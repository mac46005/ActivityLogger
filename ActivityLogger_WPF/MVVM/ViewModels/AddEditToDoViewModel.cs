using ActivityLogger_WPF.Core;
using ActivityLogger_WPF.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ActivityLogger_WPF.MVVM.ViewModels
{
    public class AddEditToDoViewModel : ObservableObject
    {


        #region PUBLIC PROPERTIES

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

        /// <summary>
        /// Enables and disables Submit button if TextboxValue is not empty and SetDueDate is more than today
        /// </summary>
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

        #endregion












        public AddEditToDoViewModel()
        {
            ClickSubmitCommand = new RelayCommand(o =>
            {
                EventHandler<ToDoModel> handler = SubmitEvent;

                ToDoModel toDoModel = new ToDoModel(TextBoxValue, SetDueDate);
                TextBoxValue = "";


                handler?.Invoke(this, toDoModel);
            });
        }
        #region METHODS
        public void ResetTextBoxes()
        {

        }
        #endregion


        #region COMMANDS
        public ICommand ClickSubmitCommand { get; set; }
        #endregion

        public event EventHandler<ToDoModel> SubmitEvent;

    }
}
