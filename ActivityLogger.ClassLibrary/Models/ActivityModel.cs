using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityLogger.ClassLibrary.Models
{
    public class ActivityModel
    {
        public int ID { get; set; }
        public string ActivityName { get; set; }
        public int Interval_ID { get; set; }
        public TimeModel Interval { get; set; }
        public string Note { get; set; }

        public override string ToString() => ActivityName;
    }
}
