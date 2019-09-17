using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Siemens.UTMonitor.RunNUnit
{
    public class RunNUnit:IDisposable
    {
        public void Dispose() { }


        private Process CreateProcess()
        {
            var processInfo = new ProcessStartInfo();
            processInfo.FileName = "cmd.exe";
            processInfo.RedirectStandardInput = true;

            Process process = new Process();
            process.StartInfo = processInfo;
            process.EnableRaisingEvents = true;

            return process;
        }

        private void CopyData(string sourceLocation,string destinationLocation,Process process)
        {
            var command = "robocopy " + sourceLocation + " " + destinationLocation + " /is /it";
            process.StandardInput.WriteLine(command);
        }

        public void RunNunit(string testlocation,string projectLocation,string projectName)
        {
            try
            {
                var process = CreateProcess();
                process.Start();

                var command = "cd " + testlocation;

                process.StandardInput.WriteLine(command);

                CopyData(projectLocation, testlocation, process);

                var nunitConsole = "\"C:\\Program Files (x86)\\NUnit.org\\nunit-console\\nunit3-console.exe\"";

                command = nunitConsole + " " + testlocation + "\\" + projectName + "Test.dll";

                process.StandardInput.WriteLine(command);

                process.StandardInput.WriteLine("exit");

                process.WaitForExit();

                returnValue = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Data);
            }
        }
    }
}
