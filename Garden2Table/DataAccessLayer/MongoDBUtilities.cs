using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices.WindowsRuntime;
using Garden2Table.Models;
using MongoDB.Bson;
using MongoDB.Driver;




namespace Garden2Table.DataAccessLayer
{
    class MongoDBUtilities
    {
        private static MongoClient _client;

        /// <summary>
        /// test for connection to online MongoDb 
        /// </summary>
        /// <returns>true if connected</returns>
        public static bool Connection()
        {
            try
            {
                _client = new MongoClient(MongoDBDataSettings.connectionString);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// write seed data to online MongoDb database/collection
        /// </summary>
        /// <returns>true of seed data added successfully</returns>
        public static bool WriteSeedDataToDatabase()
        {
            if (Connection())
            {
                //
                // get collection
                //
                IMongoDatabase database = _client.GetDatabase(MongoDBDataSettings.databaseName);
                IMongoCollection<Stands> collection = database.GetCollection<Stands>(MongoDBDataSettings.collectionName);

                //
                // delete all existing documents in collection
                //
                var filter = Builders<Stands>.Filter.Empty;
                collection.DeleteMany(filter);

                //
                // write all seed data to collection
                //
                var test = SeedData.GetStandsList();
                collection.InsertMany(SeedData.GetStandsList());
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}


