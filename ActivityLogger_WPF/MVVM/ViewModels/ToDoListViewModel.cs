using ActivityLogger_WPF.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ActivityLogger_WPF.MVVM.ViewModels
{
    class ToDoListViewModel : ObservableObject
    {

        private string _textBoxValue;

        public string TextBoxValue
        {
            get { return _textBoxValue; }
            set { _textBoxValue = value; }
        }


        public ICommand Submit = new RelayCommand(o =>
        {
            Debug.WriteLine("Submit");
        });
    }
}
