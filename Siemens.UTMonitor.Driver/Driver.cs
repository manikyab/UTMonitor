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
        ErrorFetcher errorFetcher;

        public void Dispose() { }

        public Dictionary<string, string> ExecuteDriver(string projectDLLPath, string directory,ErrorFetcher errorFetcher)
        {
            Dictionary<string, string> result = null;
            this.errorFetcher = errorFetcher;
            try
            {
                var pathSplit = projectDLLPath.Split('\\');
                var projectLocation = string.Join("\\", pathSplit.Take((pathSplit.Length) - 1));
                var projectName = pathSplit[pathSplit.Length - 4];
                var testLocation = GetNunitLocation(projectName, projectLocation, directory);

                RunNunitTest(testLocation, projectLocation, projectName);

                result = GetResult(testLocation);
            }
            catch(Exception e)
            {
                errorFetcher.Invoke(e.Message);
            }
            return result;
        }
        
        private string GetNunitLocation(string projectName,string sourceLocation,string directory)
        {
           string returnValue = null;
            using (var nunitfinder = new NunitFinder.NunitFinder())
            {
                returnValue = nunitfinder.NUnitFinder(directory, projectName, sourceLocation, errorFetcher);
            }
            return returnValue;
        }
        private void RunNunitTest(string testLocation,string projectLocation,string projectName)
        {
            using (var runNunit=new RunNUnit.RunNUnit())
            {
                runNunit.RunNunit(testLocation, projectLocation, projectName, errorFetcher);
            }
        }

        private Dictionary<string, string> GetResult(string ResultLocation)
        {
            Dictionary<string, string> result = null;
            using (var XMLparse=new XMLParser.XMLParser())
            {
                result = XMLparse.ResultDisplay(ResultLocation, errorFetcher);
            }
            return result;
        }
    }
}
