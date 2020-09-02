namespace Tetris_
{
    partial class AlertWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlertWin));
            this.Alert = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Alert
            // 
            this.Alert.BackColor = System.Drawing.Color.Transparent;
            this.Alert.Font = new System.Drawing.Font("Microsoft YaHei", 13.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Alert.Location = new System.Drawing.Point(10, 23);
            this.Alert.Name = "Alert";
            this.Alert.Size = new System.Drawing.Size(283, 95);
            this.Alert.TabIndex = 3;
            this.Alert.Text = "Alert";
            this.Alert.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Alert.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Alert_MouseDown);
            // 
            // OK
            // 
            this.OK.BackColor = System.Drawing.Color.Gainsboro;
            this.OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OK.Location = new System.Drawing.Point(99, 113);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(104, 32);
            this.OK.TabIndex = 2;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = false;
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Gainsboro;
            this.Exit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Exit.BackgroundImage")));
            this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.Location = new System.Drawing.Point(272, 0);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(30, 25);
            this.Exit.TabIndex = 4;
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.button1_Click);
            // 
            // AlertWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCoral;
            this.BackgroundImage = global::Tetris_.Properties.Resources.Sign8;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(302, 155);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Alert);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AlertWin";
            this.ShowInTaskbar = false;
            this.Text = "AlertWin";
            this.TopMost = true;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AlertWin_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label Alert;
        public System.Windows.Forms.Button OK;
        public System.Windows.Forms.Button Exit;
    }
}