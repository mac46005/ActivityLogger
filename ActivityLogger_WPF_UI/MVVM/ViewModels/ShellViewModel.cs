using ActivityLogger_WPF_UI.Core.Classes;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ActivityLogger_WPF_UI.MVVM.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public static RunCurrentActivity RunCurrentActivity = new RunCurrentActivity();
        IEventAggregator _events;
        public ShellViewModel(IEventAggregator events)
        {
            _events = events;
            _events.Subscribe(this);

        }
        protected override void OnViewLoaded(object view)
        {





        }       


        private void TickTheClock(object sender,EventArgs e)
        {
            DateTime d;
            d = DateTime.Now;
            ClockTextBox = $"{d.Hour} : {d.Minute} : {d.Second}";
        }

        private string _cockTime;

        public string ClockTextBox
        {
            get { return _cockTime; }
            set 
            { 
                _cockTime = value;
                NotifyOfPropertyChange(() => ClockTextBox);
            }
        }











































    }
}
