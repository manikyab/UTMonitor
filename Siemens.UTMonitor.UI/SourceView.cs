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
using System.Threading;

namespace Siemens.UTMonitor.UI
{
    public partial class SourceView : Form
    {
        string directory;//Directory string
        List<string> SCList = new List<string>();//Source Control list

        public SourceView()
        {
            InitializeComponent();
        }

        private void findFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowser.ShowDialog();//Getting Source Control Folder
            if (result == DialogResult.OK)//Checking if path is Selected or not
            {
                folderPath.Text = folderBrowser.SelectedPath;
                Environment.SpecialFolder root = folderBrowser.RootFolder;
            }
        }

        private void Monitor_Click(object sender, EventArgs e)
        {
            //Adding Source to Monitor
            if (folderPath.Text.Trim().Length > 0)
            {
                directory = folderPath.Text.Trim();//Getting Directory Path

                SCList.Add(directory);//Adding to Source List

                var watcher = FileWatch();//Creating a FileWatcher object

                Thread thr = new Thread(watcher.CreateWatcher) { IsBackground = true };//Thread for starting the FileWatcher Object

                thr.Start();

                var id = thr.ManagedThreadId;

                ListViewItem li = new ListViewItem(directory);//Adding Source directory path to list
                listView1.Items.Add(li);

                folderPath.Text = "";

            }
            else
            {
                MessageBox.Show("Please select a path to monitor.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private FileWatcher.FileWatcher FileWatch()
        {
            //Initializing Delegate
            Invoker.DataFetcher dataFetcher = new Invoker.DataFetcher(this.GetNotification);
            Invoker.ErrorFetcher errorFetcher = new Invoker.ErrorFetcher(this.GetError);
            Invoker.MonitoringSourceControl sourceControl = new Invoker.MonitoringSourceControl(this.GetSCList);
            FileWatcher.FileWatcher fileWatcher = new FileWatcher.FileWatcher(dataFetcher, directory, errorFetcher,sourceControl);//Creating fileWatcher object
            return fileWatcher;
        }

        public void GetNotification(Dictionary<string, string> list)//Function to show result when Delegate is Invoked
        {
            var obj = new DisplayResult();
            obj.Data = list;
            obj.ShowDialog();
        }

        public List<string> GetSCList()//Returning List of Source Control on Delegate call
        {
            return SCList;
        }

        public void GetError(string error)//Showing Exception to the user on delegate invoke
        {
            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SourceView_Load(object sender, EventArgs e)
        {

        }

        private void btn_exitMonitor_Click(object sender, EventArgs e)//Stoping Monitor for Source Control
        {
            if (listView1.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure?","Confirmantion",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string SCName = listView1.SelectedItems[0].SubItems[0].Text;//Getting Source name
                    SCList.Remove(SCName);//Removing from list
                    listView1.SelectedItems[0].Remove();
                }
            }
            else
            {
                MessageBox.Show("Select a Source folder to remove Monitor", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
