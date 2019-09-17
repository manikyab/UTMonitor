namespace Siemens.UTMonitor.UI
{
    partial class SourceView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.folderPath = new System.Windows.Forms.TextBox();
            this.findFolder = new System.Windows.Forms.Button();
            this.Monitor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Source Folder";
            // 
            // folderPath
            // 
            this.folderPath.Location = new System.Drawing.Point(190, 75);
            this.folderPath.Name = "folderPath";
            this.folderPath.Size = new System.Drawing.Size(171, 20);
            this.folderPath.TabIndex = 1;
            // 
            // findFolder
            // 
            this.findFolder.Location = new System.Drawing.Point(386, 75);
            this.findFolder.Name = "findFolder";
            this.findFolder.Size = new System.Drawing.Size(75, 23);
            this.findFolder.TabIndex = 2;
            this.findFolder.Text = "Browse Folder";
            this.findFolder.UseVisualStyleBackColor = true;
            this.findFolder.Click += new System.EventHandler(this.findFolder_Click);
            // 
            // Monitor
            // 
            this.Monitor.Location = new System.Drawing.Point(467, 76);
            this.Monitor.Name = "Monitor";
            this.Monitor.Size = new System.Drawing.Size(75, 23);
            this.Monitor.TabIndex = 3;
            this.Monitor.Text = "Monitor";
            this.Monitor.UseVisualStyleBackColor = true;
            this.Monitor.Click += new System.EventHandler(this.Monitor_Click);
            // 
            // SourceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Monitor);
            this.Controls.Add(this.findFolder);
            this.Controls.Add(this.folderPath);
            this.Controls.Add(this.label1);
            this.Name = "SourceView";
            this.Text = "UT Monitor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.TextBox folderPath;
        private System.Windows.Forms.Button findFolder;
        private System.Windows.Forms.Button Monitor;
    }
}

