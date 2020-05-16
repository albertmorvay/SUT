namespace SUT
{
    partial class FormCategoryPicker
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
            this.buttonWorkCategory01 = new System.Windows.Forms.Button();
            this.buttonWorkCategory02 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonWorkCategory01
            // 
            this.buttonWorkCategory01.BackgroundImage = global::SUT.Properties.Resources.clock_icon_made_by_eucalyp_from_flaticon;
            this.buttonWorkCategory01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonWorkCategory01.FlatAppearance.BorderSize = 0;
            this.buttonWorkCategory01.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.buttonWorkCategory01.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonWorkCategory01.Location = new System.Drawing.Point(12, 8);
            this.buttonWorkCategory01.Name = "buttonWorkCategory01";
            this.buttonWorkCategory01.Size = new System.Drawing.Size(80, 80);
            this.buttonWorkCategory01.TabIndex = 0;
            this.buttonWorkCategory01.UseVisualStyleBackColor = true;
            this.buttonWorkCategory01.Click += new System.EventHandler(this.ButtonWorkCategory01_Click);
            // 
            // buttonWorkCategory02
            // 
            this.buttonWorkCategory02.BackgroundImage = global::SUT.Properties.Resources.calculator_icon_made_by_eucalyp_from_flaticon;
            this.buttonWorkCategory02.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonWorkCategory02.FlatAppearance.BorderSize = 0;
            this.buttonWorkCategory02.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.buttonWorkCategory02.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonWorkCategory02.Location = new System.Drawing.Point(98, 8);
            this.buttonWorkCategory02.Name = "buttonWorkCategory02";
            this.buttonWorkCategory02.Size = new System.Drawing.Size(80, 80);
            this.buttonWorkCategory02.TabIndex = 1;
            this.buttonWorkCategory02.UseVisualStyleBackColor = true;
            this.buttonWorkCategory02.Click += new System.EventHandler(this.ButtonWorkCategory02_Click);
            // 
            // FormCategoryPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(520, 100);
            this.Controls.Add(this.buttonWorkCategory02);
            this.Controls.Add(this.buttonWorkCategory01);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCategoryPicker";
            this.Text = "FormCategoryPicker";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonWorkCategory01;
        private System.Windows.Forms.Button buttonWorkCategory02;
    }
}