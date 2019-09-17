using System.Collections.Generic;

namespace Siemens.UTMonitor.Invoker
{
    public delegate void DataFetcher(List<string> list);
    public delegate void ErrorFetcher(string error);
}
