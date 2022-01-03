//using icok1.Domain;
//using icok1.Domain.Entities;
//using Microsoft.Azure.Cosmos;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace icok1.Persistence
//{
//    public class CosmosDbService<T> : ICosmosDbServiceT<T> where T : BaseEntity
//    {
//        private Container _container;

//        public CosmosDbService(
//            CosmosClient dbClient,
//            string databaseName,
//            string containerName)
//        {
//            this._container = dbClient.GetContainer(databaseName, containerName);
//        }

//        public async Task<IEnumerable<T>> ListAsync(string queryString)
//        {
//            var query = this._container.GetItemQueryIterator<T>(new QueryDefinition(queryString));
//            List<T> results = new();
//            while (query.HasMoreResults)
//            {
//                var response = await query.ReadNextAsync();
//                results.AddRange(response.ToList());
//            }

//            return results;
//        }

//        public async Task<T> GetAsync(string id)
//        {
//            try
//            {
//                ItemResponse<T> response = await this._container.ReadItemAsync<T>(id.ToString(), new PartitionKey(id));
//                return response.Resource;
//            }
//            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
//            {
//                return default(T);
//            }
//        }

//        public async Task AddAsync(T item)
//        {
//            await this._container.CreateItemAsync<T>(item, new PartitionKey(item.Id));
//        }

//        public async Task UpdateAsync(string id, T item)
//        {
//            await this._container.UpsertItemAsync<T>(item, new PartitionKey(id));
//        }

//        public async Task DeleteAsync(string id)
//        {
//            await this._container.DeleteItemAsync<T>(id.ToString(), new PartitionKey(id));
//        }

//    }
//}