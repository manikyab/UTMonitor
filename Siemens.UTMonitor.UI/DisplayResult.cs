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
            testNameData.Text = Data["Test-Name"];
            ResultData.Text = Data["Result"];
            totalData.Text = Data["Total"];
            passedData.Text = Data["Passed"];
            skippedData.Text = Data["Skipped"];
            failedData.Text = Data["Failed"];
            inconclusiveData.Text = Data["Inconclusive"];
            assertsData.Text = Data["Asserts"];
            FileLocation.Text = Data["Location"];
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FileLocation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("notepad.exe", FileLocation.Text);
        }
    }
}
