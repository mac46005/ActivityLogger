using ActivityLogger_WPF.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityLogger_WPF.MVVM.ViewModels
{
    class MainViewModel : ObservableObject
    {
        private object _selectedViewModel;

        public object SelectedViewModel
        {
            get { return _selectedViewModel; }
            set 
            {
                _selectedViewModel = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            SelectedViewModel = new ToDoListViewModel();

            // The SendCommand
            //SendCommand = new RelayCommand(o =>
            //{
            //    Messages.Add(new MessageModel
            //    {
            //        Message = Message,
            //        FirstMessage = false
            //    });

            //    Message = "";
            //});
        }
    }
}
