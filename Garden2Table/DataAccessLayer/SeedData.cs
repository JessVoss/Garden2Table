using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garden2Table.Models;
using Garden2Table.BusinessLayer;
using System.Collections.ObjectModel;

namespace Garden2Table.DataAccessLayer
{
    public class SeedData: ObservableObject
    {
        public static List<Stands> GetStandsList()
        {
            return new List<Stands>()
            {
                new Stands(1,"Dusty's", "111 billivard Rd", "49807", "yes", new ObservableCollection<Product>(){new Product(){Name = "Zucchini",Family="Cucurbitaceae", Quantity = 10 },new Product(){ Name = "Tomatoes", Family = "Solanaceae", Quantity = 50 }, new Product(){ Name = "Summer Squash", Family = "Cucurbitaceae", Quantity = 5}}),
                new Stands(2,"Normals", "111 Test Rd", "49607", "yes", new ObservableCollection<Product>(){ new Product(){ Name = "Okra", Family = "Malvaceae", Quantity = 7},new Product(){ Name = "Green Beans", Family = "Fabaceae", Quantity = 25},new Product(){ Name = "Watermellon", Family = "Citrullus", Quantity = 4},new Product(){ Name = "Grape Tomatoes", Family = "Solanaceae", Quantity = 100}}),
                new Stands(3,"Dee's", "101 Test Rd", "49607", "no", new ObservableCollection<Product>(){new Product(){ Name = "Spinanch", Family = "Chenopiaceae"},new Product(){ Name = "Collard Greens"},new Product(){ Name = "Cabbage", Family = "Brassicaceae", Quantity = 10},new Product(){ Name = "Broccoli", Family = "Brassicaceae", Quantity = 20}})
            };
        }
    }
}
