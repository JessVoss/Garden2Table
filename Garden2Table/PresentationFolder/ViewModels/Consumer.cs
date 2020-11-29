using Garden2Table.BusinessLayer;
using Garden2Table.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;

namespace Garden2Table.PresentationFolder.ViewModels
{
    class Consumer: ObservableObject
    {
        #region COMMANDS
        public ICommand QuitApplicationCommand
        {
            get { return new RelayCommand(OnQuitApplication); }
        }
        public ICommand HomeCommand
        {
            get { return new RelayCommand(OnGoHome); }
        }
        public ICommand ButtonSearchCommand
        {
            get { return new RelayCommand(new Action<object>(OnSearch)); }
        }
        public ICommand FilterListCommand
        {
            get { return new RelayCommand(OnFilter); }
        }
        public ICommand ResetCommnd
        {
            get { return new RelayCommand(OnReset); }
        }
        public ICommand SortStandsListCommand
        {
            get { return new RelayCommand(new Action<object>(OnSort)); }
        }
        #endregion

        #region FIELDS
        private ObservableCollection<string> _product;
        private ObservableCollection<Stands> _stand;
        private Stands _selectedStand;
        private string _searchText;
        private string _sortType;
        private string _searchType;
        #endregion

        #region PROPERTIES
        public ObservableCollection<string> Product
        {
            get { return _product; }
            set { _product = value; }
        }
        public ObservableCollection<Stands> Stand
        {
            get { return _stand; }
            set { _stand = value; }
        }

        public Stands SelectedStand
        {
            get { return _selectedStand; }
            set { _selectedStand = value; }
        }

        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; }
        }
        public string SortType
        {
            get { return _sortType; }
            set { _sortType = value; }
        }
        public string SearchType
        {
            get { return _searchType; }
            set { _searchType = value; }
        }
        #endregion

        #region METHOD
        public Consumer()
        {
           // Stand = new ObservableCollection<Stands>(_stand)
        }
        private void OnReset()
        {
            SearchText = "";

        }
        private void OnFilter()
        {

        }
        private void OnSearch(Object parameter)
        {
            string searchType = parameter.ToString();
            switch (searchType)
            {
                case "Stand":
                    Stand = new ObservableCollection<Stands>(_stand.Where(x => x.Name.ToLower().Contains(_searchText)));
                    break;
                case "ZipCode":
                   Stand = new ObservableCollection<Stands>(_stand.Where(x => x.ZipCode.ToLower().Contains(_searchText)));
                    break;
                case "Product":
                  // Stand = new ObservableCollection<Product>(_products.Where(x => x    .ToLower().Contains(_searchText)));
                    break;
                default:

                    break;

            }
        }
        private void OnSort(Object parameter)
        {
            string sortType = parameter.ToString();
            switch (sortType)
            {
                case "Stand":
                    Stand = new ObservableCollection<Stands>(Stand.OrderBy(x => x.Id));
                    break;
                case "ZipCode":
                   Stand = new ObservableCollection<Stands>(Stand.OrderBy(x=> x.ZipCode));
                    break;
                default:

                    break;

            }
        }
        private void OnQuitApplication()
        {
            //
            //  house keeping method 
            //
            System.Environment.Exit(1);
            // Application.Current.Shutdown();
        }
        private void OnGoHome()
        {
            Window homeWindow = new Window();
            homeWindow.Show();
        }
        #endregion
    }
}
