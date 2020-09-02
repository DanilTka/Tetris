namespace Tetris_
{
    partial class UserControl1
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Level = new System.Windows.Forms.Button();
            this.MeetHello = new System.Windows.Forms.Label();
            this.Difficulty = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.Easy = new System.Windows.Forms.Button();
            this.Medium = new System.Windows.Forms.Button();
            this.Hard = new System.Windows.Forms.Button();
            this.Beach = new System.Windows.Forms.Button();
            this.Jungle = new System.Windows.Forms.Button();
            this.Volcano = new System.Windows.Forms.Button();
            this.Tips = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.Record = new System.Windows.Forms.Label();
            this.Control_Keys = new System.Windows.Forms.Button();
            this.Load_Pic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Load_Pic)).BeginInit();
            this.SuspendLayout();
            // 
            // Level
            // 
            this.Level.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Level.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Level.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Level.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.Level.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Level.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Italic);
            this.Level.Location = new System.Drawing.Point(96, 190);
            this.Level.Name = "Level";
            this.Level.Size = new System.Drawing.Size(246, 47);
            this.Level.TabIndex = 2;
            this.Level.TabStop = false;
            this.Level.Text = "Select Level";
            this.Level.UseVisualStyleBackColor = false;
            this.Level.Click += new System.EventHandler(this.Level_Click);
            // 
            // MeetHello
            // 
            this.MeetHello.BackColor = System.Drawing.Color.Transparent;
            this.MeetHello.Font = new System.Drawing.Font("Arial Narrow", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MeetHello.ForeColor = System.Drawing.Color.PapayaWhip;
            this.MeetHello.Location = new System.Drawing.Point(96, 26);
            this.MeetHello.Name = "MeetHello";
            this.MeetHello.Size = new System.Drawing.Size(246, 78);
            this.MeetHello.TabIndex = 3;
            this.MeetHello.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Difficulty
            // 
            this.Difficulty.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Difficulty.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Difficulty.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Difficulty.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.Difficulty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Difficulty.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Italic);
            this.Difficulty.Location = new System.Drawing.Point(96, 252);
            this.Difficulty.Name = "Difficulty";
            this.Difficulty.Size = new System.Drawing.Size(246, 47);
            this.Difficulty.TabIndex = 3;
            this.Difficulty.TabStop = false;
            this.Difficulty.Text = "Difficulty";
            this.Difficulty.UseVisualStyleBackColor = false;
            this.Difficulty.Click += new System.EventHandler(this.Difficulty_Click);
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Back.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Back.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Back.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Italic);
            this.Back.Location = new System.Drawing.Point(96, 377);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(246, 47);
            this.Back.TabIndex = 4;
            this.Back.TabStop = false;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Visible = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            this.Back.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Back_MouseMove);
            // 
            // Easy
            // 
            this.Easy.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Easy.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Easy.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Easy.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.Easy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Easy.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Italic);
            this.Easy.Location = new System.Drawing.Point(96, 125);
            this.Easy.Name = "Easy";
            this.Easy.Size = new System.Drawing.Size(246, 47);
            this.Easy.TabIndex = 5;
            this.Easy.TabStop = false;
            this.Easy.Text = "Easy";
            this.Easy.UseVisualStyleBackColor = false;
            this.Easy.Click += new System.EventHandler(this.Easy_Click);
            this.Easy.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.Easy.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Easy_MouseDown);
            // 
            // Medium
            // 
            this.Medium.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Medium.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Medium.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Medium.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.Medium.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Medium.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Italic);
            this.Medium.Location = new System.Drawing.Point(96, 190);
            this.Medium.Name = "Medium";
            this.Medium.Size = new System.Drawing.Size(246, 47);
            this.Medium.TabIndex = 6;
            this.Medium.TabStop = false;
            this.Medium.Text = "Medium";
            this.Medium.UseVisualStyleBackColor = false;
            this.Medium.Click += new System.EventHandler(this.Medium_Click);
            this.Medium.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.Medium.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Medium_MouseDown);
            // 
            // Hard
            // 
            this.Hard.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Hard.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Hard.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Hard.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.Hard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Hard.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Italic);
            this.Hard.Location = new System.Drawing.Point(96, 252);
            this.Hard.Name = "Hard";
            this.Hard.Size = new System.Drawing.Size(246, 47);
            this.Hard.TabIndex = 7;
            this.Hard.TabStop = false;
            this.Hard.Text = "Hard";
            this.Hard.UseVisualStyleBackColor = false;
            this.Hard.Click += new System.EventHandler(this.Hard_Click);
            this.Hard.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.Hard.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Hard_MouseDown);
            // 
            // Beach
            // 
            this.Beach.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Beach.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Beach.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Beach.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.Beach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Beach.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Italic);
            this.Beach.Location = new System.Drawing.Point(96, 125);
            this.Beach.Name = "Beach";
            this.Beach.Size = new System.Drawing.Size(246, 47);
            this.Beach.TabIndex = 8;
            this.Beach.TabStop = false;
            this.Beach.Text = "Beach";
            this.Beach.UseVisualStyleBackColor = false;
            this.Beach.Click += new System.EventHandler(this.Beach_Click);
            this.Beach.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.Beach.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Beach_MouseDown);
            // 
            // Jungle
            // 
            this.Jungle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Jungle.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Jungle.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Jungle.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.Jungle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Jungle.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Italic);
            this.Jungle.Location = new System.Drawing.Point(96, 190);
            this.Jungle.Name = "Jungle";
            this.Jungle.Size = new System.Drawing.Size(246, 47);
            this.Jungle.TabIndex = 9;
            this.Jungle.TabStop = false;
            this.Jungle.Text = "Jungle";
            this.Jungle.UseVisualStyleBackColor = false;
            this.Jungle.Click += new System.EventHandler(this.Jungle_Click);
            this.Jungle.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.Jungle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Jungle_MouseDown);
            // 
            // Volcano
            // 
            this.Volcano.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Volcano.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Volcano.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Volcano.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.Volcano.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Volcano.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Italic);
            this.Volcano.Location = new System.Drawing.Point(96, 252);
            this.Volcano.Name = "Volcano";
            this.Volcano.Size = new System.Drawing.Size(246, 47);
            this.Volcano.TabIndex = 10;
            this.Volcano.TabStop = false;
            this.Volcano.Text = "Volcano";
            this.Volcano.UseVisualStyleBackColor = false;
            this.Volcano.Click += new System.EventHandler(this.Volcano_Click);
            this.Volcano.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.Volcano.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Volcano_MouseDown);
            // 
            // Tips
            // 
            this.Tips.BackColor = System.Drawing.Color.PapayaWhip;
            this.Tips.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tips.Location = new System.Drawing.Point(0, 507);
            this.Tips.Name = "Tips";
            this.Tips.Size = new System.Drawing.Size(438, 70);
            this.Tips.TabIndex = 11;
            this.Tips.Visible = false;
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Start.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Start.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Start.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start.Location = new System.Drawing.Point(96, 125);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(246, 47);
            this.Start.TabIndex = 1;
            this.Start.TabStop = false;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Record
            // 
            this.Record.BackColor = System.Drawing.Color.Transparent;
            this.Record.Font = new System.Drawing.Font("Book Antiqua", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Record.Location = new System.Drawing.Point(1, 552);
            this.Record.Name = "Record";
            this.Record.Size = new System.Drawing.Size(182, 25);
            this.Record.TabIndex = 12;
            this.Record.Text = "Your record: 0";
            // 
            // Control_Keys
            // 
            this.Control_Keys.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Control_Keys.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Control_Keys.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Control_Keys.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.Control_Keys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Control_Keys.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Italic);
            this.Control_Keys.Location = new System.Drawing.Point(96, 315);
            this.Control_Keys.Name = "Control_Keys";
            this.Control_Keys.Size = new System.Drawing.Size(246, 47);
            this.Control_Keys.TabIndex = 13;
            this.Control_Keys.TabStop = false;
            this.Control_Keys.Text = "Control keys";
            this.Control_Keys.UseVisualStyleBackColor = false;
            this.Control_Keys.Click += new System.EventHandler(this.Control_Keys_Click);
            // 
            // Load_Pic
            // 
            this.Load_Pic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Load_Pic.Image = global::Tetris_.Properties.Resources.Фон_для_управления;
            this.Load_Pic.Location = new System.Drawing.Point(0, 0);
            this.Load_Pic.Name = "Load_Pic";
            this.Load_Pic.Size = new System.Drawing.Size(438, 577);
            this.Load_Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Load_Pic.TabIndex = 14;
            this.Load_Pic.TabStop = false;
            this.Load_Pic.Visible = false;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackgroundImage = global::Tetris_.Properties.Resources.UserControlBackGround;
            this.Controls.Add(this.Load_Pic);
            this.Controls.Add(this.Control_Keys);
            this.Controls.Add(this.Record);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.MeetHello);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Difficulty);
            this.Controls.Add(this.Level);
            this.Controls.Add(this.Beach);
            this.Controls.Add(this.Easy);
            this.Controls.Add(this.Jungle);
            this.Controls.Add(this.Medium);
            this.Controls.Add(this.Volcano);
            this.Controls.Add(this.Hard);
            this.Controls.Add(this.Tips);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(438, 577);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.UserControl1_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Load_Pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label MeetHello;
        private System.Windows.Forms.Label Tips;
        public System.Windows.Forms.Button Level;
        public System.Windows.Forms.Button Difficulty;
        public System.Windows.Forms.Button Back;
        public System.Windows.Forms.Button Easy;
        public System.Windows.Forms.Button Medium;
        public System.Windows.Forms.Button Hard;
        public System.Windows.Forms.Button Beach;
        public System.Windows.Forms.Button Jungle;
        public System.Windows.Forms.Button Volcano;
        public System.Windows.Forms.Button Start;
        public System.Windows.Forms.Label Record;
        public System.Windows.Forms.Button Control_Keys;
        public System.Windows.Forms.PictureBox Load_Pic;
    }
}
