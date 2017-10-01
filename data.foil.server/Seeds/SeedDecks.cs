using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Data.Foil.Server.Enums;
using Data.Foil.Server.Models.Cards;
using Data.Foil.Server.Models.Decks;
using Humanizer;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

namespace Data.Foil.Server.Seeds
{
	public static class SeedDecks
	{
		public static async Task Seed(IDocumentClient client, string databaseId, string collectionId)
		{
			var collectionLink = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);

			await SeedDeck(client, collectionLink, databaseId);
		}

		private static async Task SeedDeck(IDocumentClient client, Uri collectionLink, string databaseId)
		{
			var decks = new List<Deck>();

			decks.Add(new Deck
			{
				Description = "Beginner Deck",
				Title = "Starter",
				OneRing = (OneRing)await GetCard(client, databaseId, 1),
				Sites = new Collection<Site>
				{
					(Site)await GetCard(client, databaseId, 319),
					(Site)await GetCard(client, databaseId, 314)
				}
			});

			foreach (var deck in decks)
			{
				await client.CreateDocumentAsync(collectionLink, deck);
			}
		}

		private static async Task<Card> GetCard(IDocumentClient client, string databaseId, int number)
		{
			var collectionId = typeof(Card).Name.Pluralize();

			var query = client.CreateDocumentQuery<Card>(UriFactory.CreateDocumentCollectionUri(databaseId, collectionId), new FeedOptions { MaxItemCount = -1 }).Where(x => x.Number == number).AsDocumentQuery();

			var results = new List<Card>();

			while (query.HasMoreResults)
			{
				results.AddRange(await query.ExecuteNextAsync<Card>());
			}

			return results.FirstOrDefault();
		}
	}
}