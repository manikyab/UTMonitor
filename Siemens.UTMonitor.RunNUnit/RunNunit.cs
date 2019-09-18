using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Siemens.UTMonitor.Invoker;

namespace Siemens.UTMonitor.RunNUnit
{
    public class RunNUnit:IDisposable
    {
        public void Dispose() { }


        private Process CreateProcess()
        {
            //Creating setup info for cmd process
            var processInfo = new ProcessStartInfo();
            processInfo.FileName = "cmd.exe";
            processInfo.RedirectStandardInput = true;
            processInfo.UseShellExecute = false;
            processInfo.CreateNoWindow = true;

            //Starting process with Start info
            Process process = new Process();
            process.StartInfo = processInfo;
            process.EnableRaisingEvents = true;

            return process;
        }

        private void CopyData(string sourceLocation,string destinationLocation,Process process)//Copying latest DLL to test location with overwrite
        {
            var command = "robocopy " + sourceLocation + " " + destinationLocation + " /is /it";
            process.StandardInput.WriteLine(command);
        }

        public void RunNunit(string testlocation,string projectLocation,string projectName,ErrorFetcher errorfetcher)
        {
            try
            {
                var process = CreateProcess();//Process Creation
                process.Start();//Process Start

                var command = "cd " + testlocation;//Changning CMD dir to Test case directory

                process.StandardInput.WriteLine(command);

                CopyData(projectLocation, testlocation, process);//Copying latest DLL

                var nunitConsole = "\"C:\\Program Files (x86)\\NUnit.org\\nunit-console\\nunit3-console.exe\"";//Location of NUnit Console

                command = nunitConsole + " " + testlocation + "\\" + projectName + "Test.dll";//Commmand for running NUnit console with testcase

                process.StandardInput.WriteLine(command);

                process.StandardInput.WriteLine("exit");//Exiting CMD

                process.WaitForExit();

            }
            catch (Exception e)
            {
                errorfetcher.Invoke(e.Message);
            }
        }
    }
}
