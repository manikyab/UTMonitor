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


        public List<string> ResultDisplay(string ResultLocation)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(ResultLocation + "\\TestResult.xml");
            XmlNodeList elem = doc.GetElementsByTagName("test-run");
            List<string> result = new List<string>();
            foreach (XmlNode item in elem)
            {
                result.Add(item.Attributes["result"].Value);
                result.Add(item.Attributes["total"].Value);
                result.Add(item.Attributes["passed"].Value);
                result.Add(item.Attributes["skipped"].Value);
                result.Add(item.Attributes["failed"].Value);
                result.Add(item.Attributes["inconclusive"].Value);
                result.Add(item.Attributes["asserts"].Value);
            }

            return result;
        }
    }
}
