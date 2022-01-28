using ActivityLogger_WPF.Core;
using ActivityLogger_WPF.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ActivityLogger_WPF.MVVM.ViewModels
{
    class ToDoListViewModel : ObservableObject
    {

        public ObservableCollection<ToDoModel> ToDoCollection { get; set; } = new ObservableCollection<ToDoModel>();




        private string _textBoxValue;

        public string TextBoxValue
        {
            get { return _textBoxValue; }
            set { _textBoxValue = value; }
        }
        public ToDoListViewModel()
        {



            ClickSubmitCommand = new RelayCommand(o =>
            {
                ToDoCollection.Add(new ToDoModel { ToDoValue = TextBoxValue });
            });
        }




        public ICommand ClickSubmitCommand { get; set; }
    }
}
