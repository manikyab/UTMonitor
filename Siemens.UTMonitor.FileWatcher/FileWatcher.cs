using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Siemens.UTMonitor.Invoker;
using Siemens.UTMonitor.Driver;
using System.Threading;

namespace Siemens.UTMonitor.FileWatcher
{
    public class FileWatcher
    {
        
        public string Directory { get; set; }
        DataFetcher fetcher;
        ErrorFetcher errorFetcher;
        DLLFilter dLLFilter = new DLLFilter();
        MonitoringSourceControl MonitorSCList;

        public FileWatcher(DataFetcher dataFetcher, string directory,ErrorFetcher errorFetcher,MonitoringSourceControl sourceControl)//FileWatcher Constructor initializing all Delegates
        {
            this.Directory = directory;
            this.fetcher = dataFetcher;
            this.errorFetcher = errorFetcher;
            this.MonitorSCList = sourceControl;
        }

        public void CreateWatcher()// Initializing File Watcher
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = Directory;
            watcher.Filter = "*.dll";
            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = true;
            //Event Handler


            watcher.Changed += watcher_Changed;//Event handler for checking changes in file


            Thread.CurrentThread.Join();
        }

        private void watcher_Changed(object sender, FileSystemEventArgs ev)//Event Handler function for changes in file
        {
            try
            {
                var SCList = MonitorSCList.Invoke();//Getting list of Source Control
                int flag = 0;
                foreach (var item in SCList)//Checking if changed file is in source control
                {
                    if (ev.FullPath.StartsWith(item))
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 1)
                {
                    var result = dLLFilter.FilterDLL(ev.FullPath);//Running filter for valid dll file
                    if (result)
                    {
                        using (var driver = new Driver.Driver())//Executing Driver funvtion for executing test case
                        {
                            Dictionary<string, string> resultData = driver.ExecuteDriver(ev.FullPath, Directory, errorFetcher);
                            fetcher.Invoke(resultData);//Sending test case data back to the UI
                        }
                    }
                }
            }
            catch(Exception e)
            {
                errorFetcher.Invoke(e.Message);
            }
        }
    }
}
