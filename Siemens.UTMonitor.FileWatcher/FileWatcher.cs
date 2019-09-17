using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Siemens.UTMonitor.Invoker;
using Siemens.UTMonitor.Driver;

namespace Siemens.UTMonitor.FileWatcher
{
    public class FileWatcher
    {
        public string Directory { get; set; }
        DataFetcher fetcher;
        ErrorFetcher errorFetcher;
        DLLFilter dLLFilter = new DLLFilter();

        public FileWatcher(DataFetcher dataFetcher, string directory,ErrorFetcher errorFetcher)
        {
            this.Directory = directory;
            this.fetcher = dataFetcher;
            this.errorFetcher = errorFetcher;
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = directory;
            watcher.Filter = "*.dll";
            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = true;
            //Event Handler


            watcher.Changed += watcher_Changed;
        }
        private void watcher_Changed(object sender, FileSystemEventArgs ev)
        {
            try
            {
                var result = dLLFilter.FilterDLL(ev.FullPath);
                if (result)
                {
                    using (var driver = new Driver.Driver())
                    {
                        var resultData=driver.ExecuteDriver(ev.FullPath, Directory);
                        fetcher.Invoke(resultData);
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
