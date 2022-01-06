using ActivityLogger.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ActivityLogger_WPF_UI.Core.Classes
{
    public class RunCurrentActivity
    {
        DispatcherTimer _timer;
        ActivityModel _currentActivity;

        public RunCurrentActivity()
        {

        }



        public void SetActivity(ActivityModel activityModel)
        {
            _currentActivity = activityModel;
        }



        private void SetTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Tick += new EventHandler(Timer_Tick);
            _timer.Interval = new TimeSpan(
                _currentActivity.WorkInterval.Hour,
                _currentActivity.WorkInterval.Minute,
                _currentActivity.WorkInterval.Second
                );
        }




        private void Timer_Tick(object sender, EventArgs e)
        {

        }





        public void Run() => _timer.Start();
    }
}
