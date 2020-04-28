﻿namespace SUT
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
            this.tabPageAbout = new System.Windows.Forms.TabPage();
            this.labelSoftwareVersion = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelTitleAbout = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pictureBoxServiceUnits = new System.Windows.Forms.PictureBox();
            this.labelTotalServiceUnitCount = new System.Windows.Forms.Label();
            this.groupBoxTotalNumberOfServiceUnits = new System.Windows.Forms.GroupBox();
            this.tabControlMain.SuspendLayout();
            this.tabPageTracker.SuspendLayout();
            this.tabPageAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxServiceUnits)).BeginInit();
            this.groupBoxTotalNumberOfServiceUnits.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageTracker);
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
            this.tabPageAbout.ResumeLayout(false);
            this.tabPageAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxServiceUnits)).EndInit();
            this.groupBoxTotalNumberOfServiceUnits.ResumeLayout(false);
            this.groupBoxTotalNumberOfServiceUnits.PerformLayout();
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
    }
}

