namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theaters = context.Theatres
                .ToArray()
                .Where(x => x.NumberOfHalls >= numbersOfHalls && x.Tickets.Count >= 20)
                .Select(x => new
                {
                    Name = x.Name,
                    Halls = x.NumberOfHalls,
                    TotalIncome = x.Tickets.Where(t => t.RowNumber >= 1 && t.RowNumber <= 5).Sum(t => t.Price),
                    Tickets = x.Tickets.Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)
                    .Select(x => new
                    {
                        Price = decimal.Parse(x.Price.ToString("F2")),
                        RowNumber = x.RowNumber,
                    })
                    .OrderByDescending(x => x.Price)
                })
                .OrderByDescending(x => x.Halls)
                .ThenBy(x => x.Name)
                .ToList();

            return JsonConvert.SerializeObject(theaters, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context.Plays
                .ToArray()
                .Where(x => x.Rating <= rating)
                .Select(x => new PlayXMLExportModel
                {
                    Title = x.Title,
                    Duration = x.Duration.ToString(),
                    Rating = x.Rating > 0 ? x.Rating.ToString() : "Premier",
                    Genre = x.Genre.ToString(),
                    Actor = x.Casts.Where(a => a.IsMainCharacter).Select(x => new ActorsXmlExportModel
                    {
                        FullName = x.FullName,
                        MainCharacter = $"Plays main character in '{x.Play.Title}'."
                    })
                    .OrderByDescending(x => x.FullName)
                    .ToArray()
                })
                .OrderBy(x => x.Title)
                .ThenByDescending(x => x.Genre)
                .ToList();

            return XmlConverter.Serialize(plays, "Plays");
        }
    }
}
