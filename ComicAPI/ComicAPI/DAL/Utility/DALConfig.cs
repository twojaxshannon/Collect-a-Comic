using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicAPI.DAL.Utility
{
    public class DALConfig
    {
        public string MongoConnectionString { get; set; }
        public string DefaultDatabase;

        /// <summary>
        /// Initialize with a default connection string and database.
        /// </summary>
        public DALConfig()
        {
            MongoConnectionString = "mongodb://127.0.0.1:27017";
            DefaultDatabase = "CollectAComicDB";
        }

        /// <summary>
        /// Initialize with a default connection string and custom database name.
        /// </summary>
        /// <param name="databaseName">Name of the database to connect to by default</param>
        public DALConfig(string databaseName)
        {
            DefaultDatabase = databaseName;
        }

        /// <summary>
        /// Initialize with a custom database name and connection string.
        /// </summary>
        /// <param name="databaseName">Name of the database to connect to by default</param>
        /// <param name="connection">Database connection string to connect to Mongo</param>
        public DALConfig(string connection, string databaseName)
        {
            MongoConnectionString = connection;
            DefaultDatabase = databaseName;
        }

        /// <summary>
        /// Fetch a MongoClient connection using the current MongoConnectionString.
        /// </summary>
        /// <returns>MongoClient connection using default connection string and database</returns>
        public MongoClient GetMongoClient()
        {
            return new MongoClient(MongoConnectionString);
        }


        /// <summary>
        /// Fetch a Mongo database connection using a new MongoClient instance.
        /// If no database name is provided, the DefaultDatabase will be used.
        /// </summary>
        /// <param name="databaseName">Name of the database to which you wish to connect (optional)</param>
        /// <returns>IMongoDatabase using the default MongoClient connection</returns>
        public IMongoDatabase GetMongoDatabase(string databaseName = "")
        {
            return GetMongoClient().GetDatabase(String.IsNullOrWhiteSpace(databaseName) ? DefaultDatabase : databaseName);
        }

        /// <summary>
        /// Fetch a Mongo database connection using the provided MongoClient.
        /// If no database name is provided, the DefaultDatabase will be used.
        /// </summary>
        /// <param name="client">MongoClient connection to use</param>
        /// <param name="databaseName">Name of the database to which you wish to connect (optional)</param>
        /// <returns>IMongoDatabase using the provided MongoClient connection</returns>
        public IMongoDatabase GetMongoDatabase(MongoClient client, string databaseName = "")
        {
            return client.GetDatabase(String.IsNullOrWhiteSpace(databaseName) ? DefaultDatabase : databaseName);
        }
    }
}
