using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garden2Table.Models;
using Garden2Table.DataAccessLayer;


namespace Garden2Table.BusinessLayer
{
    /// <summary>
    /// Repository for CRUD
    /// Note: the _dataService object is instantiated with DataConfig class
    /// </summary>
    class StandRepository : IStandRepository, IDisposable
    {
        private IDataService _dataService;
        List<Stands> _stand;

        ///<summary>
        /// Data Service read a list of all stands
        ///</summary>

        public StandRepository()
        {
            //_dataService = new DataServiceMongoDb();

            try
            {
                _stand = _dataService.GetAll() as List<Stands>;
            }
            catch (Exception e)
            {
                string message = e.Message;
                throw;
            }
        }
        /// <summary>
        /// retrieve all stands
        /// </summary>
        /// <returns>all stands</returns>
        public IEnumerable<Stands> GetAll()
        {
            return _stand;
        }
        /// <summary>
        /// retrieve stands by Id
        /// </summary>
        /// <returns>stands by Id</returns>
        public Stands GetById(int Id)
        {
            return _stand.FirstOrDefault(s => s.Id == Id);
        }
        /// <summary>
        /// add a new stand
        /// </summary>
        /// <returns> </returns>
        public void Add(Stands stand)
        {
            try
            {
                _dataService.Add(stand);
            }
            catch (Exception e)
            {
                string message = e.Message;
                throw;
            }
        }
        /// <summary>
        /// delete a widget by id
        /// </summary>
        /// <returns> </returns>
      public void Delete(int id)
        {
            try
            {
                _dataService.Delete(id);
            }
            catch (Exception e)
            {
                string message = e.Message;
                throw;
            }
        }

        /// <summary>
        /// update a widget by name
        /// </summary>
        /// <returns> </returns>
        public void Update(Stands stand)
        {
            try
            {
                _dataService.Update(stand);
            }
            catch (Exception e)
            {
                string message = e.Message;
                throw;
            }
        }
        /// <summary>
        /// required if class will be use in a 'using" block
        /// </summary>
        public void Dispose()
        {
            _dataService = null;
            _stand = null;
        }
    }
}