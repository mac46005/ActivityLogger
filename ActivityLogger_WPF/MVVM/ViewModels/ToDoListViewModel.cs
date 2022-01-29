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


        #region listprocessing
        /// <summary>
        /// This is in charge filtering the items
        /// </summary>
        private CollectionViewSource ToDoCollectionViewSource;
        private CollectionViewSource CompleteCollectionViewSource;


        /// <summary>
        /// The view will see the filtered list here
        /// </summary>
        public ICollectionView ToDoSourceCollectionView => ToDoCollectionViewSource.View;
        public ICollectionView CompleteSourceCollectionView => CompleteCollectionViewSource.View;

        /// <summary>
        /// This is the collection of all ToDoModel Item
        /// </summary>
        private ObservableCollection<ToDoModel> ToDoCollection { get; set; } = new ObservableCollection<ToDoModel>();

        /// <summary>
        /// Filters ToDo Items and adds to CompleteList if ToDo object IsTaskDone is true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompleteCollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
            ToDoModel _item = e.Item as ToDoModel;
            if (_item.IsTaskDone == true)
            {
                e.Accepted = true;
            }
        }



        /// <summary>
        /// Filters ToDo Item and adds to ToDoList if ToDo object isTaskDone is false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToDoCollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
            ToDoModel _item = e.Item as ToDoModel;
            if (_item.IsTaskDone == false)
            {
                e.Accepted = true;
            }
        }
        #endregion




















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










        // Constructor
        public ToDoListViewModel()
        {
            ToDoCollectionViewSource = new CollectionViewSource { Source = ToDoCollection };
            CompleteCollectionViewSource = new CollectionViewSource { Source = ToDoCollection };
            ToDoCollectionViewSource.Filter += ToDoCollectionViewSource_Filter;
            CompleteCollectionViewSource.Filter += CompleteCollectionViewSource_Filter;




            ClickSubmitCommand = new RelayCommand(o =>
            {
                ToDoCollection.Add(new ToDoModel { ToDoValue = TextBoxValue });
                SubscribeToDoItems();
            });
        }
        // END Constructor












        #region METHODS
        /// <summary>
        /// Subscribes all ToDoItems.TaskIsDoneEvent 
        /// </summary>
        private void SubscribeToDoItems()
        {
            foreach (var item in ToDoCollection)
            {
                item.TaskIsDoneEvent += Item_TaskIsDoneEvent;
            }
        }



        /// <summary>
        /// Should update Lists according to filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Item_TaskIsDoneEvent(object? sender, EventArgs e)
        {
            
            CompleteCollectionViewSource.View.Refresh();
            ToDoCollectionViewSource.View.Refresh();
        }
        #endregion

































        #region COMMANDS
        public ICommand ClickSubmitCommand { get; set; }
        #endregion
    }
}
