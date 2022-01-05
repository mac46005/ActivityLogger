using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ActivityLogger_WPF_UI.MVVM.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
        public ShellView()
        {
            //InitializeComponent();
            //Timer.Tick += new EventHandler(OnLoaded);
            //Timer.Interval = new TimeSpan(0, 0, 1);
            //Timer.Start();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        //private void OnLoaded(object sender, EventArgs e)
        //{
        //    DateTime d;
        //    d = DateTime.Now;
        //    ClockTextBox.Text = d.Hour + ":" + d.Minute + ":" + d.Second;
        //}
    }
}
