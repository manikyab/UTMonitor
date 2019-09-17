using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siemens.UTMonitor.Invoker;


namespace Siemens.UTMonitor.Driver
{
    public class Driver:IDisposable
    {
        public void Dispose() { }

        public List<string> ExecuteDriver(string projectDLLPath, string directory)
        {
            List<string> result = null;
            var pathSplit = projectDLLPath.Split('\\');
            var projectLocation = string.Join("\\", pathSplit.Take((pathSplit.Length) - 1));
            var projectName = pathSplit[pathSplit.Length - 4];
            var testLocation = GetNunitLocation(projectName, projectLocation, directory);

            RunNunitTest(testLocation, projectLocation, projectName);

            result=GetResult(testLocation);
            return result;
        }
        
        private string GetNunitLocation(string projectName,string sourceLocation,string directory)
        {
           string returnValue = null;
            using (var nunitfinder = new NunitFinder.NunitFinder())
            {
                returnValue = nunitfinder.NUnitFinder(directory, projectName, sourceLocation);
            }
            return returnValue;
        }
        private void RunNunitTest(string testLocation,string projectLocation,string projectName)
        {
            using (var runNunit=new RunNUnit.RunNUnit())
            {
                runNunit.RunNunit(testLocation, projectLocation, projectName);
            }
        }

        private List<string> GetResult(string ResultLocation)
        {
            List < string > result = null;
            using (var XMLparse=new XMLParser.XMLParser())
            {
                result = XMLparse.ResultDisplay(ResultLocation);
            }
            return result;
        }
    }
}
