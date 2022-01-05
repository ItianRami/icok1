using icok1.Domain.Entities;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Text;

namespace icok1.RecordsGenerator.Classes
{
    public class CosmosDbHandler
    {
        /// The Azure Cosmos DB endpoint for running this GetStarted sample.
        private string _endpointUrl = "https://study-icok.documents.azure.com:443/";

        /// The primary key for the Azure DocumentDB account.
        private string _primaryKey = "vxBxp3cb4lJmXTDRQycAmC3JQycgnTSeIcVIB2RquLg3ZLp0FTTMcHd2PNrJVjDNlSs0lP8DFq7XDcLMfCgiGg==";

        // The Cosmos client instance
        private CosmosClient _cosmosClient;

        // The database we will create
        private Database _database;

        // The container we will create.
        public Container Container { get; private set; }

        // The name of the database and container we will create
        private string _databaseId = "DatabaseId";
        private string _containerId = "ContainerId";

        // The partitionKey we will create.
        private string _partitionKey = "PK";

        public CosmosDbHandler(
            string endpointUrl = null,
            string primaryKey = null,
            string databaseName = null,
            string containerName = null,
            string partitionKey = null
            )
        {
            if (endpointUrl != null & endpointUrl != "")
            {
                _endpointUrl = endpointUrl;
            }
            if (primaryKey == null & primaryKey != "")
            {
                _primaryKey = primaryKey;
            }
            if (databaseName == null & databaseName != "")
            {
                _databaseId = databaseName;
            }
            if (containerName != null & containerName != "")
            {
                _containerId = containerName;
            }
            if (partitionKey != null & partitionKey != "")
            {
                _partitionKey = partitionKey;
            }
            // Create a new instance of the Cosmos Client
            _cosmosClient = new CosmosClient(_endpointUrl, _primaryKey);

            var dbResult = CreateDatabase();
            if (dbResult.StatusCode == System.Net.HttpStatusCode.OK || dbResult.StatusCode == System.Net.HttpStatusCode.Created)
            {
                try
                {
                    CreateContainer();
                }
                catch (Exception e)
                {
                    //(Parameter 'PartitionKey')
                    if (e.Message.Contains("(The requested partition key path '/" + _partitionKey + "' does not match existing Container"))
                    {
                        Console.WriteLine("Container Status | Name: {0} | {1}\n", System.Net.HttpStatusCode.Conflict.ToString(), "..[Hidden]..");
                        Console.WriteLine("The requested partition key path '/" + _partitionKey + "' does not match existing Container.");
                        return;
                    }
                    throw e;
                }
            }
            //await this.CreateDatabaseAsync();
            //await this.CreateContainerAsync();
            //await this.AddItemsToContainerAsync();
            //await this.QueryItemsAsync();
        }

        public DatabaseResponse CreateDatabase()
        {
            // check database
            var dbResult = _cosmosClient.CreateDatabaseIfNotExistsAsync(_databaseId).Result;
            _database = dbResult;
            Console.WriteLine("Database Status | Name: {0} | {1}\n", dbResult.StatusCode, dbResult.Database.Id);
            return dbResult;
        }

        public void CreateContainer()
        {
            // check container
            var containerResult = _database.CreateContainerIfNotExistsAsync(_containerId, "/" + _partitionKey).Result;
            Container = containerResult;
            Console.WriteLine("Container Status | Name: {0} | {1}\n", containerResult.StatusCode, containerResult.Container.Id);
        }

        public void ClearDatabase()
        {
            DatabaseResponse databaseResourceResponse = this._database.DeleteAsync().Result;
            // Also valid: await cosmosClient.Databases["_databaseId"].DeleteAsync();

            Console.WriteLine("Deleted Database: {0}\n", _databaseId);
            ConsoleExtensions.WriteSpaceLine();
            //this._cosmosClient.Dispose();
        }

        public void GenerateProducts()
        {
            Console.WriteLine("Product container name = (ProductContainerId is the default value)");
            var productContainerId = Console.ReadLine();
            if (productContainerId.Length == 0)
            {
                productContainerId = "ProductContainerId";
            }
            //set partition key
            Console.WriteLine("Partition key = / (Partition Key of the container)");
            var productPartitionkey = Console.ReadLine();
            var cosmosDbProduct = new CosmosDbHandler(_endpointUrl, _primaryKey, _databaseId, productContainerId, productPartitionkey);

            //gen prod
            List<Product> prods = new()
            {
                new Product { Id = "1", ProductName = "Icecream", Size = "Large", Type = "Cup", UnitPrice = 9 },
                new Product { Id = "2", ProductName = "Icecream", Size = "Medium", Type = "Cup", UnitPrice = 6.5M },
                new Product { Id = "3", ProductName = "Icecream", Size = "Small", Type = "Cup", UnitPrice = 3 },
                new Product { Id = "4", ProductName = "Icecream", Size = "Large", Type = "Cone", UnitPrice = 10 },
                new Product { Id = "5", ProductName = "Icecream", Size = "Medium", Type = "Cone", UnitPrice = 8.5M },
                new Product { Id = "6", ProductName = "Icecream", Size = "Small", Type = "Cone", UnitPrice = 3 },
            };
            int counter = 0;
            foreach (var item in prods)
            {
                try
                {
                    var prod = cosmosDbProduct.Container.CreateItemAsync(item, new PartitionKey(item.Id)).Result;
                    Console.WriteLine("New record created: {0} - {1}", item.ProductName, item.Size);
                    counter++;
                }
                catch (Exception e)
                {
                    Console.WriteLine("New record could not be created: {0} - {1}", item.ProductName, item.Size);
                    Console.WriteLine("Reason: {0}", e.Message);
                }
            }
            Console.WriteLine("New records created");
            Console.WriteLine("Total record created: {0}", counter);
            ConsoleExtensions.WriteSpaceLine();
        }

        internal void GenerateRecords()
        {
            Console.WriteLine("comming soon");
            //get number
            //get user 
            //generate orders
        }

    }
}
