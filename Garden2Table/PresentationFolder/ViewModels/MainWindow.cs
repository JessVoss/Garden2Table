using Garden2Table.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Garden2Table.PresentationFolder.ViewModels
{
    class MainWindow
    {

        public ICommand QuitApplicationCommand
        {
            get { return new RelayCommand(OnQuitApplication); }
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
