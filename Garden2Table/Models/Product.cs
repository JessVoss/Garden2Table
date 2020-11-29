using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Garden2Table.BusinessLayer;

namespace Garden2Table.Models
{
    public class Product : ObservableObject
    {
        public string Name { get; set; }

        public string Family { get; set; }

        public int Quantity { get; set; }

    }
}
