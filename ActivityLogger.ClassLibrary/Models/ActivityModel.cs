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

        public int WorkInterval_ID { get; set; }
        public TimeModel WorkInterval { get; set; }


        public int BreakInterval_ID { get; set; }
        public TimeModel BreakInterval { get; set; }


        public string Description { get; set; }

        public override string ToString() => ActivityName;
    }
}
