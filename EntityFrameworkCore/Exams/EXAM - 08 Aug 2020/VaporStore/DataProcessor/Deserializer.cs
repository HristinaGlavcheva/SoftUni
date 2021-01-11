namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Internal;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Import;
    using VaporStore.XMLHelper;

    public static class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var importGameDTOs = JsonConvert.DeserializeObject<List<ImportGameDTO>>(jsonString);

            foreach (var importGameDTO in importGameDTOs)
            {
                if (!IsValid(importGameDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (importGameDTO.Tags.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!context.Developers.Any(d => d.Name == importGameDTO.Developer))
                {
                    var newDeveloper = new Developer
                    {
                        Name = importGameDTO.Developer
                    };

                    context.Add(newDeveloper);
                    context.SaveChanges();
                }

                if (!context.Genres.Any(g => g.Name == importGameDTO.Genre))
                {
                    var newGenre = new Genre
                    {
                        Name = importGameDTO.Genre
                    };

                    context.Genres.Add(newGenre);
                    context.SaveChanges();
                }

                var newGame = new Game
                {
                    Name = importGameDTO.Name,
                    Price = importGameDTO.Price,
                    ReleaseDate = DateTime.ParseExact(importGameDTO.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Developer = context.Developers.First(d => d.Name == importGameDTO.Developer),
                    Genre = context.Genres.First(g => g.Name == importGameDTO.Genre)
                };

                foreach (var tagInDTO in importGameDTO.Tags)
                {
                    if (!context.Tags.Any(t => t.Name == tagInDTO))
                    {
                        var newTag = new Tag
                        {
                            Name = tagInDTO
                        };

                        context.Add(newTag);
                        context.SaveChanges();
                    }

                    newGame.GameTags.Add(new GameTag
                    {
                        Tag = context.Tags.First(t => t.Name == tagInDTO)
                    });
                }

                context.Games.Add(newGame);
                context.SaveChanges();

                sb.AppendLine($"Added {newGame.Name} ({newGame.Genre.Name}) with {newGame.GameTags.Count} tags");

            }
            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var importUserDTOs = JsonConvert.DeserializeObject<List<ImportUserDTO>>(jsonString);

            foreach (var importUserDTO in importUserDTOs)
            {
                if (!IsValid(importUserDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (importUserDTO.Cards.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var importCardDTO in importUserDTO.Cards)
                {
                    if (!IsValid(importCardDTO))
                    {
                        //sb.AppendLine(ErrorMessage);
                        continue;
                    }
                }

                var newUser = new User
                {
                    Username = importUserDTO.Username,
                    FullName = importUserDTO.FullName,
                    Age = importUserDTO.Age,
                    Email = importUserDTO.Email,
                    Cards = importUserDTO.Cards
                };

                context.Add(newUser);
                context.SaveChanges();

                sb.AppendLine($"Imported {newUser.Username} with {newUser.Cards.Count} cards");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            string rootElement = "Purchases";

            var importPurchaseDTOs = XMLConverter.Deserializer<ImportPurchaseDTO>(xmlString, rootElement);

            foreach (var importPurchaseDTO in importPurchaseDTOs)
            {
                if (!IsValid(importPurchaseDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var newPurchase = new Purchase
                {
                    Game = context.Games.First(g => g.Name == importPurchaseDTO.GameName),
                    Type = importPurchaseDTO.Type,
                    ProductKey = importPurchaseDTO.ProductKey,
                    Date = DateTime.ParseExact(importPurchaseDTO.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Card = context.Cards.First(c => c.Number == importPurchaseDTO.CardNumber)
                };

                context.Add(newPurchase);
                context.SaveChanges();

                sb.AppendLine($"Imported {newPurchase.Game.Name} for {newPurchase.Card.User.Username}");
            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}