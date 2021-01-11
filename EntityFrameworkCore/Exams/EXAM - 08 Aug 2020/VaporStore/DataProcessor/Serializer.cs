namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Export;
    using VaporStore.XMLHelper;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
            //var games = context
            //	.Games
            //	.Where(g => genreNames.Contains(g.Genre.Name))
            //	.Where(g => g.Purchases.Count > 0)
            //	.ToList()
            //	.Select(g => new ExportGenreDTO
            //             {
            //		Id = g.Id,
            //		Genre = g.Genre,
            //		Games = new ExportGameDTO
            //                 {

            //                 }
            //             }

            //var genres = context.Genres
            //    .Where(g => genreNames.Contains(g.Name))
            //    .AsEnumerable()
            //    .Select(g => new
            //    {
            //        Id = g.Id,
            //        Genre = g.Name,
            //        Games = g.Games
            //                    .Where(ga => ga.Purchases.Any())
            //                    .Select(ga => new
            //                    {
            //                        Id = ga.Id,
            //                        Title = ga.Name,
            //                        Developer = ga.Developer.Name,
            //                        Tags = string.Join(", ", ga.GameTags.Select(gt => gt.Tag.Name)),
            //                        Players = ga.Purchases.Count
            //                    })
            //                    .OrderByDescending(ga => ga.Players)
            //                    .ThenBy(ga => ga.Id),
            //        TotalPlayers = g.Games.Sum(ga => ga.Purchases.Count)
            //    })
            //    .OrderByDescending(g => g.TotalPlayers)
            //    .ThenBy(g => g.Id)
            //    .ToArray();

            var games = context
                .Games
                .Where(g => genreNames.Contains(g.Genre.Name))
                .Where(g => g.Purchases.Count > 0)
                .ToList()
                .Select(g => new
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.GameTags.Select(gt => gt.Game).Select(game => new
                    {
                        Id = game.Id,
                        Title = game.Name,
                        Developer = game.Developer.Name,
                        Tags = string.Join(", ", game.GameTags),
                        Players = game.Purchases.Count
                    })
                        .ToList()
                        .OrderByDescending(game => game.Players)
                        .OrderBy(game => game.Id),
                    TotalPlayers = g.GameTags.Select(gt => gt.Game.Purchases.Count)
                })
                .ToList()
                .OrderByDescending(g => g.Games.Sum(game => game.Players))
                .OrderBy(g => g.Id);

            string result = JsonConvert.SerializeObject(games, Formatting.Indented);

			return result;
		}

		//The given method in the project skeleton receives an array of genre names.
		//	Export all games in those genres, which have any purchases.
		//	For each genre, export its id, genre name, games and total players(total purchase count). 
		//	For each game, export its id, name, developer, tags(separated by ", ") and total player count(purchase count). 
		//	Order the games by player count(descending), then by game id(ascending).
		//	Order the genres by total player count(descending), then by genre id(ascending)


		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
            string rootElement = "Users";

            //var users = context
            //    .Users
            //    .ToList()
            //    .Where(u => u.Cards.Select(c => c.Purchases.Count > 0))


            //Use the method provided in the project skeleton, which receives a purchase type as a string.
            //    Export all users who have any purchases. 
            //    For each user, export their username, purchases for that purchase type 
            //    and total money spent for that purchase type.
            //        For each purchase, export its card number, CVC, date in the format "yyyy-MM-dd HH:mm"(make sure you use CultureInfo.InvariantCulture)
            //        and the game.
            //        For each game, export its title(name), genre and price.Order the users by total spent(descending), 
            //        then by username(ascending).For each user, order the purchases by date(ascending).
            //        Do not export users, who don’t have any purchases.



            //string result = XMLConverter.Serialize<List<ExportPurchasesDTO>>(users, rootElement);
            //return result;

            return null;

        }
	}
}