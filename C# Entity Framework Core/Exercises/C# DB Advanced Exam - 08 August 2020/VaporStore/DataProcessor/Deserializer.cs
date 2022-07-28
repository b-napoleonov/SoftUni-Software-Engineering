namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var deserialize = JsonConvert.DeserializeObject<GameImportModel[]>(jsonString);

            foreach (var gameItem in deserialize)
            {
                if (!IsValid(gameItem))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime releaseDate;
                bool checkReleaseDate = DateTime.TryParseExact(gameItem.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out releaseDate);

                if (!checkReleaseDate)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var genre = context.Genres.FirstOrDefault(g => g.Name == gameItem.Genre) ?? new Genre { Name = gameItem.Genre };
                var developer = context.Developers.FirstOrDefault(d => d.Name == gameItem.Developer) ?? new Developer { Name = gameItem.Developer };

                Game game = new Game()
                {
                    Name = gameItem.Name,
                    Price = gameItem.Price,
                    ReleaseDate = releaseDate,
                    Genre = genre,
                    Developer = developer
                };

                foreach (var tagItem in gameItem.Tags)
                {
                    if (!IsValid(tagItem))
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }
                    var tag = context.Tags.FirstOrDefault(t => t.Name == tagItem) ?? new Tag { Name = tagItem };

                    game.GameTags.Add(new GameTag()
                    {
                        Tag = tag
                    });

                }
                context.Games.Add(game);
                context.SaveChanges();

                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count()} tags");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var users = new List<User>();

            var deserialized = JsonConvert.DeserializeObject<IEnumerable<UsersImportModel>>(jsonString);

            foreach (var currentUser in deserialized)
            {
                if (!IsValid(currentUser) ||
                    !currentUser.Cards.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var user = new User
                {
                    FullName = currentUser.FullName,
                    Username = currentUser.Username,
                    Email = currentUser.Email,
                    Age = currentUser.Age,
                    Cards = currentUser.Cards.Select(c => new Card
                    {
                        Number = c.Number,
                        Cvc = c.CVC,
                        Type = Enum.Parse<CardType>(c.Type)
                    })
                    .ToList()
                };

                users.Add(user);

                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var purchases = new List<Purchase>();

            var deserialized = XmlConverter.Deserializer<PurchaseImportModel>(xmlString, "Purchases");

            foreach (var currentPurchase in deserialized)
            {
                if (!IsValid(currentPurchase))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime date;
                var checkDate = DateTime.TryParseExact(currentPurchase.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture,
                  DateTimeStyles.None, 
                  out date);

                var purchase = new Purchase
                {
                    Type = Enum.Parse<PurchaseType>(currentPurchase.Type),
                    ProductKey = currentPurchase.Key,
                    Game = context.Games.FirstOrDefault(x => x.Name == currentPurchase.Title),
                    Card = context.Cards.FirstOrDefault(x => x.Number == currentPurchase.Card),
                    Date = date,
                };

                purchases.Add(purchase);

                sb.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}");
            }

            context.Purchases.AddRange(purchases);
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