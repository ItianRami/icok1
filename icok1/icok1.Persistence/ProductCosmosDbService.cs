using icok1.Domain.Entities;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace icok1.Persistence
{
    public class ProductCosmosDbService : ICosmosDbServiceT<Product>
    {
        private Container _container;

        public ProductCosmosDbService(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }
        
        public async Task<IEnumerable<Product>> ListAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<Product>(new QueryDefinition(queryString));
            List<Product> results = new List<Product>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }
        
        public async Task<Product> GetAsync(string id)
        {
            try
            {
                ItemResponse<Product> response = await this._container.ReadItemAsync<Product>(id.ToString(), new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

        }
        
        public async Task AddAsync(Product item)
        {
            await this._container.CreateItemAsync<Product>(item, new PartitionKey(item.Id));
        }
        
        public async Task UpdateAsync(string id, Product item)
        {
            await this._container.UpsertItemAsync<Product>(item, new PartitionKey(id));
        }

        public async Task DeleteAsync(string id)
        {
            await this._container.DeleteItemAsync<Product>(id.ToString(), new PartitionKey(id));
        }

    }
}