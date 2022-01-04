using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityLogger_WPF_UI.MVVM.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        IEventAggregator _events;
        public ShellViewModel(IEventAggregator events)
        {
            _events = events;
            _events.Subscribe(this);
        }
    }
}
