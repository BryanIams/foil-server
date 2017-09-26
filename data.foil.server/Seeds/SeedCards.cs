using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Foil.Server.Enums;
using Data.Foil.Server.Models.Cards;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace Data.Foil.Server.Seeds
{
	public static class SeedCards
	{
		public static async Task Seed(IDocumentClient client, string databaseId, string collectionId)
		{
			var collectionLink = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);

			await SeedRings(client, collectionLink);
			await SeedSites(client, collectionLink);
		}

		private static async Task SeedRings(IDocumentClient client, Uri collectionLink)
		{
			var cards = new List<OneRing>();

			cards.Add(new OneRing {Description = "Isildur's Bane", Title = "The One Ring", Number = 1, Url = "01.jpg", HealthModifier = 1, StrengthModifier = 1, Unique = true, Kind = CardKind.TheOneRing});

			foreach (var card in cards)
			{
				await client.CreateDocumentAsync(collectionLink, card);
			}
		}

		private static async Task SeedSites(IDocumentClient client, Uri collectionLink)
		{
			var cards = new List<Site>();

			cards.Add(new Site {Title = "Trollshaw Forest", Number = 314, Url = "314.jpg", Unique = true, Kind = CardKind.Site, Shadow = 1, SiteNumber = 2});
			cards.Add(new Site {Title = "Bag End", Number = 319, Url = "319.jpg", Unique = true, Kind = CardKind.Site, Shadow = 0, SiteNumber = 1});

			foreach (var card in cards)
			{
				await client.CreateDocumentAsync(collectionLink, card);
			}
		}
	}
}