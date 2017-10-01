using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;
using Data.Foil.Server.Models.Cards;
using Data.Foil.Server.Models.Decks;
using Humanizer;
using Microsoft.Azure.Documents;
using Newtonsoft.Json;
using utility.foil.server.ApplicationConfiguration.Options;

namespace Data.Foil.Server.Seeds
{
	public class SeedData
	{
		private readonly CosmosDb _cosmosDb;

		public SeedData(IOptions<CosmosDb> cosmoDbOptionsSnapshot)
		{
			_cosmosDb = cosmoDbOptionsSnapshot.Value;
		}

		public async Task Seed()
		{
			var client = new DocumentClient(new Uri(_cosmosDb.EndpointUrl), _cosmosDb.PrimaryKey, new JsonSerializerSettings{ TypeNameHandling = TypeNameHandling.All }, new ConnectionPolicy { EnableEndpointDiscovery = false } );

			await CreateDatabaseIfNotExists(client);

			await SeedCards(client);
			await SeedDecks(client);
		}

		private async Task SeedCards(IDocumentClient client)
		{
			var collectionId = typeof(Card).Name.Pluralize();

			await CreateCollection(client, collectionId);

			await Seeds.SeedCards.Seed(client, _cosmosDb.DatabaseId, collectionId);
		}

		private async Task SeedDecks(IDocumentClient client)
		{
			var collectionId = typeof(Deck).Name.Pluralize();

			await CreateCollection(client, collectionId);

			await Seeds.SeedDecks.Seed(client, _cosmosDb.DatabaseId, collectionId);
		}

		private async Task CreateDatabaseIfNotExists(IDocumentClient client)
		{
			await client.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(_cosmosDb.DatabaseId));
		}

		private async Task CreateCollection(IDocumentClient client, string collectionId)
		{
			var databaseUri = UriFactory.CreateDatabaseUri(_cosmosDb.DatabaseId);

			var collection = client.CreateDocumentCollectionQuery(databaseUri)
					.Where(c => c.Id == collectionId)
					.AsEnumerable()
					.FirstOrDefault();

			if (collection != null)
			{
				await client.DeleteDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri(_cosmosDb.DatabaseId, collectionId));
			}

			await client.CreateDocumentCollectionAsync(databaseUri, new DocumentCollection { Id = collectionId });
		}
	}
}