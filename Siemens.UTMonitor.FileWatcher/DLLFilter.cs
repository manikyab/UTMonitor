using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siemens.UTMonitor.FileWatcher
{
    public class DLLFilter
    {
        public string FileName { get; set; }

        public bool FilterDLL(string FileFullPath)//Checking if DLL meet all condition for executing the Test Cases
        {
            var returnvalue = false;
            var data = FileFullPath.Split('\\');
            var len = data.Length;
            var dllName = data[len - 1];
            var binFolder = data[len - 3];
            var projectName = data[len - 4];
            var projectLocation = string.Join("\\", data.Take(len - 1));

            if (dllName != FileName)
            {
                
                if (binFolder == "bin" && dllName.StartsWith(projectName))
                {
                    if (projectName.EndsWith("Test"))
                    {
                        returnvalue = false;
                    }
                    else
                    {
                        returnvalue = true;
                    }
                }
            }
            FileName = dllName;

            return returnvalue;
        }
    }
}
