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
        private ManualResetEvent resetEvent = new ManualResetEvent(false);

        public ManualResetEvent ManualReset { get { return resetEvent; } }
        public string Directory { get; set; }
        DataFetcher fetcher;
        ErrorFetcher errorFetcher;
        DLLFilter dLLFilter = new DLLFilter();

        public FileWatcher(DataFetcher dataFetcher, string directory,ErrorFetcher errorFetcher)
        {
            this.Directory = directory;
            this.fetcher = dataFetcher;
            this.errorFetcher = errorFetcher;
        }

        public void CreateWatcher()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = Directory;
            watcher.Filter = "*.dll";
            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = true;
            //Event Handler


            watcher.Changed += watcher_Changed;

            //resetEvent.WaitOne();

            Thread.CurrentThread.Join();
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
                        Dictionary<string, string> resultData =driver.ExecuteDriver(ev.FullPath, Directory,errorFetcher);
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
