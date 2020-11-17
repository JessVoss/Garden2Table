using Garden2Table.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Garden2Table.PresentationFolder.ViewModels
{
    class Gardener
    {
        #region ENUMS

        #endregion

        #region COMMANDS
        public ICommand QuitApplicationCommand
        {
            get { return new RelayCommand(OnQuitApplication); }
        }
        public ICommand SearchButtonCommand
        {
            get { return new RelayCommand(OnSearch); }
        }
        public ICommand EditStandCommand
        {
            get { return new RelayCommand(OnEdit); }
        }
        public ICommand AddStandCommand
        {
            get { return new RelayCommand(OnAdd); }
        }
        public ICommand DeleteStandCommand
        {
            get { return new RelayCommand(OnDelete); }
        }
        public ICommand AddProductCommand
        {
            get { return new RelayCommand(AddProduct); }
        }
        public ICommand Reset
        {
            get { return new RelayCommand(OnReset); }
        }
        #endregion

        #region FIELDS

        #endregion

        #region PROPERTIES

        #endregion

        #region METHODS
        private void OnReset()
        {

        }
        private void AddProduct()
        {

        }
        private void OnDelete()
        {

        }
        private void OnAdd()
        {

        }
        private void OnEdit()
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
        #endregion
    }
}
