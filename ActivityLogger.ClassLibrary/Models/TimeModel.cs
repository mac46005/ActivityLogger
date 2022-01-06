using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityLogger.ClassLibrary.Models
{
    public class TimeModel
    {
        public int ID { get; set; }

        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }

        public TimeModel()
        {

        }
        public TimeModel(int hour,int minute,int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }
    }
}
