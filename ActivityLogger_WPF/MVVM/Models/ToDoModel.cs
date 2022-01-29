using ActivityLogger_WPF.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ActivityLogger_WPF.MVVM.Models
{
    public class ToDoModel : ObservableObject
    {
        private DateTime _dateCompleted;
        private bool _isOverDue;
        private bool _isTaskDone = false;



        /// <summary>
        /// This describes the task to complete
        /// </summary>
        public string ToDoValue { get; set; }

        /// <summary>
        /// The date this task need to be complete
        /// </summary>
        public DateTime Due { get; set; }

        /// <summary>
        /// When the task is complete this records when the 
        /// task has been completed
        /// </summary>
        public DateTime DateCompleted
        {
            get { return _dateCompleted; }
            set { _dateCompleted = value; }
        }



        /// <summary>
        /// Marks the object as completed or not completed
        /// </summary>
        public bool IsTaskDone
        {
            get { return _isTaskDone; }
            set
            {
                _isTaskDone = value;

                OnPropertyChanged("IsTaskDone");

                if (value == true)
                {
                    EventHandler<TaskDoneEventHandler> handler = TaskIsDoneEvent;

                    if (handler != null)
                    {
                        handler(this, new TaskDoneEventHandler(this));
                    }
                }
            }
        }


        /// <summary>
        /// Checks to see if the ToDo objects Due is less than the current time 
        /// is it is not and the task is not complete is will return true.
        /// </summary>
        public bool IsOverDue
        {
            get { return _isOverDue; }
            private set
            {
                if (DateTime.Now > Due && IsTaskDone != true)
                {
                    _isOverDue = true;
                }
                else
                {
                    _isOverDue = false;
                }
                OnPropertyChanged("IsOverDue");
            }
        }













        #region Contructors
        public ToDoModel()
        {
        }

        public ToDoModel(string toDoValue, DateTime due)
        {
            ToDoValue = toDoValue;
            Due = due;
        }
        #endregion



















        public event EventHandler<TaskDoneEventHandler> TaskIsDoneEvent;
    }


    public class TaskDoneEventHandler : EventArgs
    {
        public TaskDoneEventHandler(ToDoModel toDoModel)
        {
            ToDoModel = toDoModel;
        }
        ToDoModel ToDoModel { get; set; } = null;
    }
}
