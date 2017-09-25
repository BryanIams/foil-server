using Data.Foil.Server.Connections;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Humanizer;

namespace Data.Foil.Server.Repositories
{
	public class Repository<T> where T : class
	{
		private readonly CosmosDbConnection _cosmosDbConnection;
		private readonly string _collectionId = typeof(T).Name.Pluralize();

		public Repository(CosmosDbConnection cosmosDbConnection)
		{
			_cosmosDbConnection = cosmosDbConnection;

			CreateCollectionIfNotExists().Wait();
		}

		public async Task<T> Get(string id)
		{
			var document = await _cosmosDbConnection.Client.ReadDocumentAsync(UriFactory.CreateDocumentUri(_cosmosDbConnection.DatabaseId, _collectionId, id));

			return (T) (dynamic) document;
		}

		public async Task<IEnumerable<T>> GetItems(Expression<Func<T, bool>> predicate)
		{
			var query = _cosmosDbConnection.Client.CreateDocumentQuery<T>(UriFactory.CreateDocumentCollectionUri(_cosmosDbConnection.DatabaseId, _collectionId), new FeedOptions {MaxItemCount = -1}).Where(predicate).AsDocumentQuery();

			var results = new List<T>();

			while (query.HasMoreResults)
			{
				results.AddRange(await query.ExecuteNextAsync<T>());
			}

			return results;
		}

		private async Task CreateCollectionIfNotExists()
		{
			await _cosmosDbConnection.Client.ReadDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri(_cosmosDbConnection.DatabaseId, _collectionId));
		}
	}
}