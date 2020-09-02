namespace Tetris_
{
    partial class MainGameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGameForm));
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.authorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.musicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NextBlockPic = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.TetrisField = new System.Windows.Forms.PictureBox();
            this.MovingTimer = new System.Windows.Forms.Timer(this.components);
            this.FallingTimer = new System.Windows.Forms.Timer(this.components);
            this.ScoreNum = new System.Windows.Forms.Label();
            this.GoalScore = new System.Windows.Forms.Label();
            this.ForNext = new System.Windows.Forms.Label();
            this.ScoreLab = new System.Windows.Forms.Label();
            this.Next = new System.Windows.Forms.Label();
            this.ObstaclesGenerator = new System.Windows.Forms.Timer(this.components);
            this.ChangingBackGround = new System.Windows.Forms.Timer(this.components);
            this.ObstaclesDelete = new System.Windows.Forms.Timer(this.components);
            this.shardsMoving = new System.Windows.Forms.Timer(this.components);
            this.menuToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.authorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.musicStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.PauseBut = new System.Windows.Forms.Integration.ElementHost();
            this.userControl22 = new Tetris_.UserControl2();
            ((System.ComponentModel.ISupportInitialize)(this.NextBlockPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TetrisField)).BeginInit();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // authorToolStripMenuItem
            // 
            this.authorToolStripMenuItem.Name = "authorToolStripMenuItem";
            this.authorToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // musicToolStripMenuItem
            // 
            this.musicToolStripMenuItem.Name = "musicToolStripMenuItem";
            this.musicToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // NextBlockPic
            // 
            this.NextBlockPic.BackColor = System.Drawing.Color.Transparent;
            this.NextBlockPic.Cursor = System.Windows.Forms.Cursors.Default;
            this.NextBlockPic.Location = new System.Drawing.Point(227, 179);
            this.NextBlockPic.Name = "NextBlockPic";
            this.NextBlockPic.Size = new System.Drawing.Size(190, 164);
            this.NextBlockPic.TabIndex = 5;
            this.NextBlockPic.TabStop = false;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Moccasin;
            this.button1.FlatAppearance.BorderSize = 3;
            this.button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Peru;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("MV Boli", 21.75F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(227, 427);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 75);
            this.button1.TabIndex = 6;
            this.button1.TabStop = false;
            this.button1.Text = "0";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Enabled = false;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Aquamarine;
            this.button2.FlatAppearance.BorderSize = 3;
            this.button2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Peru;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("MV Boli", 21.75F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(227, 349);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(190, 75);
            this.button2.TabIndex = 7;
            this.button2.TabStop = false;
            this.button2.Text = "Score";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Enabled = false;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.button3.FlatAppearance.BorderSize = 3;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("MV Boli", 21.75F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(227, 101);
            this.button3.MaximumSize = new System.Drawing.Size(190, 75);
            this.button3.MinimumSize = new System.Drawing.Size(190, 75);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(190, 75);
            this.button3.TabIndex = 8;
            this.button3.TabStop = false;
            this.button3.Text = "Next";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // TetrisField
            // 
            this.TetrisField.BackColor = System.Drawing.Color.Transparent;
            this.TetrisField.Cursor = System.Windows.Forms.Cursors.Default;
            this.TetrisField.Location = new System.Drawing.Point(21, 101);
            this.TetrisField.Name = "TetrisField";
            this.TetrisField.Size = new System.Drawing.Size(200, 500);
            this.TetrisField.TabIndex = 9;
            this.TetrisField.TabStop = false;
            this.TetrisField.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox2_Paint);
            // 
            // MovingTimer
            // 
            this.MovingTimer.Enabled = true;
            this.MovingTimer.Interval = 40;
            this.MovingTimer.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // FallingTimer
            // 
            this.FallingTimer.Enabled = true;
            this.FallingTimer.Interval = 800;
            this.FallingTimer.Tick += new System.EventHandler(this.Timer3_Tick);
            // 
            // ScoreNum
            // 
            this.ScoreNum.BackColor = System.Drawing.Color.Transparent;
            this.ScoreNum.Font = new System.Drawing.Font("Segoe Print", 20.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreNum.Location = new System.Drawing.Point(230, 430);
            this.ScoreNum.Name = "ScoreNum";
            this.ScoreNum.Size = new System.Drawing.Size(184, 69);
            this.ScoreNum.TabIndex = 13;
            this.ScoreNum.Text = "0";
            this.ScoreNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GoalScore
            // 
            this.GoalScore.BackColor = System.Drawing.Color.Transparent;
            this.GoalScore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GoalScore.Font = new System.Drawing.Font("MV Boli", 16.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoalScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(30)))), ((int)(((byte)(0)))));
            this.GoalScore.Image = global::Tetris_.Properties.Resources.transparency;
            this.GoalScore.Location = new System.Drawing.Point(271, 37);
            this.GoalScore.Name = "GoalScore";
            this.GoalScore.Size = new System.Drawing.Size(146, 58);
            this.GoalScore.TabIndex = 14;
            this.GoalScore.Text = " 8000";
            this.GoalScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ForNext
            // 
            this.ForNext.BackColor = System.Drawing.Color.Transparent;
            this.ForNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ForNext.Font = new System.Drawing.Font("Segoe Print", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForNext.ForeColor = System.Drawing.Color.NavajoWhite;
            this.ForNext.Location = new System.Drawing.Point(0, 30);
            this.ForNext.Name = "ForNext";
            this.ForNext.Size = new System.Drawing.Size(285, 74);
            this.ForNext.TabIndex = 15;
            this.ForNext.Text = "Scores for next level:";
            this.ForNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScoreLab
            // 
            this.ScoreLab.BackColor = System.Drawing.Color.Transparent;
            this.ScoreLab.Font = new System.Drawing.Font("Segoe Print", 20.75F, System.Drawing.FontStyle.Bold);
            this.ScoreLab.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ScoreLab.Location = new System.Drawing.Point(230, 352);
            this.ScoreLab.Name = "ScoreLab";
            this.ScoreLab.Size = new System.Drawing.Size(184, 69);
            this.ScoreLab.TabIndex = 12;
            this.ScoreLab.Text = "Score";
            this.ScoreLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Next
            // 
            this.Next.BackColor = System.Drawing.Color.Transparent;
            this.Next.Font = new System.Drawing.Font("Segoe Print", 21.75F, System.Drawing.FontStyle.Bold);
            this.Next.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Next.Location = new System.Drawing.Point(230, 104);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(184, 69);
            this.Next.TabIndex = 11;
            this.Next.Text = "Next";
            this.Next.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ObstaclesGenerator
            // 
            this.ObstaclesGenerator.Interval = 10000;
            this.ObstaclesGenerator.Tick += new System.EventHandler(this.ObstaclesGenerator_Tick);
            // 
            // ChangingBackGround
            // 
            this.ChangingBackGround.Enabled = true;
            this.ChangingBackGround.Interval = 50000;
            this.ChangingBackGround.Tick += new System.EventHandler(this.ChangingBackGround_Tick);
            // 
            // ObstaclesDelete
            // 
            this.ObstaclesDelete.Interval = 10000;
            this.ObstaclesDelete.Tick += new System.EventHandler(this.ObstaclesDelete_Tick);
            // 
            // shardsMoving
            // 
            this.shardsMoving.Interval = 120;
            // 
            // menuToolStripMenuItem1
            // 
            this.menuToolStripMenuItem1.Name = "menuToolStripMenuItem1";
            this.menuToolStripMenuItem1.Size = new System.Drawing.Size(50, 26);
            this.menuToolStripMenuItem1.Text = "Menu";
            // 
            // MenuStrip
            // 
            this.MenuStrip.AutoSize = false;
            this.MenuStrip.BackColor = System.Drawing.Color.White;
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem2,
            this.exitToolStripMenuItem1,
            this.musicStripMenuItem1,
            this.pauseStripMenuItem1});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(438, 30);
            this.MenuStrip.TabIndex = 17;
            this.MenuStrip.Text = "menuStrip";
            this.MenuStrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseDown);
            // 
            // menuToolStripMenuItem2
            // 
            this.menuToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem1,
            this.authorToolStripMenuItem1,
            this.mainToolStripMenuItem});
            this.menuToolStripMenuItem2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuToolStripMenuItem2.Name = "menuToolStripMenuItem2";
            this.menuToolStripMenuItem2.Size = new System.Drawing.Size(57, 26);
            this.menuToolStripMenuItem2.Text = "Menu";
            // 
            // newGameToolStripMenuItem1
            // 
            this.newGameToolStripMenuItem1.Name = "newGameToolStripMenuItem1";
            this.newGameToolStripMenuItem1.Size = new System.Drawing.Size(145, 24);
            this.newGameToolStripMenuItem1.Text = "New Game";
            this.newGameToolStripMenuItem1.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // authorToolStripMenuItem1
            // 
            this.authorToolStripMenuItem1.Name = "authorToolStripMenuItem1";
            this.authorToolStripMenuItem1.Size = new System.Drawing.Size(145, 24);
            this.authorToolStripMenuItem1.Text = "Author";
            this.authorToolStripMenuItem1.Click += new System.EventHandler(this.authorToolStripMenuItem_Click);
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(145, 24);
            this.mainToolStripMenuItem.Text = "Main";
            this.mainToolStripMenuItem.Click += new System.EventHandler(this.menuToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.exitToolStripMenuItem1.AutoSize = false;
            this.exitToolStripMenuItem1.BackColor = System.Drawing.Color.Transparent;
            this.exitToolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exitToolStripMenuItem1.Image = global::Tetris_.Properties.Resources.Крест;
            this.exitToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(35, 30);
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // musicStripMenuItem1
            // 
            this.musicStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.musicStripMenuItem1.AutoSize = false;
            this.musicStripMenuItem1.BackColor = System.Drawing.Color.Transparent;
            this.musicStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.musicStripMenuItem1.Image = global::Tetris_.Properties.Resources.ВКЛЛ;
            this.musicStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.musicStripMenuItem1.Name = "musicStripMenuItem1";
            this.musicStripMenuItem1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.musicStripMenuItem1.Size = new System.Drawing.Size(35, 30);
            this.musicStripMenuItem1.Click += new System.EventHandler(this.musicToolStripMenuItem_Click);
            this.musicStripMenuItem1.MouseEnter += new System.EventHandler(this.musicToolStripMenuItem_MouseEnter);
            this.musicStripMenuItem1.MouseLeave += new System.EventHandler(this.musicToolStripMenuItem_MouseLeave);
            // 
            // pauseStripMenuItem1
            // 
            this.pauseStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.pauseStripMenuItem1.AutoSize = false;
            this.pauseStripMenuItem1.BackColor = System.Drawing.Color.Transparent;
            this.pauseStripMenuItem1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pauseStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pauseStripMenuItem1.Image = global::Tetris_.Properties.Resources.Pause;
            this.pauseStripMenuItem1.Name = "pauseStripMenuItem1";
            this.pauseStripMenuItem1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pauseStripMenuItem1.Size = new System.Drawing.Size(35, 30);
            this.pauseStripMenuItem1.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            this.pauseStripMenuItem1.MouseEnter += new System.EventHandler(this.pauseToolStripMenuItem_MouseEnter);
            this.pauseStripMenuItem1.MouseLeave += new System.EventHandler(this.pauseToolStripMenuItem_MouseLeave);
            // 
            // PauseBut
            // 
            this.PauseBut.BackColor = System.Drawing.Color.Transparent;
            this.PauseBut.BackgroundImage = global::Tetris_.Properties.Resources.Pause2;
            this.PauseBut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PauseBut.Location = new System.Drawing.Point(169, 163);
            this.PauseBut.Name = "PauseBut";
            this.PauseBut.Size = new System.Drawing.Size(100, 100);
            this.PauseBut.TabIndex = 18;
            this.PauseBut.Text = "elementHost1";
            this.PauseBut.Visible = false;
            this.PauseBut.Child = this.userControl22;
            // 
            // MainGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Tetris_.Properties.Resources.Пляж1;
            this.ClientSize = new System.Drawing.Size(438, 607);
            this.Controls.Add(this.PauseBut);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.GoalScore);
            this.Controls.Add(this.TetrisField);
            this.Controls.Add(this.ScoreNum);
            this.Controls.Add(this.ScoreLab);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.NextBlockPic);
            this.Controls.Add(this.ForNext);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.MenuStrip;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(438, 650);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(438, 569);
            this.Name = "MainGameForm";
            this.Opacity = 0.98D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainGameForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.NextBlockPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TetrisField)).EndInit();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.PictureBox NextBlockPic;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox TetrisField;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem authorToolStripMenuItem;
        private System.Windows.Forms.Label GoalScore;
        private System.Windows.Forms.Label ForNext;
        private System.Windows.Forms.Label ScoreLab;
        private System.Windows.Forms.Label Next;
        private System.Windows.Forms.Timer MovingTimer;
        private System.Windows.Forms.Timer FallingTimer;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem musicToolStripMenuItem;
        private System.Windows.Forms.Timer ObstaclesGenerator;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.Timer ChangingBackGround;
        private System.Windows.Forms.Timer ObstaclesDelete;
        private System.Windows.Forms.Timer shardsMoving;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem1;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem authorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem musicStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pauseStripMenuItem1;
        private System.Windows.Forms.Integration.ElementHost PauseBut;
        private UserControl2 userControl22;
        public System.Windows.Forms.Label ScoreNum;
    }
}

