namespace SUT
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageTracker = new System.Windows.Forms.TabPage();
            this.groupBoxTotalNumberOfServiceUnits = new System.Windows.Forms.GroupBox();
            this.pictureBoxServiceUnits = new System.Windows.Forms.PictureBox();
            this.labelTotalServiceUnitCount = new System.Windows.Forms.Label();
            this.tabPageReports = new System.Windows.Forms.TabPage();
            this.checkBoxRunOnStartup = new System.Windows.Forms.CheckBox();
            this.groupBoxWeeklyReport = new System.Windows.Forms.GroupBox();
            this.numericUpDownWeeklyReportWeekNumber = new System.Windows.Forms.NumericUpDown();
            this.buttonGenerateWeeklyReport = new System.Windows.Forms.Button();
            this.numericUpDownWeeklyReportYear = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPageAbout = new System.Windows.Forms.TabPage();
            this.labelSoftwareVersion = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelTitleAbout = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.checkBoxTrackWhilstLocked = new System.Windows.Forms.CheckBox();
            this.tabControlMain.SuspendLayout();
            this.tabPageTracker.SuspendLayout();
            this.groupBoxTotalNumberOfServiceUnits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxServiceUnits)).BeginInit();
            this.tabPageReports.SuspendLayout();
            this.groupBoxWeeklyReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWeeklyReportWeekNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWeeklyReportYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPageAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageTracker);
            this.tabControlMain.Controls.Add(this.tabPageReports);
            this.tabControlMain.Controls.Add(this.tabPageAbout);
            this.tabControlMain.Location = new System.Drawing.Point(12, 12);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(280, 337);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageTracker
            // 
            this.tabPageTracker.Controls.Add(this.groupBoxTotalNumberOfServiceUnits);
            this.tabPageTracker.Location = new System.Drawing.Point(4, 22);
            this.tabPageTracker.Name = "tabPageTracker";
            this.tabPageTracker.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTracker.Size = new System.Drawing.Size(272, 311);
            this.tabPageTracker.TabIndex = 0;
            this.tabPageTracker.Text = "Tracker";
            this.tabPageTracker.UseVisualStyleBackColor = true;
            // 
            // groupBoxTotalNumberOfServiceUnits
            // 
            this.groupBoxTotalNumberOfServiceUnits.Controls.Add(this.pictureBoxServiceUnits);
            this.groupBoxTotalNumberOfServiceUnits.Controls.Add(this.labelTotalServiceUnitCount);
            this.groupBoxTotalNumberOfServiceUnits.Location = new System.Drawing.Point(20, 20);
            this.groupBoxTotalNumberOfServiceUnits.Name = "groupBoxTotalNumberOfServiceUnits";
            this.groupBoxTotalNumberOfServiceUnits.Size = new System.Drawing.Size(233, 112);
            this.groupBoxTotalNumberOfServiceUnits.TabIndex = 2;
            this.groupBoxTotalNumberOfServiceUnits.TabStop = false;
            this.groupBoxTotalNumberOfServiceUnits.Text = "Total Number of Service Units";
            // 
            // pictureBoxServiceUnits
            // 
            this.pictureBoxServiceUnits.Image = global::SUT.Properties.Resources.clock_icon_made_by_eucalyp_from_flaticon;
            this.pictureBoxServiceUnits.Location = new System.Drawing.Point(19, 32);
            this.pictureBoxServiceUnits.Name = "pictureBoxServiceUnits";
            this.pictureBoxServiceUnits.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxServiceUnits.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxServiceUnits.TabIndex = 0;
            this.pictureBoxServiceUnits.TabStop = false;
            // 
            // labelTotalServiceUnitCount
            // 
            this.labelTotalServiceUnitCount.AutoSize = true;
            this.labelTotalServiceUnitCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalServiceUnitCount.Location = new System.Drawing.Point(103, 26);
            this.labelTotalServiceUnitCount.Name = "labelTotalServiceUnitCount";
            this.labelTotalServiceUnitCount.Size = new System.Drawing.Size(104, 73);
            this.labelTotalServiceUnitCount.TabIndex = 1;
            this.labelTotalServiceUnitCount.Text = "00";
            this.labelTotalServiceUnitCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPageReports
            // 
            this.tabPageReports.Controls.Add(this.checkBoxTrackWhilstLocked);
            this.tabPageReports.Controls.Add(this.checkBoxRunOnStartup);
            this.tabPageReports.Controls.Add(this.groupBoxWeeklyReport);
            this.tabPageReports.Location = new System.Drawing.Point(4, 22);
            this.tabPageReports.Name = "tabPageReports";
            this.tabPageReports.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReports.Size = new System.Drawing.Size(272, 311);
            this.tabPageReports.TabIndex = 2;
            this.tabPageReports.Text = "Reports";
            this.tabPageReports.UseVisualStyleBackColor = true;
            this.tabPageReports.Click += new System.EventHandler(this.tabPageReports_Click);
            // 
            // checkBoxRunOnStartup
            // 
            this.checkBoxRunOnStartup.AutoSize = true;
            this.checkBoxRunOnStartup.Location = new System.Drawing.Point(20, 189);
            this.checkBoxRunOnStartup.Name = "checkBoxRunOnStartup";
            this.checkBoxRunOnStartup.Size = new System.Drawing.Size(100, 17);
            this.checkBoxRunOnStartup.TabIndex = 4;
            this.checkBoxRunOnStartup.Text = "Run On Startup";
            this.checkBoxRunOnStartup.UseVisualStyleBackColor = true;
            this.checkBoxRunOnStartup.CheckedChanged += new System.EventHandler(this.checkBoxRunOnStartup_CheckedChanged);
            // 
            // groupBoxWeeklyReport
            // 
            this.groupBoxWeeklyReport.Controls.Add(this.numericUpDownWeeklyReportWeekNumber);
            this.groupBoxWeeklyReport.Controls.Add(this.buttonGenerateWeeklyReport);
            this.groupBoxWeeklyReport.Controls.Add(this.numericUpDownWeeklyReportYear);
            this.groupBoxWeeklyReport.Controls.Add(this.pictureBox1);
            this.groupBoxWeeklyReport.Location = new System.Drawing.Point(20, 20);
            this.groupBoxWeeklyReport.Name = "groupBoxWeeklyReport";
            this.groupBoxWeeklyReport.Size = new System.Drawing.Size(233, 162);
            this.groupBoxWeeklyReport.TabIndex = 3;
            this.groupBoxWeeklyReport.TabStop = false;
            this.groupBoxWeeklyReport.Text = "Year and Week Number";
            // 
            // numericUpDownWeeklyReportWeekNumber
            // 
            this.numericUpDownWeeklyReportWeekNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.numericUpDownWeeklyReportWeekNumber.Location = new System.Drawing.Point(94, 66);
            this.numericUpDownWeeklyReportWeekNumber.Maximum = new decimal(new int[] {
            52,
            0,
            0,
            0});
            this.numericUpDownWeeklyReportWeekNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownWeeklyReportWeekNumber.Name = "numericUpDownWeeklyReportWeekNumber";
            this.numericUpDownWeeklyReportWeekNumber.Size = new System.Drawing.Size(100, 26);
            this.numericUpDownWeeklyReportWeekNumber.TabIndex = 7;
            this.numericUpDownWeeklyReportWeekNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonGenerateWeeklyReport
            // 
            this.buttonGenerateWeeklyReport.Location = new System.Drawing.Point(19, 98);
            this.buttonGenerateWeeklyReport.Name = "buttonGenerateWeeklyReport";
            this.buttonGenerateWeeklyReport.Size = new System.Drawing.Size(175, 23);
            this.buttonGenerateWeeklyReport.TabIndex = 6;
            this.buttonGenerateWeeklyReport.Text = "Save to My Documents Folder";
            this.buttonGenerateWeeklyReport.UseVisualStyleBackColor = true;
            this.buttonGenerateWeeklyReport.Click += new System.EventHandler(this.buttonGenerateWeeklyReport_Click);
            // 
            // numericUpDownWeeklyReportYear
            // 
            this.numericUpDownWeeklyReportYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.numericUpDownWeeklyReportYear.Location = new System.Drawing.Point(94, 32);
            this.numericUpDownWeeklyReportYear.Maximum = new decimal(new int[] {
            2120,
            0,
            0,
            0});
            this.numericUpDownWeeklyReportYear.Minimum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.numericUpDownWeeklyReportYear.Name = "numericUpDownWeeklyReportYear";
            this.numericUpDownWeeklyReportYear.Size = new System.Drawing.Size(100, 26);
            this.numericUpDownWeeklyReportYear.TabIndex = 5;
            this.numericUpDownWeeklyReportYear.Value = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SUT.Properties.Resources.calculator_icon_made_by_eucalyp_from_flaticon;
            this.pictureBox1.Location = new System.Drawing.Point(19, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // tabPageAbout
            // 
            this.tabPageAbout.Controls.Add(this.labelSoftwareVersion);
            this.tabPageAbout.Controls.Add(this.labelVersion);
            this.tabPageAbout.Controls.Add(this.labelTitleAbout);
            this.tabPageAbout.Controls.Add(this.richTextBox1);
            this.tabPageAbout.Location = new System.Drawing.Point(4, 22);
            this.tabPageAbout.Name = "tabPageAbout";
            this.tabPageAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAbout.Size = new System.Drawing.Size(272, 311);
            this.tabPageAbout.TabIndex = 1;
            this.tabPageAbout.Text = "About";
            this.tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // labelSoftwareVersion
            // 
            this.labelSoftwareVersion.AutoSize = true;
            this.labelSoftwareVersion.Location = new System.Drawing.Point(57, 15);
            this.labelSoftwareVersion.Name = "labelSoftwareVersion";
            this.labelSoftwareVersion.Size = new System.Drawing.Size(44, 13);
            this.labelSoftwareVersion.TabIndex = 3;
            this.labelSoftwareVersion.Text = "X.X.X.X";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.Location = new System.Drawing.Point(3, 15);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(53, 13);
            this.labelVersion.TabIndex = 2;
            this.labelVersion.Text = "Version:";
            // 
            // labelTitleAbout
            // 
            this.labelTitleAbout.AutoSize = true;
            this.labelTitleAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleAbout.Location = new System.Drawing.Point(3, 38);
            this.labelTitleAbout.Name = "labelTitleAbout";
            this.labelTitleAbout.Size = new System.Drawing.Size(201, 13);
            this.labelTitleAbout.TabIndex = 1;
            this.labelTitleAbout.Text = "License and Open Source Notices";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(6, 57);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(260, 248);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // checkBoxTrackWhilstLocked
            // 
            this.checkBoxTrackWhilstLocked.AutoSize = true;
            this.checkBoxTrackWhilstLocked.Location = new System.Drawing.Point(20, 212);
            this.checkBoxTrackWhilstLocked.Name = "checkBoxTrackWhilstLocked";
            this.checkBoxTrackWhilstLocked.Size = new System.Drawing.Size(125, 17);
            this.checkBoxTrackWhilstLocked.TabIndex = 5;
            this.checkBoxTrackWhilstLocked.Text = "Track Whilst Locked";
            this.checkBoxTrackWhilstLocked.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(304, 361);
            this.Controls.Add(this.tabControlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Service Unit Tracker";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageTracker.ResumeLayout(false);
            this.groupBoxTotalNumberOfServiceUnits.ResumeLayout(false);
            this.groupBoxTotalNumberOfServiceUnits.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxServiceUnits)).EndInit();
            this.tabPageReports.ResumeLayout(false);
            this.tabPageReports.PerformLayout();
            this.groupBoxWeeklyReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWeeklyReportWeekNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWeeklyReportYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPageAbout.ResumeLayout(false);
            this.tabPageAbout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageTracker;
        private System.Windows.Forms.TabPage tabPageAbout;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label labelSoftwareVersion;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelTitleAbout;
        private System.Windows.Forms.Label labelTotalServiceUnitCount;
        private System.Windows.Forms.PictureBox pictureBoxServiceUnits;
        private System.Windows.Forms.GroupBox groupBoxTotalNumberOfServiceUnits;
        private System.Windows.Forms.TabPage tabPageReports;
        private System.Windows.Forms.GroupBox groupBoxWeeklyReport;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown numericUpDownWeeklyReportYear;
        private System.Windows.Forms.Button buttonGenerateWeeklyReport;
        private System.Windows.Forms.NumericUpDown numericUpDownWeeklyReportWeekNumber;
        private System.Windows.Forms.CheckBox checkBoxRunOnStartup;
        private System.Windows.Forms.CheckBox checkBoxTrackWhilstLocked;
    }
}

