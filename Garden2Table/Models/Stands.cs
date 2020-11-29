using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garden2Table.BusinessLayer;


namespace Garden2Table.Models
{
    public class Stands : ObservableObject
    {
        
        private string _name;
        private string _streetAddress;
        private string _zipCode;
        private string _donationRequired;
        private ObservableCollection<Product> _products;
        private string _reviews;
        public int Id { get; set; }
        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string StreetAddress
        {
            get { return _streetAddress; }
            set { _streetAddress = value; }
        }
        public string ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; }
        }
        public string DonationRequired
        {
            get { return _donationRequired; }
            set { _donationRequired = value; }
        }
        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }
        private string Reviews
        {
            get { return _reviews; }
            set { _reviews = value; }
        }

        public Stands()
        {

        }

        public Stands(int id, string name, string address, string zip, string donationReq, ObservableCollection<Product>products)
        {
            Id = id;
            Name = name;
            StreetAddress = address;
            ZipCode = zip;
            DonationRequired = donationReq;
            Products = products;
        }
    }
}