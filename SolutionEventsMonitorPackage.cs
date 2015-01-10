using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace Company.SolutionEventsMonitor
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideToolWindow(typeof(MyToolWindow))]
    [Guid(GuidList.guidSolutionEventsMonitorPkgString)]
    public sealed class SolutionEventsMonitorPackage : Package
    {
        private IVsSolution _solutionService;

        private void ShowToolWindow(object sender, EventArgs e)
        {
            ToolWindowPane window = this.FindToolWindow(typeof(MyToolWindow), 0, true);
            if ((null == window) || (null == window.Frame))
            {
                throw new NotSupportedException(Resources.CanNotCreateWindow);
            }
            IVsWindowFrame windowFrame = (IVsWindowFrame)window.Frame;
            ErrorHandler.ThrowOnFailure(windowFrame.Show());
        }


        protected override void Initialize()
        {
            Debug.WriteLine (string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this.ToString()));
            base.Initialize();

            _solutionService = GetService(typeof(SVsSolution)) as IVsSolution;
            if (_solutionService != null)
            {
                Common.Instance.Package = this;
                Common.Instance.Solution = _solutionService;
            }

            OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if ( null != mcs )
            {
                // Create the command for the tool window
                CommandID toolwndCommandID = new CommandID(GuidList.guidSolutionEventsMonitorCmdSet, (int)PkgCmdIDList.cmdidMyTool);
                MenuCommand menuToolWin = new MenuCommand(ShowToolWindow, toolwndCommandID);
                mcs.AddCommand( menuToolWin );
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (_solutionService != null && Common.Instance.SolutionCookie != 0)
            {
                _solutionService.UnadviseSolutionEvents(Common.Instance.SolutionCookie);
            }
        }
    }
}
