using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Siemens.UTMonitor.FileWatcher
{
    public class FileWatcher
    {
        public string directory { get; set; }
        public string fileName { get; set; }
        public void FileWatching()
        {


            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = directory;
            watcher.Filter = "*.dll";
            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = true;

            //Event Handler


            watcher.Changed += watcher_Changed;
        }
        private void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            //Console.WriteLine($"File:{e.FullPath} changed at {DateTime.Now.ToLocalTime()}");

            if (e.Name != fileName)
            {
                var data = e.FullPath.Split('\\');
                var len = data.Length;
                var dllName = data[len - 1];
                var binFolder = data[len - 3];
                var nameSpace = data[len - 4];
                var location = string.Join("\\", data.Take(len - 1));
                if (binFolder == "bin" && dllName.StartsWith(nameSpace))
                {
                    var result=UT_Search.GetTestFile(directory, nameSpace, location);
                    if (result)
                    {
                        fileName = null;
                    }
                    fileName = e.Name;

                }
            }
        }
    }
}
