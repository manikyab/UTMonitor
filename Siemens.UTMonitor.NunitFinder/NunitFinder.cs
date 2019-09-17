using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siemens.UTMonitor.NunitFinder
{
    public class NunitFinder:IDisposable
    {
        public void Dispose() { }

        public string NUnitFinder(string directory, string projectName, string dll_location)
        {
            string returnValue = null;
            try
            {
                List<string> files = new List<string>();
                files.AddRange(Directory.GetFiles(directory, projectName + "Test.dll", SearchOption.AllDirectories));
                var dest = files[0].Split('\\');
                var destination = string.Join("\\", dest.Take((dest.Length) - 1));

                returnValue = destination;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Data);
            }
            return returnValue;
        }

        
    }
}
