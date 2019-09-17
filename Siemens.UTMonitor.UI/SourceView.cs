﻿using System;
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
        string directory;
        CancellationTokenSource cts = new System.Threading.CancellationTokenSource();
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
            //
            if (folderPath.Text.Trim().Length > 0)
            {
                directory = folderPath.Text.Trim();
                //Action action = FileWatch;
                //var token = cts.Token;
                //Task.Run(action, token);
                Thread thr = new Thread(FileWatch);
                thr.Start();
                var id = thr.ManagedThreadId;

                //MessageBox.Show(id.ToString());

                ListViewItem li = new ListViewItem(directory);
                li.Tag = thr;

                listView1.Items.Add(li);

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
            Invoker.ErrorFetcher errorFetcher = new Invoker.ErrorFetcher(this.GetError);
            FileWatcher.FileWatcher fileWatcher = new FileWatcher.FileWatcher(dataFetcher, directory, errorFetcher);
        }
        public void GetNotification(Dictionary<string, string> list)
        {
            var obj = new DisplayResult();
            obj.Data = list;
            obj.ShowDialog();
            //MessageBox.Show(list["Result"]);
        }

        public void GetError(string error)
        {
            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SourceView_Load(object sender, EventArgs e)
        {

        }

        private void btn_exitMonitor_Click(object sender, EventArgs e)
        {

            Thread thr = (Thread)listView1.SelectedItems[0].Tag;
            thr.Abort();
        }
    }
}
