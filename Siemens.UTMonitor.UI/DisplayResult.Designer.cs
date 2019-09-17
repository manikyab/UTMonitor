namespace Siemens.UTMonitor.UI
{
    partial class DisplayResult
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
            this.testName = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.Button();
            this.ResultData = new System.Windows.Forms.Label();
            this.testNameData = new System.Windows.Forms.Label();
            this.Result = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.totalData = new System.Windows.Forms.Label();
            this.passedData = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.skippedData = new System.Windows.Forms.Label();
            this.failedData = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.inconclusiveData = new System.Windows.Forms.Label();
            this.assertsData = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.FileLocation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(86, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Test Result";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // testName
            // 
            this.testName.AutoSize = true;
            this.testName.Location = new System.Drawing.Point(13, 68);
            this.testName.Name = "testName";
            this.testName.Size = new System.Drawing.Size(59, 13);
            this.testName.TabIndex = 1;
            this.testName.Text = "Test Name";
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(16, 324);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 2;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.Close_Click);
            // 
            // ResultData
            // 
            this.ResultData.AutoSize = true;
            this.ResultData.Location = new System.Drawing.Point(128, 90);
            this.ResultData.Name = "ResultData";
            this.ResultData.Size = new System.Drawing.Size(35, 13);
            this.ResultData.TabIndex = 6;
            this.ResultData.Text = "label2";
            // 
            // testNameData
            // 
            this.testNameData.AutoSize = true;
            this.testNameData.Location = new System.Drawing.Point(128, 68);
            this.testNameData.Name = "testNameData";
            this.testNameData.Size = new System.Drawing.Size(35, 13);
            this.testNameData.TabIndex = 7;
            this.testNameData.Text = "label2";
            // 
            // Result
            // 
            this.Result.AutoSize = true;
            this.Result.Location = new System.Drawing.Point(13, 90);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(37, 13);
            this.Result.TabIndex = 8;
            this.Result.Text = "Result";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Passed";
            // 
            // totalData
            // 
            this.totalData.AutoSize = true;
            this.totalData.Location = new System.Drawing.Point(128, 113);
            this.totalData.Name = "totalData";
            this.totalData.Size = new System.Drawing.Size(35, 13);
            this.totalData.TabIndex = 11;
            this.totalData.Text = "label2";
            // 
            // passedData
            // 
            this.passedData.AutoSize = true;
            this.passedData.Location = new System.Drawing.Point(128, 135);
            this.passedData.Name = "passedData";
            this.passedData.Size = new System.Drawing.Size(35, 13);
            this.passedData.TabIndex = 10;
            this.passedData.Text = "label2";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 113);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Total";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 183);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "Failed";
            // 
            // skippedData
            // 
            this.skippedData.AutoSize = true;
            this.skippedData.Location = new System.Drawing.Point(128, 161);
            this.skippedData.Name = "skippedData";
            this.skippedData.Size = new System.Drawing.Size(35, 13);
            this.skippedData.TabIndex = 15;
            this.skippedData.Text = "label2";
            // 
            // failedData
            // 
            this.failedData.AutoSize = true;
            this.failedData.Location = new System.Drawing.Point(128, 183);
            this.failedData.Name = "failedData";
            this.failedData.Size = new System.Drawing.Size(35, 13);
            this.failedData.TabIndex = 14;
            this.failedData.Text = "label2";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(13, 161);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "Skipped";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 227);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 13);
            this.label16.TabIndex = 20;
            this.label16.Text = "Asserts";
            // 
            // inconclusiveData
            // 
            this.inconclusiveData.AutoSize = true;
            this.inconclusiveData.Location = new System.Drawing.Point(128, 205);
            this.inconclusiveData.Name = "inconclusiveData";
            this.inconclusiveData.Size = new System.Drawing.Size(35, 13);
            this.inconclusiveData.TabIndex = 19;
            this.inconclusiveData.Text = "label2";
            // 
            // assertsData
            // 
            this.assertsData.AutoSize = true;
            this.assertsData.Location = new System.Drawing.Point(128, 227);
            this.assertsData.Name = "assertsData";
            this.assertsData.Size = new System.Drawing.Size(35, 13);
            this.assertsData.TabIndex = 18;
            this.assertsData.Text = "label2";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(13, 205);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 13);
            this.label19.TabIndex = 17;
            this.label19.Text = "Inconclusive";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(13, 253);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(48, 13);
            this.label56.TabIndex = 22;
            this.label56.Text = "Location";
            // 
            // FileLocation
            // 
            this.FileLocation.AutoSize = true;
            this.FileLocation.Location = new System.Drawing.Point(128, 253);
            this.FileLocation.Name = "FileLocation";
            this.FileLocation.Size = new System.Drawing.Size(35, 13);
            this.FileLocation.TabIndex = 21;
            this.FileLocation.Text = "label2";
            // 
            // DisplayResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 359);
            this.Controls.Add(this.label56);
            this.Controls.Add(this.FileLocation);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.inconclusiveData);
            this.Controls.Add(this.assertsData);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.skippedData);
            this.Controls.Add(this.failedData);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.totalData);
            this.Controls.Add(this.passedData);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.testNameData);
            this.Controls.Add(this.ResultData);
            this.Controls.Add(this.close);
            this.Controls.Add(this.testName);
            this.Controls.Add(this.label1);
            this.Name = "DisplayResult";
            this.Text = "DisplayResult";
            this.Load += new System.EventHandler(this.DisplayResult_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label testName;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Label ResultData;
        private System.Windows.Forms.Label testNameData;
        private System.Windows.Forms.Label Result;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label totalData;
        private System.Windows.Forms.Label passedData;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label skippedData;
        private System.Windows.Forms.Label failedData;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label inconclusiveData;
        private System.Windows.Forms.Label assertsData;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label FileLocation;
    }
}