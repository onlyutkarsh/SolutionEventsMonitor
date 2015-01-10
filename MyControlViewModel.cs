using System.Collections.ObjectModel;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;

namespace Company.SolutionEventsMonitor
{
    internal class MyControlViewModel : IVsSolutionEvents
    {
        private DelegateCommand _clearCommand;
        public ObservableCollection<string> EventsList { get; set; }

        public DelegateCommand ClearCommand {
            get
            {
                return _clearCommand ?? (_clearCommand = new DelegateCommand(OnClearClick));
            }
        }

        private void OnClearClick(object obj)
        {
            EventsList.Clear();
        }

        public MyControlViewModel()
        {
            uint cookie;
            EventsList = new ObservableCollection<string>();
            Common.Instance.Solution.AdviseSolutionEvents(this, out cookie);
            Common.Instance.SolutionCookie = cookie;
        }

        public int OnAfterOpenProject(IVsHierarchy pHierarchy, int fAdded)
        {
            EventsList.Add("Triggered OnAfterOpenProject");
            return VSConstants.S_OK;
        }

        public int OnQueryCloseProject(IVsHierarchy pHierarchy, int fRemoving, ref int pfCancel)
        {
            EventsList.Add("Triggered OnQueryCloseProject");
            return VSConstants.S_OK;
        }

        public int OnBeforeCloseProject(IVsHierarchy pHierarchy, int fRemoved)
        {
            EventsList.Add("Triggered OnBeforeCloseProject");
            return VSConstants.S_OK;
        }

        public int OnAfterLoadProject(IVsHierarchy pStubHierarchy, IVsHierarchy pRealHierarchy)
        {
            EventsList.Add("Triggered OnAfterLoadProject");
            return VSConstants.S_OK;
        }

        public int OnQueryUnloadProject(IVsHierarchy pRealHierarchy, ref int pfCancel)
        {
            EventsList.Add("Triggered OnQueryUnloadProject");
            return VSConstants.S_OK;
        }

        public int OnBeforeUnloadProject(IVsHierarchy pRealHierarchy, IVsHierarchy pStubHierarchy)
        {
            EventsList.Add("Triggered OnBeforeUnloadProject");
            return VSConstants.S_OK;
        }

        public int OnAfterOpenSolution(object pUnkReserved, int fNewSolution)
        {
            EventsList.Add("Triggered OnAfterOpenSolution");
            return VSConstants.S_OK;
        }

        public int OnQueryCloseSolution(object pUnkReserved, ref int pfCancel)
        {
            EventsList.Add("Triggered OnQueryCloseSolution");
            return VSConstants.S_OK;
        }

        public int OnBeforeCloseSolution(object pUnkReserved)
        {
            EventsList.Add("Triggered OnBeforeCloseSolution");
            return VSConstants.S_OK;
        }

        public int OnAfterCloseSolution(object pUnkReserved)
        {
            EventsList.Add("Triggered OnAfterCloseSolution");
            return VSConstants.S_OK;
        }
    }
}