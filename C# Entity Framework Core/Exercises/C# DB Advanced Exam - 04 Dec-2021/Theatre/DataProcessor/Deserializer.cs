namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var plays = new List<Play>();

            var playsDTO = XmlConverter.Deserializer<PlayXMLImportModel>(xmlString, "Plays");

            foreach (var currentPlay in playsDTO)
            {
                var isValidTimeSpan = TimeSpan.TryParseExact(currentPlay.Duration, "c", CultureInfo.InvariantCulture,
                  TimeSpanStyles.None,
                  out TimeSpan duration);

                if (!IsValid(currentPlay) || duration.TotalHours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var play = new Play
                {
                    Title = currentPlay.Title,
                    Duration = duration,
                    Rating = currentPlay.Rating,
                    Genre = Enum.Parse<Genre>(currentPlay.Genre),
                    Description = currentPlay.Description,
                    Screenwriter = currentPlay.Screenwriter,
                };

                plays.Add(play);

                sb.AppendLine(String.Format(SuccessfulImportPlay, play.Title, play.Genre, play.Rating));
            }

            context.AddRange(plays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var casts = new List<Cast>();

            var castsDTO = XmlConverter.Deserializer<CastXMLImportModel>(xmlString, "Casts");

            foreach (var currentCast in castsDTO)
            {
                if (!IsValid(currentCast))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var cast = new Cast
                {
                    FullName = currentCast.FullName,
                    IsMainCharacter = currentCast.IsMainCharacter,
                    PhoneNumber = currentCast.PhoneNumber,
                    PlayId = currentCast.PlayId
                };

                casts.Add(cast);

                sb.AppendLine(string.Format(SuccessfulImportActor, cast.FullName, cast.IsMainCharacter ? "main" : "lesser"));
            }

            context.AddRange(casts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var theatres = new List<Theatre>();

            var theatreDTO = JsonConvert.DeserializeObject<IEnumerable<TheaterTicketJSONImportModel>>(jsonString);

            foreach (var currentTheatre in theatreDTO)
            {
                if (!IsValid(currentTheatre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var theatre = new Theatre
                {
                    Name = currentTheatre.Name,
                    NumberOfHalls = currentTheatre.NumberOfHalls,
                    Director = currentTheatre.Director,
                };

                foreach (var currentTicket in currentTheatre.Tickets)
                {
                    if (!IsValid(currentTicket))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    theatre.Tickets.Add(new Ticket
                    {
                        Price = currentTicket.Price,
                        RowNumber = currentTicket.RowNumber,
                        PlayId = currentTicket.PlayId
                    });
                }

                theatres.Add(theatre);

                sb.AppendLine(String.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
            }

            context.AddRange(theatres);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
