using System.Collections.Generic;

namespace Siemens.UTMonitor.Invoker
{
    public delegate void DataFetcher(Dictionary<string, string> list);
    public delegate void ErrorFetcher(string error);
    public delegate List<string> MonitoringSourceControl();
}
