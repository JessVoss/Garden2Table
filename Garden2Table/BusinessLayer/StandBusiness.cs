using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garden2Table.Models;
using Garden2Table.DataAccessLayer;

namespace Garden2Table.BusinessLayer
{
    class StandBusiness
    {
        public FileMessage FileStatus { get; set; }

        public StandBusiness()
        {
            //MongoDbUtilities.WriteSeeDataToDatabase();
        }
        ///
        ///  retrieve a stand using the repository
        ///  
        private Stands GetStand(int id)
        {
            Stands stand = null;
            FileStatus = FileMessage.None;
           try
            {
                using (StandRepository sRepository = new StandRepository())
                {
                    stand = sRepository.GetById(id);
                };

                if (stand != null)
                {
                    FileStatus = FileMessage.Complete;
                }
                else
                {
                    FileStatus = FileMessage.RecordNotFound;
                }
            }
            catch (Exception)
            {
                FileStatus = FileMessage.FileAccessError;
            }

            return stand;
        }
   
    /// <summary>
    /// 
    /// </summary>
    /// <returns>Stand</returns>
        private List<Stands> GetAllStands()
         {
        List<Stands> stand = null;
        FileStatus = FileMessage.None;
        try
        {
            using (StandRepository sRepository = new StandRepository())
            {
                    stand = sRepository.GetAll() as List<Stands>;
            };

            if (stand != null)
            {
                FileStatus = FileMessage.Complete;
            }
            else
            {
                FileStatus = FileMessage.RecordNotFound;
            }
        }
        catch (Exception)
        {
            FileStatus = FileMessage.FileAccessError;
        }

        return stand;
         }

    /// <summary>
    /// provide list of all stands
    /// </summary>
    /// <returns>List of Stand</returns>
        public List<Stands> AllStands()
        {
            return SeedData.GetStandsList();

            // return GetAllStands() as List<Stands>;
        }

        /// <summary>
        /// retrieve a stand by id
        /// </summary>
        /// <returns>Stand</returns>
        /// 
        public Stands StandById(int id)
        {
            return GetStand(id);
        }

        /// <summary>
        /// add a new stand
        /// </summary>
        /// <returns>Stand</returns>
        /// 
        public void AddStand(Stands stand)
        {
            try
            {
                if (stand != null)
                {
                    using (StandRepository sRepository = new StandRepository())
                    {
                        sRepository.Add(stand);
                    };

                    FileStatus = FileMessage.Complete;
                }
            }
            catch (Exception)
            {
                FileStatus = FileMessage.FileAccessError;
            }
        }

        /// <summary>
        /// update a stand
        /// </summary>
        /// <returns>Stand</returns>
        /// 
        public void UpdateStand(Stands updatedStand)
        {
            try
            {
                if (GetStand(updatedStand.Id) != null)
                {
                    using (StandRepository repo = new StandRepository())
                    {
                        repo.Update(updatedStand);
                    }

                    FileStatus = FileMessage.Complete;
                }
                else
                {
                    FileStatus = FileMessage.RecordNotFound;
                }
            }
            catch (Exception)
            {
                FileStatus = FileMessage.FileAccessError;
            }
        }
        /// <summary>
        /// Delete a widget by id
        /// </summary>
        /// <returns>Stand</returns>
        /// 
        public void DeleteStand(int Id)
        {
            try
            {
                if (GetStand(Id) != null)
                {
                    using(StandRepository sRepository = new StandRepository())
                    {
                        sRepository.Delete(Id);

                        FileStatus = FileMessage.Complete;
                    }
                }
                else
                {
                    FileStatus = FileMessage.RecordNotFound;
                }
            }
            catch (Exception)
            {
                FileStatus = FileMessage.FileAccessError;
            }
        }
    }
}
