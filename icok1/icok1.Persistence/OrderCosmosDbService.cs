using icok1.Domain.Entities;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace icok1.Persistence
{
    public class OrderCosmosDbService : ICosmosDbServiceT<Order>
    {
        private Container _container;

        public OrderCosmosDbService(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task<IEnumerable<Order>> ListAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<Order>(new QueryDefinition(queryString));
            List<Order> results = new List<Order>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task<Order> GetAsync(string id)
        {
            try
            {
                ItemResponse<Order> response = await this._container.ReadItemAsync<Order>(id.ToString(), new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

        }

        public async Task AddAsync(Order item)
        {
            await this._container.CreateItemAsync<Order>(item, new PartitionKey(item.Id));
        }

        public async Task UpdateAsync(string id, Order item)
        {
            await this._container.UpsertItemAsync<Order>(item, new PartitionKey(id));
        }

        public async Task DeleteAsync(string id)
        {
            await this._container.DeleteItemAsync<Order>(id.ToString(), new PartitionKey(id));
        }

    }
}