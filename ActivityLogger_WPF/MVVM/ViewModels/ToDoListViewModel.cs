using ActivityLogger_WPF.Core;
using ActivityLogger_WPF.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace ActivityLogger_WPF.MVVM.ViewModels
{
    class ToDoListViewModel : ObservableObject
    {
        public CollectionViewSource ToDoCollectionViewSource;



        public ICollectionView ToDoSourceCollection => ToDoCollectionViewSource.View;





        public ObservableCollection<ToDoModel> ToDoCollection { get; set; } = new ObservableCollection<ToDoModel>();








        private string _textBoxValue = "";

        public string TextBoxValue
        {
            get { return _textBoxValue; }
            set
            {
                _textBoxValue = value;
                OnPropertyChanged("TextBoxValue");
                OnPropertyChanged("IsSubmitButtonEnabled");
            }
        }

        private DateTime _setDueDate = DateTime.Now;

        public DateTime SetDueDate
        {
            get { return _setDueDate; }
            set
            {
                _setDueDate = value;
                OnPropertyChanged("SetDueDate");
                OnPropertyChanged("IsSubmitButtonEnabled");
            }
        }




        public ToDoListViewModel()
        {


            ClickSubmitCommand = new RelayCommand(o =>
            {
                ToDoCollection.Add(new ToDoModel { ToDoValue = TextBoxValue });
            });
        }








        private bool _isSubmitButtonEnabled;

        public bool IsSubmitButtonEnabled
        {
            get 
            { 
                
                if (TextBoxValue.Length > 0 && SetDueDate > DateTime.Now)
                {
                    _isSubmitButtonEnabled = true;
                }
                else
                {
                    _isSubmitButtonEnabled = false;
                }
                return _isSubmitButtonEnabled; 
            }
        }


        // COMMANDS
        public ICommand ClickSubmitCommand { get; set; }
    }
}
