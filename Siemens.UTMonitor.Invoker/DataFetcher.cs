using System.Collections.Generic;

namespace Siemens.UTMonitor.Invoker
{
    public delegate void DataFetcher(Dictionary<string, string> list); //Delegate for getting data from XML to UI async

    public delegate void ErrorFetcher(string error); //Delegate for showing error to user

    public delegate List<string> MonitoringSourceControl(); //Delegate for getting list of Source Control
}
