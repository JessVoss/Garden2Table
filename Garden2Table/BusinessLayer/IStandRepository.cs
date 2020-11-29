using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garden2Table.Models;

namespace Garden2Table.BusinessLayer
{
    public interface IStandRepository
    {
        IEnumerable<Stands> GetAll();
        Stands GetById(int Id);
        void Add(Stands stand);
        void Update(Stands stand);
        void Delete(int id);
    }
}
