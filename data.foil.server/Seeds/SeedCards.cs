using Data.Foil.Server.Models.Cards;
using Microsoft.Azure.Documents;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;

namespace Data.Foil.Server.Seeds
{
	public static class SeedCards
	{
		public static async Task Seed(IDocumentClient client, string databaseId, string collectionId)
		{
			var collectionLink = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);

			var cards = new List<Card>();

			cards.Add(new Card {Description = "Isildur's Bane", Title = "The One Ring", Number = 1, Url = "01.jpg"});

			foreach (var card in cards)
			{
				await client.CreateDocumentAsync(collectionLink, card);
			}
		}
	}
}