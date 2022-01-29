using ActivityLogger_WPF.Core;
using ActivityLogger_WPF.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ActivityLogger_WPF.MVVM.ViewModels
{
    public class AddEditToDoViewModel : ObservableObject
    {


        #region PUBLIC PROPERTIES


        private string _hourString;

        public string Hour
        {
            get { return _hourString; }
            set
            {
                if (int.TryParse(value, out _hour) == true)
                {

                    int h = int.Parse(value);
                    if (h <= 1 || h >= 12)
                    {
                        MessageBox.Show("Please input an integer that is 1 - 12");
                    }
                    else
                    {
                         _hour = h;
                        _hourString = value;
                    }

                }
                else
                {
                    MessageBox.Show("Please input a whole integer");
                }

                OnPropertyChanged("Hour");
            }
        }
        private string _minuteString;

        public string Minute
        {
            get { return _minuteString; }
            set
            {
                if (int.TryParse(value, out _minute))
                {
                    int m = int.Parse(value);
                    if (m <= 1 || m >= 59)
                    {
                        MessageBox.Show("Please input an integer that is 1 - 12");
                    }
                    else
                    {
                        _hour = m;
                        _minuteString = value;
                    }
                }
                else
                {
                    MessageBox.Show("Please input a whole integer");
                }

                OnPropertyChanged("Minute");
            }
        }

        private int _hour = 0;
        private int _minute = 0;



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
















        #region CONSTRUCTOR
        public AddEditToDoViewModel()
        {
            ClickSubmitCommand = new RelayCommand(o =>
            {
                EventHandler<ToDoModel> handler = SubmitEvent;

                // Create new DateTime object



                ToDoModel toDoModel = new ToDoModel(TextBoxValue, SetDueDate);



                TextBoxValue = "";


                handler?.Invoke(this, toDoModel);
            });
        }
        #endregion













        #region METHODS
        public void ResetTextBoxes()
        {
            TextBoxValue = "";
        }



        #endregion











        #region COMMANDS
        public ICommand ClickSubmitCommand { get; set; }
        #endregion






        public event EventHandler<ToDoModel> SubmitEvent;
    }
}
