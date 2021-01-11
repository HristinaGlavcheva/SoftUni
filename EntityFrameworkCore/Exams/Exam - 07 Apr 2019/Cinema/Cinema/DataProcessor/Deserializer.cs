namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Cinema.XMLHelper;
    using Data;
    using Microsoft.EntityFrameworkCore.Internal;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var movieDTOs = JsonConvert.DeserializeObject<List<ImportMovieDTO>>(jsonString);

            var validMovies = new List<Movie>();

            foreach (var movieDTO in movieDTOs)
            {
                if (!IsValid(movieDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (validMovies.Any(m => m.Title == movieDTO.Title))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                validMovies.Add(new Movie
                {
                    Title = movieDTO.Title,
                    Genre = (Genre)movieDTO.Genre,
                    Duration = TimeSpan.Parse(movieDTO.Duration),
                    Rating = movieDTO.Rating,
                    Director = movieDTO.Director
                });

                sb.AppendLine(string.Format(SuccessfulImportMovie, movieDTO.Title, movieDTO.Genre, movieDTO.Rating.ToString("F2")));
            }

            context.Movies.AddRange(validMovies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var hallSeatsDTOs = JsonConvert.DeserializeObject<List<ImportHallSeatsDTO>>(jsonString);

            var validHalls = new List<Hall>();
            var validSeats = new List<Seat>();

            foreach (var hallSeatsDTO in hallSeatsDTOs)
            {
                if (!IsValid(hallSeatsDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var newHall = new Hall
                {
                    Name = hallSeatsDTO.Name,
                    Is3D = hallSeatsDTO.Is3D,
                    Is4Dx = hallSeatsDTO.Is4Dx
                };

                validHalls.Add(newHall);

                for (int i = 0; i < hallSeatsDTO.Seats; i++)
                {
                    var newSeat = new Seat
                    {
                        Hall = newHall
                    };

                    validSeats.Add(newSeat);
                }

                int seatsCount = hallSeatsDTO.Seats;
                string projectionType = "Normal";

                if (hallSeatsDTO.Is4Dx && hallSeatsDTO.Is3D)
                {
                    projectionType = "4Dx/3D";
                }
                else if (hallSeatsDTO.Is3D)
                {
                    projectionType = "3D";
                }
                else if (hallSeatsDTO.Is4Dx)
                {
                    projectionType = "4Dx";
                }

                sb.AppendLine(string.Format(SuccessfulImportHallSeat, hallSeatsDTO.Name, projectionType, seatsCount));
            }

            context.Halls.AddRange(validHalls);
            context.Seats.AddRange(validSeats);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            string rootElement = "Projections";
            StringBuilder sb = new StringBuilder();

            var importProjectionDTOs = XMLConverter.Deserializer<ImportProjectionDTO>(xmlString, rootElement);

            var validProjections = new List<Projection>();

            foreach (var importProjectionDTO in importProjectionDTOs)
            {
                if (!context.Halls.Any(h => h.Id == importProjectionDTO.HallId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if(!context.Movies.Any(m => m.Id == importProjectionDTO.MovieId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var newProjection = new Projection
                {
                    MovieId = importProjectionDTO.MovieId,
                    HallId = importProjectionDTO.HallId,
                    DateTime = DateTime.ParseExact(importProjectionDTO.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                };

                validProjections.Add(newProjection);
               
                string dateTime = newProjection.DateTime.ToString("MM/dd/yyyy");
                string movieTitle = context.Movies.First(m => m.Id == newProjection.MovieId).Title;

                //sb.AppendLine(string.Format(SuccessfulImportProjection, newProjection.Movie.Title, dateTime));
                //null reference exception, защото на newProjection не сме сетнали Movie = ...., затова си го дърпаме от базата:
                //sb.AppendLine(string.Format(SuccessfulImportProjection, movieTitle, dateTime));

                //друг вариант е първо да добавим newProjection в базата и тогава вече имаме достъп до newProjection.Movie.Title - намира си го в базата по MovieId:
                context.Projections.Add(newProjection); //и тогава
                sb.AppendLine(string.Format(SuccessfulImportProjection, newProjection.Movie.Title, dateTime));
                //в този случай List validProjections e излишен и дори работи по-бързо
            }

            context.Projections.AddRange(validProjections);
            context.SaveChanges();

            return sb.ToString().TrimEnd(); ;
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            string rootElement = "Customers";
            var importCustomerDTOs = XMLConverter.Deserializer<ImportCustomerDTO>(xmlString, rootElement);

            foreach (var importCustomerDTO in importCustomerDTOs)
            {
                if (!IsValid(importCustomerDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var newCustormer = new Customer
                {
                    FirstName = importCustomerDTO.FirstName,
                    LastName = importCustomerDTO.LastName,
                    Age = importCustomerDTO.Age,
                    Balance = importCustomerDTO.Balance,
                };

                foreach (var importTicketDTO in importCustomerDTO.Tickets)
                {
                    if (!context.Projections.Any(p => p.Id == importTicketDTO.ProjectionId))
                    {
                        continue;
                    }

                    Ticket newTicket = new Ticket
                    {
                        ProjectionId = importTicketDTO.ProjectionId,
                        Price = importTicketDTO.Price
                    };

                    newCustormer.Tickets.Add(newTicket);
                }


                if(newCustormer.Tickets.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                context.Customers.Add(newCustormer);

                sb.AppendLine(string.Format(SuccessfulImportCustomerTicket, newCustormer.FirstName, newCustormer.LastName, newCustormer.Tickets.Count));
            }

            context.SaveChanges();

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