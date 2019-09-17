using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siemens.UTMonitor.FileWatcher;
using System.Windows.Forms;

namespace Siemens.UTMonitor.UI
{
    public partial class SourceView : Form
    {
        string directory;
        public SourceView()
        {
            InitializeComponent();
        }

        private void findFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
                folderPath.Text = folderBrowser.SelectedPath;
                Environment.SpecialFolder root = folderBrowser.RootFolder;
            }
        }

        private void Monitor_Click(object sender, EventArgs e)
        {
            System.Threading.CancellationTokenSource cancellationTokenSource = new System.Threading.CancellationTokenSource();
            if (folderPath.Text.Trim().Length > 0)
            {
                 directory = folderPath.Text.Trim();
                Action action = FileWatch;
                Task.Run(action,cancellationTokenSource.Token);

                folderPath.Text = "";
            }
            else
            {
                MessageBox.Show("Please select a path to monitor.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void FileWatch()
        {
            Invoker.DataFetcher dataFetcher = new Invoker.DataFetcher(this.GetNotification);
            FileWatcher.FileWatcher fileWatcher = new FileWatcher.FileWatcher(dataFetcher, directory);
        }
        public void GetNotification(List<string> list)
        {
            MessageBox.Show(list[0], "Test Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void SourceView_Load(object sender, EventArgs e)
        {

        }
    }
}
