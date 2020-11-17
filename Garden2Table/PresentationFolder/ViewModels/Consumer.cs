using Garden2Table.BusinessLayer;
using Garden2Table.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Garden2Table.PresentationFolder.ViewModels
{
    class Consumer: ObservableObject
    {
        #region COMMANDS
        public ICommand QuitApplicationCommand
        {
            get { return new RelayCommand(OnQuitApplication); }
        }
        public ICommand ButtonSearchCommand
        {
            get { return new RelayCommand(OnSearch); }
        }
        public ICommand FilterListCommand
        {
            get { return new RelayCommand(OnFilter); }
        }
        public ICommand ResetCommnd
        {
            get { return new RelayCommand(OnReset); }
        }
        #endregion

        #region FIELDS
        private ObservableCollection<string> _product;
        private ObservableCollection<Stands> _stand;
        private Stands _selectedStand;
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
        #endregion

        private void OnReset()
        {

        }
        private void OnFilter()
        {

        }
        private void OnSearch()
        {

        }
        private void OnQuitApplication()
        {
            //
            //  house keeping method 
            //
            System.Environment.Exit(1);
            // Application.Current.Shutdown();
        }
    }
}
