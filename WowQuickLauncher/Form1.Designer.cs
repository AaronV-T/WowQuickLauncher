namespace WowQuickLauncher
{
    partial class Form1
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
            this.btnLaunch = new System.Windows.Forms.Button();
            this.btnGetWindowPositions = new System.Windows.Forms.Button();
            this.chbxCloseProgramOnLaunch = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnLaunch
            // 
            this.btnLaunch.Location = new System.Drawing.Point(131, 12);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(75, 23);
            this.btnLaunch.TabIndex = 0;
            this.btnLaunch.Text = "Launch";
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // btnGetWindowPositions
            // 
            this.btnGetWindowPositions.Location = new System.Drawing.Point(109, 66);
            this.btnGetWindowPositions.Name = "btnGetWindowPositions";
            this.btnGetWindowPositions.Size = new System.Drawing.Size(125, 23);
            this.btnGetWindowPositions.TabIndex = 1;
            this.btnGetWindowPositions.Text = "Get Window Positions";
            this.btnGetWindowPositions.UseVisualStyleBackColor = true;
            this.btnGetWindowPositions.Click += new System.EventHandler(this.btnGetWindowPositions_Click);
            // 
            // chbxCloseProgramOnLaunch
            // 
            this.chbxCloseProgramOnLaunch.AutoSize = true;
            this.chbxCloseProgramOnLaunch.Location = new System.Drawing.Point(95, 41);
            this.chbxCloseProgramOnLaunch.Name = "chbxCloseProgramOnLaunch";
            this.chbxCloseProgramOnLaunch.Size = new System.Drawing.Size(150, 17);
            this.chbxCloseProgramOnLaunch.TabIndex = 2;
            this.chbxCloseProgramOnLaunch.Text = "Close Program On Launch";
            this.chbxCloseProgramOnLaunch.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 112);
            this.Controls.Add(this.chbxCloseProgramOnLaunch);
            this.Controls.Add(this.btnGetWindowPositions);
            this.Controls.Add(this.btnLaunch);
            this.Name = "Form1";
            this.Text = "WoW Quick Launcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.Button btnGetWindowPositions;
        private System.Windows.Forms.CheckBox chbxCloseProgramOnLaunch;
    }
}

