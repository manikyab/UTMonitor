using Siemens.UTMonitor.Invoker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Siemens.UTMonitor.XMLParser
{
    public class XMLParser:IDisposable
    {
        public void Dispose() { }


        public Dictionary<string, string> ResultDisplay(string ResultLocation,ErrorFetcher errorfetcher)
        {
            Dictionary<string,string> result = null;//Dictonary for returning test case result
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(ResultLocation + "\\TestResult.xml");//opening testcase result
                XmlNodeList elem = doc.GetElementsByTagName("test-run");
                result = new Dictionary<string, string>();
                XmlNode fileName = doc.GetElementsByTagName("test-suite")[0];

                //Adding result data in Dictionary

                result.Add("Test-Name", fileName.Attributes["name"].Value);
                foreach (XmlNode item in elem)
                {
                    result.Add("Result",item.Attributes["result"].Value);
                    result.Add("Total",item.Attributes["total"].Value);
                    result.Add("Passed",item.Attributes["passed"].Value);
                    result.Add("Skipped",item.Attributes["skipped"].Value);
                    result.Add("Failed",item.Attributes["failed"].Value);
                    result.Add("Inconclusive",item.Attributes["inconclusive"].Value);
                    result.Add("Asserts",item.Attributes["asserts"].Value);
                }
                result.Add("Location", ResultLocation + "\\TestResult.xml");
            }
            catch (Exception e)
            {
                errorfetcher.Invoke(e.Message);
            }
            return result;
        }
    }
}
