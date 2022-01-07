using ActivityLogger_WPF_UI.Core.Classes;
using ActivityLogger.ClassLibrary.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Collections.ObjectModel;

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
            



            ActivateItem(IoC.Get<CurrentActivityViewModel>());
        }

        /// <summary>
        /// In the future...probably sooner implement a class to have default option of activity
        /// Like idle....
        /// </summary>
        /// <param name="view"></param>
        protected override void OnViewLoaded(object view)
        {

            ListOfActivities = new ObservableCollection<ActivityModel>()
            {
                new ActivityModel{ ID = 1,ActivityName = "test",WorkInterval = new TimeModel{Hour = 1,Minute = 2,Second = 3},Description = "Test data yo"}
            };



        }




        private ObservableCollection<ActivityModel> _listOfActivities;

        public ObservableCollection<ActivityModel> ListOfActivities
        {
            get { return _listOfActivities; }
            set 
            {
                _listOfActivities = value;
                NotifyOfPropertyChange(() => ListOfActivities);
            }
        }





        private ActivityModel _selectedActivity;

        public ActivityModel SelectedActivity
        {
            get { return _selectedActivity; }
            set 
            {
                _selectedActivity = value;
                NotifyOfPropertyChange(() => SelectedActivity);
            }
        }












































    }
}
