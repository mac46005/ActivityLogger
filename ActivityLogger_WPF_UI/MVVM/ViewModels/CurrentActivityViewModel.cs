using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ActivityLogger_WPF_UI.MVVM.ViewModels
{
    public class CurrentActivityViewModel : Screen
    {
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer workTimer = new DispatcherTimer();
        DispatcherTimer breakTimer = new DispatcherTimer();







        public CurrentActivityViewModel()
        {
            timer.Tick += Timer_Tick;
            workTimer.Tick += WorkTimer_Tick;
            breakTimer.Tick += BreakTimer_Tick;
        }

        private void BreakTimer_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void WorkTimer_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }   





        private int _elapsedTime;
        public int ElapsedTime 
        {
            get { return _elapsedTime; }
            set
            {

            } 
        }





    }
}
