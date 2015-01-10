// Guids.cs
// MUST match guids.h

using System;

namespace Company.SolutionEventsMonitor
{
    static class GuidList
    {
        public const string guidSolutionEventsMonitorPkgString = "a704fa60-b3e0-4b84-bde6-2405e8ce480b";
        public const string guidSolutionEventsMonitorCmdSetString = "a024f012-846f-41ab-81a8-cfa28e6fc622";
        public const string guidToolWindowPersistanceString = "0f4a2239-ee7b-4397-a8de-14c8bf07d13b";

        public static readonly Guid guidSolutionEventsMonitorCmdSet = new Guid(guidSolutionEventsMonitorCmdSetString);
    };
}