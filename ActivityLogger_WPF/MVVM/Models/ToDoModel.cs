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
        public event EventHandler<TaskDoneEventHandler> TaskIsDoneEvent;

        public string ToDoValue { get; set; }

        public DateTime Due { get; set; }


        public ToDoModel()
        {
        }


        private bool _isTaskDone = false;
        public bool IsTaskDone
        {
            get { return _isTaskDone; }
            set 
            { 
                _isTaskDone = value;
                
                OnPropertyChanged("IsTaskDon");

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
