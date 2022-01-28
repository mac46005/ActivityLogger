using ActivityLogger_WPF.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityLogger_WPF.MVVM.Models
{
    public class ToDoModel : ObservableObject
    {



        public string ToDoValue { get; set; }

        public DateTime Due { get; set; }





        private bool _isTaskDone = false;
        public bool IsTaskDone
        {
            get { return _isTaskDone; }
            set { _isTaskDone = value; }
        }

    }
}
