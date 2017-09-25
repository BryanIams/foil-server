using System;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Options;
using utility.foil.server.ApplicationConfiguration.Options;

namespace Data.Foil.Server.Connections
{
	public class CosmosDbConnection
	{
		private readonly CosmosDb _cosmosDb;

		public CosmosDbConnection(IOptions<CosmosDb> cosmoDbOptionsSnapshot)
		{
			_cosmosDb = cosmoDbOptionsSnapshot.Value;

			Client = new DocumentClient(new Uri(_cosmosDb.EndpointUrl), _cosmosDb.PrimaryKey, new ConnectionPolicy {EnableEndpointDiscovery = false});

			CreateDatabaseIfNotExists().Wait();
		}

		public DocumentClient Client { get; }

		public string DatabaseId => _cosmosDb.DatabaseId;

		private async Task CreateDatabaseIfNotExists()
		{
			await Client.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(_cosmosDb.DatabaseId));
		}
	}
}