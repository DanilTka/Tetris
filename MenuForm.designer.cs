namespace Tetris_
{
    partial class MenuForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.Exit = new System.Windows.Forms.Button();
            this.Hello = new System.Windows.Forms.Label();
            this.Accept = new System.Windows.Forms.Button();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.Music = new System.Windows.Forms.Button();
            this.EnRu = new System.Windows.Forms.Button();
            this.ChangeButton = new System.Windows.Forms.Timer(this.components);
            this.userControl11 = new Tetris_.UserControl1();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Exit.BackgroundImage")));
            this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Exit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Exit.FlatAppearance.BorderSize = 0;
            this.Exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.Font = new System.Drawing.Font("Segoe Print", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.ForeColor = System.Drawing.Color.Black;
            this.Exit.Location = new System.Drawing.Point(360, 0);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(40, 30);
            this.Exit.TabIndex = 17;
            this.Exit.TabStop = false;
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Hello
            // 
            this.Hello.BackColor = System.Drawing.Color.Transparent;
            this.Hello.Font = new System.Drawing.Font("Book Antiqua", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hello.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Hello.Location = new System.Drawing.Point(105, 0);
            this.Hello.Name = "Hello";
            this.Hello.Size = new System.Drawing.Size(190, 97);
            this.Hello.TabIndex = 18;
            this.Hello.Text = "Enter your profil name";
            this.Hello.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Hello.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            // 
            // Accept
            // 
            this.Accept.BackColor = System.Drawing.Color.Transparent;
            this.Accept.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.Accept.FlatAppearance.BorderSize = 3;
            this.Accept.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Accept.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Accept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Accept.Font = new System.Drawing.Font("Book Antiqua", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Accept.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Accept.Location = new System.Drawing.Point(105, 132);
            this.Accept.Name = "Accept";
            this.Accept.Size = new System.Drawing.Size(190, 51);
            this.Accept.TabIndex = 0;
            this.Accept.TabStop = false;
            this.Accept.Text = "Accept";
            this.Accept.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Accept.UseVisualStyleBackColor = false;
            this.Accept.Click += new System.EventHandler(this.Accept_Click);
            // 
            // checkBox
            // 
            this.checkBox.BackColor = System.Drawing.Color.Transparent;
            this.checkBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox.Location = new System.Drawing.Point(105, 186);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(186, 23);
            this.checkBox.TabIndex = 20;
            this.checkBox.TabStop = false;
            this.checkBox.Text = "Remember me";
            this.checkBox.UseVisualStyleBackColor = false;
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox.Font = new System.Drawing.Font("Book Antiqua", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.textBox.Location = new System.Drawing.Point(105, 96);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(190, 30);
            this.textBox.TabIndex = 20;
            this.textBox.TabStop = false;
            this.textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Music
            // 
            this.Music.BackColor = System.Drawing.Color.Transparent;
            this.Music.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Music.BackgroundImage")));
            this.Music.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Music.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Music.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Music.FlatAppearance.BorderSize = 0;
            this.Music.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.Music.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.Music.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Music.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Music.Location = new System.Drawing.Point(320, 0);
            this.Music.Name = "Music";
            this.Music.Size = new System.Drawing.Size(40, 30);
            this.Music.TabIndex = 18;
            this.Music.TabStop = false;
            this.Music.UseVisualStyleBackColor = false;
            this.Music.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Music_MouseClick);
            this.Music.MouseEnter += new System.EventHandler(this.Music_MouseEnter);
            this.Music.MouseLeave += new System.EventHandler(this.Music_MouseLeave);
            // 
            // EnRu
            // 
            this.EnRu.BackColor = System.Drawing.Color.Transparent;
            this.EnRu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.EnRu.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.EnRu.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.EnRu.FlatAppearance.BorderSize = 0;
            this.EnRu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.EnRu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.EnRu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EnRu.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnRu.ForeColor = System.Drawing.Color.Black;
            this.EnRu.Location = new System.Drawing.Point(284, 0);
            this.EnRu.Name = "EnRu";
            this.EnRu.Size = new System.Drawing.Size(36, 30);
            this.EnRu.TabIndex = 19;
            this.EnRu.TabStop = false;
            this.EnRu.Text = "EN";
            this.EnRu.UseVisualStyleBackColor = false;
            this.EnRu.Click += new System.EventHandler(this.EnRu_Click);
            // 
            // ChangeButton
            // 
            this.ChangeButton.Enabled = true;
            this.ChangeButton.Interval = 200;
            this.ChangeButton.Tick += new System.EventHandler(this.ChangeButton_Tick);
            // 
            // userControl11
            // 
            this.userControl11.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.userControl11.BackgroundImage = global::Tetris_.Properties.Resources.UserControlBackGround;
            this.userControl11.lev = "Beach";
            this.userControl11.Location = new System.Drawing.Point(0, 0);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(438, 577);
            this.userControl11.TabIndex = 25;
            this.userControl11.Visible = false;
            this.userControl11.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            // 
            // MenuForm
            // 
            this.AcceptButton = this.Accept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Tetris_.Properties.Resources.HelloBackGround2;
            this.ClientSize = new System.Drawing.Size(400, 243);
            this.Controls.Add(this.EnRu);
            this.Controls.Add(this.Music);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Accept);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.Hello);
            this.Controls.Add(this.userControl11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Label Hello;
        private System.Windows.Forms.Button Accept;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.TextBox textBox;
        private UserControl1 userControl11;
        private System.Windows.Forms.Button Music;
        private System.Windows.Forms.Button EnRu;
        private System.Windows.Forms.Timer ChangeButton;
    }
}