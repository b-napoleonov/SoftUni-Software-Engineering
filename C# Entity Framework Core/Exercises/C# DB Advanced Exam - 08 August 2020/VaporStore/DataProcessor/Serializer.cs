namespace VaporStore.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.Linq;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			var result = context.Genres
				.ToList()
				.Where(x => genreNames.Contains(x.Name))
				.Select(x => new
				{
					Id = x.Id,
					Genre = x.Name,
					Games = x.Games.Where(x => x.Purchases.Any())
					.Select(x => new
					{
						Id = x.Id,
						Title = x.Name,
						Developer = x.Developer.Name,
						Tags = string.Join(", ", x.GameTags.Select(x => x.Tag.Name)),
						Players = x.Purchases.Count()
					})
					.OrderByDescending(x => x.Players)
					.ThenBy(x => x.Id)
					.ToList(),
					TotalPlayers = x.Games.Sum(tp => tp.Purchases.Count())
				})
				.OrderByDescending(x => x.TotalPlayers)
				.ThenBy(x => x.Id)
				.ToList();

			return JsonConvert.SerializeObject(result, Formatting.Indented);
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			var result = context.Users
				.ToArray()
				.Where(x => x.Cards.Any(c => c.Purchases.Any(p => p.Type.ToString() == storeType)))
				.Select(x => new PurchasesByTypeExportModel
                {
					UserName = x.Username,
					Purchases = x.Cards.SelectMany(c => c.Purchases)
						.Where(x => x.Type.ToString() == storeType)
						.Select(x => new PurchaseExportModel
                        {
							Card = x.Card.Number,
							Cvc = x.Card.Cvc,
							Date = x.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
							Game = new GameExportModel
                            {
								Title = x.Game.Name,
								Genre = x.Game.Genre.Name,
								Price = x.Game.Price
                            }
						})
						.OrderBy(x => x.Date)
						.ToArray(),
					TotalSpent = x.Cards.Sum(x => x.Purchases.Where(p => p.Type.ToString() == storeType).Sum(p => p.Game.Price))
				})
				.OrderByDescending(x => x.TotalSpent)
				.ThenBy(x => x.UserName)
				.ToArray();

			return XmlConverter.Serialize(result, "Users");
		}
	}
}