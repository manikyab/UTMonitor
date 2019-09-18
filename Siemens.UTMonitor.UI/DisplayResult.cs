using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Siemens.UTMonitor.UI
{
    public partial class DisplayResult : Form
    {
        public Dictionary<string,string> Data { get; set; }
        public DisplayResult()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DisplayResult_Load(object sender, EventArgs e)
        {
            //Adding test data to Label
            testNameData.Text = Data["Test-Name"];
            ResultData.Text = Data["Result"];
            totalData.Text = Data["Total"];
            passedData.Text = Data["Passed"];
            skippedData.Text = Data["Skipped"];
            failedData.Text = Data["Failed"];
            inconclusiveData.Text = Data["Inconclusive"];
            assertsData.Text = Data["Asserts"];
            var temp = Data["Location"].Split('\\');
            FileLocation.Text = temp[temp.Length - 4];
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FileLocation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //process to show testcase result file to user
            Process.Start("notepad.exe", Data["Location"]);
        }
    }
}
