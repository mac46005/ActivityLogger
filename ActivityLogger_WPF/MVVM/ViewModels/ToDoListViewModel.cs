using ActivityLogger_WPF.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
