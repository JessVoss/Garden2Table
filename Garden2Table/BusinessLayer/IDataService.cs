using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garden2Table.Models;

namespace Garden2Table.BusinessLayer
{
    public interface IDataService
    {
        IEnumerable<Stands> GetAll();
        Stands GetById(int id);
        void Add(Stands products);
        void Update(Stands products);
        void Delete(int id);
    }
}
