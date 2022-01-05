using icok1.RecordsGenerator.Classes;
using Microsoft.Azure.Cosmos;
using System;
using System.Threading.Tasks;
using icok1.Domain;
using icok1.Domain.Entities;
using System.Collections.Generic;

namespace icok1.RecordsGenerator
{
    class Program
    {
        private static CosmosDbHandler _cosmosDb;

        public static string EndpointUrl { get; set; }
        public static string PrimaryKey { get; set; }
        public static string DatabaseId { get; set; }
        public static string ContainerId { get; set; }
        public static string Partitionkey { get; set; }

        public static async Task Main(string[] args)
        {
            Console.Title = "CosmosDb Record Generator";
            try
            {
                Program p = new();
                //welcome
                ConsoleExtensions.ShowWelcomeScreen();

                ConsoleExtensions.WriteSpaceLine();
                //Console.WriteLine("                                                  ");

                //set db
                GetDbInputs();

                while (true)
                {
                    //menu
                    var selectedMenuItem = ConsoleExtensions.ShowMenu(_cosmosDb.Container == null);
                    ChooseAction(selectedMenuItem);
                }

            }
            catch (CosmosException de)
            {
                Exception baseException = de.GetBaseException();
                Console.WriteLine("{0} error occurred: {1}", de.StatusCode, de);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e);
            }
            finally
            {
                Console.WriteLine("End of app, press any key to exit.");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        private static void GetDbInputs()
        {
            //set endpointUrl
            Console.WriteLine("Endpoint url = (Azure CosmosDb endpont url)");
            EndpointUrl = Console.ReadLine();

            //set primaryKey
            Console.WriteLine("Primary key = (The CosmosDb Account key)");
            PrimaryKey = Console.ReadLine();

            //set databaseId
            Console.WriteLine("Database name = (DatabaseId is the default value)");
            DatabaseId = Console.ReadLine();

            //set container
            Console.WriteLine("Container name = (ContainerId is the default value)");
            ContainerId = Console.ReadLine();

            //set partition key
            Console.WriteLine("Partition key = / (Partition Key of the container)");
            Partitionkey = Console.ReadLine();

            Console.WriteLine("Beginning operations...\n");
            _cosmosDb = new CosmosDbHandler(EndpointUrl, PrimaryKey, DatabaseId, ContainerId, Partitionkey);
            ConsoleExtensions.WriteSpaceLine();
        }

        public static void ChooseAction(string selectedMenuItem)
        {
            switch (selectedMenuItem)
            {
                case "D1":
                    Console.WriteLine("Deleting DB..");
                    _cosmosDb.ClearDatabase();

                    Console.WriteLine("Creating new DB with your criteria..");
                    GetDbInputs();
                    break;
                case "D2":
                    //generate products
                    _cosmosDb.GenerateProducts();
                    break;
                case "D3":
                    //get number
                    //get user 
                    //generate orders
                    _cosmosDb.GenerateRecords();
                    break;
                case "D4":
                    GetDbInputs();
                    break;
                case "D5":
                    Environment.Exit(0);
                    break;
                default:
                    ConsoleExtensions.SetColor(ConsoleColor.Red);
                    Console.WriteLine("Bad Request");
                    Console.ResetColor();
                    break;
            }

        }

        //private async Task QueryItemsAsync()
        //{
        //    var sqlQueryText = "SELECT * FROM c WHERE c.LastName = 'Andersen'";

        //    Console.WriteLine("Running query: {0}\n", sqlQueryText);

        //    QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
        //    FeedIterator<Family> queryResultSetIterator = this.container.GetItemQueryIterator<Family>(queryDefinition);

        //    List<Family> families = new List<Family>();

        //    while (queryResultSetIterator.HasMoreResults)
        //    {
        //        FeedResponse<Family> currentResultSet = await queryResultSetIterator.ReadNextAsync();
        //        foreach (Family family in currentResultSet)
        //        {
        //            families.Add(family);
        //            Console.WriteLine("\tRead {0}\n", family);
        //        }
        //    }
        //}

    }
}