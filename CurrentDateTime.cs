using System;
using System.ComponentModel;
using System.Timers;

namespace Company.SolutionEventsMonitor
{
    public class CurrentDateTime : INotifyPropertyChanged
    {
        private Timer _timer;
        public event PropertyChangedEventHandler PropertyChanged;

        public CurrentDateTime()
        {
            _timer = new Timer(1000);
            _timer.Elapsed += delegate
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Now"));
            };
        }

        public DateTime Now { get { return DateTime.Now; } }
    }
}
