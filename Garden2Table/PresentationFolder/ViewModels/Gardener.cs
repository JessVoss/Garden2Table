using Garden2Table.BusinessLayer;
using Garden2Table.Models;
using Garden2Table.PresentationFolder.views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Garden2Table.PresentationFolder.ViewModels
{
    class Gardener  :  ObservableObject
    {
        #region ENUMS
        private enum OperationStatus
        {
            NONE,
            VIEW,
            ADD,
            EDIT,
            DELETE

        }
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
        public ICommand SaveStandCommand
        {
            get { return new RelayCommand(OnSave); }
        }
        public ICommand CancelStandCommand
        {
            get { return new RelayCommand(OnCancel); }
        }
        public ICommand HomeButtonCommand
        {
            get { return new RelayCommand(OnHomeButton); }
        }
        #endregion

        #region FIELDS
        private OperationStatus _operationStatus = OperationStatus.NONE;
        private ObservableCollection<string> _product;
        private ObservableCollection<Stands> _stand;
        private Stands _detailedViewStands;
        private Stands _selectedStand;
        private string _searchText;
        private bool _isEditingAdding = false;
        private bool _showAddEditDeleteButtons = true;
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

        public Stands DetailedViewStands
        {
            get { return _detailedViewStands; }
            set { _detailedViewStands = value; }
        }
        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; }
        }
        public bool IsEditingAdding
        {
            get { return _isEditingAdding; }
            set { _isEditingAdding = value; }
        }

        public bool ShowAddEditDeleteButtons
        {
            get { return _showAddEditDeleteButtons; }
            set { _showAddEditDeleteButtons = value; }
        }
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
            if (_selectedStand != null)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show($"Are you sure you want to delete {_selectedStand.Name}?", "Delete epsiode", System.Windows.MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    //
                    //deletes from persistence
                    //
                   
                    //
                    //removes stand from list
                    //

                    _stand.Remove(_selectedStand);
                    //
                    //set selected stand to first on list
                    //
                    //SelectedStand = _stand[0];
                }
                else
                {
                    result = MessageBoxResult.Cancel;
                    _operationStatus = OperationStatus.NONE;
                }
            }
        }
        private void OnAdd()
        {
            ResetDetailedViewStands();
            IsEditingAdding = true;
            ShowAddEditDeleteButtons = false;
            _operationStatus = OperationStatus.ADD;
        }
        private void OnEdit()
        {
            if (_selectedStand != null)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show($"Are you sure you want to edit {_selectedStand.Name}?", "Edit epsiode", System.Windows.MessageBoxButton.OKCancel);
                switch (result)
                {
                    case MessageBoxResult.OK:
                        _operationStatus = OperationStatus.EDIT;
                        IsEditingAdding = true;
                        ShowAddEditDeleteButtons = false;
                        break;

                    case MessageBoxResult.Cancel:
                        _operationStatus = OperationStatus.NONE;
                        break;
                    default:
                        break;
                }
            }
        }
        private void OnSearch()
        {

            _stand = new ObservableCollection<Stands>(_stand.Where(x => x.Name.ToLower().Contains(_searchText)));
        }
        private void UpdateDetailedViewStandToSelected()
        {
            Stands tempStand = new Stands();
            tempStand.Id = _selectedStand.Id;
            tempStand.Name = _selectedStand.Name;
            tempStand.StreetAddress = _selectedStand.StreetAddress;

            
        }
        private void ResetDetailedViewStands()
        {
            DetailedViewStands = new Stands();
            
        }
        private void OnSave()
        {
            switch(_operationStatus)
            {
                case OperationStatus.ADD:
                    if(_detailedViewStands != null)
                    {
                        //
                        // Adding Stand to persistence
                        //

                        //
                        // add stand to list
                        //
                        _stand.Add(DetailedViewStands);
                        //
                        // seting selected stand as new stand
                        //
                        SelectedStand = DetailedViewStands;
                    }
                    break;
                case OperationStatus.EDIT:
                    Stands standToUpdate = _stand.FirstOrDefault(x => x.Id == SelectedStand.Id);
                    if (standToUpdate != null)
                    {
                        Stands updatedStand = DetailedViewStands;
                        //
                        // update stand in persistance
                        //

                        //
                        // update stand in list
                        //
                        _stand.Remove(standToUpdate);
                        _stand.Add(updatedStand);
                        //
                        // setting selected stand as property
                        //
                        SelectedStand = updatedStand;
                    }
                    break;
                default:
                    break;
            }
                    IsEditingAdding = false;
                    ShowAddEditDeleteButtons = true;
                    _operationStatus = OperationStatus.NONE;
           
        }
        private void OnCancel()
        {
            {
                if (_operationStatus == OperationStatus.ADD)
                {
                    SelectedStand = _stand[0];
                }
                _operationStatus = OperationStatus.NONE;
                IsEditingAdding = false;
                ShowAddEditDeleteButtons = true;
            }
        }
        private void OnHomeButton()
        {
            Window homeWindow = new Window();
            homeWindow.Show();
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
