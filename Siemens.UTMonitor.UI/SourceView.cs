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
            if (folderPath.Text.Trim().Length > 0)
            {
                
                
            }
            else
            {
                MessageBox.Show("Please select a path to monitor.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void Monitor()
        {
            FileWatcher.FileWatcher fileWatcher = new FileWatcher.FileWatcher();
            fileWatcher.directory = folderPath.Text.Trim();
            fileWatcher.FileWatching();
            folderPath.Text = "";
        }
    }
}
