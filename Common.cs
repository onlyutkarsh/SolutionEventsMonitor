using System.Collections.ObjectModel;
using Microsoft.VisualStudio.Shell.Interop;

namespace Company.SolutionEventsMonitor
{
    public class Common
    {
        private static Common instance;

        private Common() { }

        public static Common Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Common();
                }
                return instance;
            }
        }

        public IVsSolution Solution { get; set; }

        public SolutionEventsMonitorPackage Package { get; set; }

        public ObservableCollection<string> Messages { get; set; } = new ObservableCollection<string>();
        public uint SolutionCookie { get; set; }
    }
}