using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garden2Table.Models;
using Garden2Table.BusinessLayer;
using Garden2Table.DataAccessLayer;
using MongoDB.Driver;

namespace Garden2Table.DataAccessLayer
{
   public  class DataServiceMongoDb : IDataService
    {
        private List<Stands> _stands;
        private IMongoCollection<Stands> _collection;

        public DataServiceMongoDb()
        {
            Connection();
        }
        /// <summary>
        /// connect to online MongoDb database
        /// </summary>
        /// <returns>true if connected</returns>

        private bool Connection()
        {
            try
            {
                MongoClient dbClient = new MongoClient(MongoDBDataSettings.connectionString);
                IMongoDatabase database = dbClient.GetDatabase(MongoDBDataSettings.databaseName);
                _collection = database.GetCollection<Stands>(MongoDBDataSettings.collectionName);

                _stands = _collection.Find(Builders<Stands>.Filter.Empty).ToList();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// get all widgets
        /// </summary>
        /// <returns>IEnumerable of widgets</returns>
        public IEnumerable<Stands> GetAll()
        {
            return _stands;
        }

        /// <summary>
        /// add a new stands
        /// </summary>
       
        public void Add(Stands stands)
        {
            stands.Id = NextIdNumber();
            _collection.InsertOne(stands);
        }

        /// <summary>
        /// delete a stand
        /// </summary>
        ///  private int NextIdNumber()
        public void Delete(int id)
        {
            Stands standToDelete = _stands.FirstOrDefault(s => s.Id == id);

            if (standToDelete != null)
            {
                var deleteFilter = Builders<Stands>.Filter.Eq("Id", id);
                _collection.DeleteOne(deleteFilter);
            }
        }
        /// <summary>
        /// get a stand by id
        /// </summary>
        public Stands GetById(int id)
        {
            var getFilter = Builders<Stands>.Filter.Eq("Id", id);
            return _collection.Find(getFilter).FirstOrDefault();
        }

        /// <summary>
        /// update a stand
        /// </summary>
     
        public void Update(Stands stands)
        {
            var updateFilter = Builders<Stands>.Filter.Eq("Id", stands.Id);
            var deleteResult = _collection.DeleteOne(updateFilter);
            _collection.InsertOne(stands);
        }
        /// <summary>
        /// get the next highest id number from the list of stands
        /// </summary>
        /// <returns>next id number</returns>
        private int NextIdNumber()
        {
            return _stands.Max(s => s.Id) + 1;
        }

        IEnumerable<Stands> IDataService.GetAll()
    {
        return _stands;
    }

    Stands IDataService.GetById(int id)
    {
        throw new NotImplementedException();
    }

    void IDataService.Add(Stands stands)
    {
        throw new NotImplementedException();
    }

    void IDataService.Update(Stands stands)
    {
        throw new NotImplementedException();
    }
}
}
