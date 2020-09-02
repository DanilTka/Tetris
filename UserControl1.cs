using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris_
{
    public partial class UserControl1 : UserControl
    {
        public string lev { get; set; }
        public string dif = "Easy";
        public ToolTip tip = new ToolTip();
        static public int level { get; set; }
        static public int difficulty { get; set; }
        public UserControl1()
        {
            InitializeComponent();
            if (MenuForm.first)
            {
                level = 1;
                difficulty = 1;
            }
            if (MenuForm.enru)
            {
                lev = "Пляж";
                tip.SetToolTip(Start, $"Выбран уровень: {lev}, Уровень сложности: {dif}.");
                Record.Text = $"Ваш рекорд: {Account.ScoreRecord}";
            }
            else
            {
                lev = "Beach";
                tip.SetToolTip(Start, $"Level: {lev}, Difficulty: {dif}.");
                Record.Text = $"Your record: {Account.ScoreRecord}";
            }
            LevelDif();
        }
        public void LevelDif()
        {
            if (level == 1)
            {
                if (MenuForm.enru)
                {
                    lev = "Пляж";
                }
                else { lev = "Beach"; }
            }
            if (level == 2)
            {
                if (MenuForm.enru)
                {
                    lev = "Джунгли";
                }
                else
                {
                    lev = "Jungle";
                }
            }
            if (level == 3)
            {
                if (MenuForm.enru)
                {
                    lev = "Вулкан";
                }
                else
                {
                    lev = "Volcano";
                }
            }
            if (difficulty == 1)
            {
                if (MenuForm.enru)
                {
                    dif = "Легко";
                }
                else
                {
                    dif = "Easy";
                }
            }
            if (difficulty == 2)
            {
                if (MenuForm.enru)
                {
                    dif = "Нормально";
                }
                else
                {
                    dif = "Medium";
                }
            }
            if (difficulty == 3)
            {
                if (MenuForm.enru)
                {
                    dif = "Профи";
                }
                else
                {
                    dif = "Hard";
                }
            }
            if (MenuForm.enru)
            {
                tip.SetToolTip(Start, $"Выбран уровень: {lev}, Уровень сложности: {dif}.");
            }
            else
            {
                tip.SetToolTip(Start, $"Level: {lev}, Difficulty: {dif}.");
            }
        }

        #region Clicks
        private void Level_Click(object sender, EventArgs e)
        {
            Beach.BringToFront();
            Jungle.BringToFront();
            Volcano.BringToFront();
            Control_Keys.Visible = false;
            Back.Location = new Point(96, 315);
            Back.Visible = true;
            Tips.BringToFront();
            Medium.SendToBack();
            Hard.SendToBack();
            Easy.Enabled = false;
            Medium.Enabled = false;
            Hard.Enabled = false;
            Beach.Enabled = true;
            Jungle.Enabled = true;
            Volcano.Enabled = true;
        }

        private void Difficulty_Click(object sender, EventArgs e)
        {
            Easy.BringToFront();
            Medium.BringToFront();
            Hard.BringToFront();
            Control_Keys.Visible = false;
            Back.Location = new Point(96, 315);
            Back.Visible = true;
            Tips.BringToFront();
            Easy.Enabled = true;
            Medium.Enabled = true;
            Hard.Enabled = true;
            Beach.Enabled = false;
            Jungle.Enabled = false;
            Volcano.Enabled = false;
        }
        public static bool changeSize = false;
        private void Control_Keys_Click(object sender, EventArgs e)
        {
            Load_Frame(true, 800);
            this.Size = new Size(560, 577);
            Beach.Visible = false;
            Easy.Visible = false;
            Medium.Visible = false;
            Hard.Visible = false;
            Jungle.Visible = false;
            Volcano.Visible = false;
            Control_Keys.Visible = false;
            //Start.Visible = false;
            Start.Hide();
            Level.Visible = false;
            Difficulty.Visible = false;
            Back.Visible = true;
            Back.Location = new Point(157, 457);
            BackgroundImage = Properties.Resources.Фон_для_управления;
            MenuForm.first = true;
            changeSize = true;
            MeetHello.Visible = false;
            Record.Visible = false;
        }

        async public void Load_Frame(bool big, int delayTime)
        {
            Load_Pic.BringToFront();
            Load_Pic.Visible = true;
            if (big)
            {
                Load_Pic.Image = Properties.Resources._560x577Load;
            }
            else
            {
                Load_Pic.Image = Properties.Resources.Load;
            }
            await Task.Delay(delayTime);
            Load_Pic.Visible = false;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            if (this.Size == new Size(560, 577))
            {
                Load_Frame(true, 900);
                ToStartWindow();
                Start.Visible = true;
                Beach.Visible = true;
                Easy.Visible = true;
                Level.Visible = true;
                Difficulty.Visible = true;
                Medium.Visible = true;
                Hard.Visible = true;
                Jungle.Visible = true;
                Volcano.Visible = true;
                MeetHello.Visible = true;
                Record.Visible = true;
                changeSize = false;
                MenuForm.first = true;
                if (UserControl1.level == 2)
                {
                    BackgroundImage = Properties.Resources.kartinki_me_763;
                }
                else if (UserControl1.level == 3)
                {
                    BackgroundImage = Properties.Resources._438Х577;
                }
                else
                {
                    BackgroundImage = Properties.Resources.UserControlBackGround;
                }
                this.Size = new Size(438, 577);
            }
            else
            {
            ToStartWindow();
            }
        }
        private void Beach_Click(object sender, EventArgs e)
        {
            ToStartWindow();
            level = 1;
            LevelDif();
            #region Design
            BackgroundImage = Properties.Resources.UserControlBackGround;
            Start.BackColor = SystemColors.GradientInactiveCaption;
            Start.FlatAppearance.BorderColor = SystemColors.GradientInactiveCaption;
            Start.FlatAppearance.MouseDownBackColor = SystemColors.GradientActiveCaption;
            Start.FlatAppearance.MouseOverBackColor = SystemColors.Control;
            Level.BackColor = SystemColors.GradientInactiveCaption;
            Level.FlatAppearance.BorderColor = SystemColors.GradientInactiveCaption;
            Level.FlatAppearance.MouseDownBackColor = SystemColors.GradientActiveCaption;
            Level.FlatAppearance.MouseOverBackColor = SystemColors.Control;
            Difficulty.BackColor = SystemColors.GradientInactiveCaption;
            Difficulty.FlatAppearance.BorderColor = SystemColors.GradientInactiveCaption;
            Difficulty.FlatAppearance.MouseDownBackColor = SystemColors.GradientActiveCaption;
            Difficulty.FlatAppearance.MouseOverBackColor = SystemColors.Control;
            Control_Keys.BackColor = SystemColors.GradientInactiveCaption;
            Control_Keys.FlatAppearance.BorderColor = SystemColors.GradientInactiveCaption;
            Control_Keys.FlatAppearance.MouseDownBackColor = SystemColors.GradientActiveCaption;
            Control_Keys.FlatAppearance.MouseOverBackColor = SystemColors.Control;
            Tips.BackColor = SystemColors.GradientInactiveCaption;
            MeetHello.ForeColor = Color.PapayaWhip;
            Record.ForeColor = SystemColors.ControlText;
            Jungle.BackColor = SystemColors.GradientInactiveCaption;
            Jungle.FlatAppearance.BorderColor = SystemColors.GradientInactiveCaption;
            Jungle.FlatAppearance.MouseDownBackColor = SystemColors.GradientActiveCaption;
            Jungle.FlatAppearance.MouseOverBackColor = SystemColors.Control;
            Beach.BackColor = SystemColors.GradientInactiveCaption;
            Beach.FlatAppearance.BorderColor = SystemColors.GradientInactiveCaption;
            Beach.FlatAppearance.MouseDownBackColor = SystemColors.GradientActiveCaption;
            Beach.FlatAppearance.MouseOverBackColor = SystemColors.Control;
            Volcano.BackColor = SystemColors.GradientInactiveCaption;
            Volcano.FlatAppearance.BorderColor = SystemColors.GradientInactiveCaption;
            Volcano.FlatAppearance.MouseDownBackColor = SystemColors.GradientActiveCaption;
            Volcano.FlatAppearance.MouseOverBackColor = SystemColors.Control;
            Easy.BackColor = SystemColors.GradientInactiveCaption;
            Easy.FlatAppearance.BorderColor = SystemColors.GradientInactiveCaption;
            Easy.FlatAppearance.MouseDownBackColor = SystemColors.GradientActiveCaption;
            Easy.FlatAppearance.MouseOverBackColor = SystemColors.Control;
            Medium.BackColor = SystemColors.GradientInactiveCaption;
            Medium.FlatAppearance.BorderColor = SystemColors.GradientInactiveCaption;
            Medium.FlatAppearance.MouseDownBackColor = SystemColors.GradientActiveCaption;
            Medium.FlatAppearance.MouseOverBackColor = SystemColors.Control;
            Hard.BackColor = SystemColors.GradientInactiveCaption;
            Hard.FlatAppearance.BorderColor = SystemColors.GradientInactiveCaption;
            Hard.FlatAppearance.MouseDownBackColor = SystemColors.GradientActiveCaption;
            Hard.FlatAppearance.MouseOverBackColor = SystemColors.Control;
            Back.BackColor = SystemColors.GradientInactiveCaption;
            Back.FlatAppearance.BorderColor = SystemColors.GradientInactiveCaption;
            Back.FlatAppearance.MouseDownBackColor = SystemColors.GradientActiveCaption;
            Back.FlatAppearance.MouseOverBackColor = SystemColors.Control;
            #endregion
        }
        private void Start_Click(object sender, EventArgs e)
        {
            MainGameForm ifrm = new MainGameForm();
            ifrm.StartPosition = FormStartPosition.CenterScreen;
            ifrm.Show();
            MenuForm.close = true;
        }
        private void Easy_Click(object sender, EventArgs e)
        {
            ToStartWindow();
            difficulty = 1;
            LevelDif();
        }

        private void Medium_Click(object sender, EventArgs e)
        {
            ToStartWindow();
            difficulty = 2;
            LevelDif();
        }

        private void Hard_Click(object sender, EventArgs e)
        {
            ToStartWindow();
            difficulty = 3;
            LevelDif();
        }
        private void Volcano_Click(object sender, EventArgs e)
        {
            if (Account.ScoreRecord < 13000)
            {
                return;
            }
            ToStartWindow();
            level = 3;
            LevelDif();
            #region Design
            BackgroundImage = Properties.Resources._438Х577;
            Start.BackColor = Color.DarkRed;
            Start.FlatAppearance.BorderColor = Color.Maroon;
            Start.FlatAppearance.MouseDownBackColor = Color.Firebrick;
            Start.FlatAppearance.MouseOverBackColor = SystemColors.Info;
            Level.BackColor = Color.DarkRed;
            Level.FlatAppearance.BorderColor = Color.Maroon;
            Level.FlatAppearance.MouseDownBackColor = Color.Firebrick;
            Level.FlatAppearance.MouseOverBackColor = SystemColors.Info;
            Difficulty.BackColor = Color.DarkRed;
            Difficulty.FlatAppearance.BorderColor = Color.Maroon;
            Difficulty.FlatAppearance.MouseDownBackColor = Color.Firebrick;
            Difficulty.FlatAppearance.MouseOverBackColor = SystemColors.Info;
            Control_Keys.BackColor = Color.DarkRed;
            Control_Keys.FlatAppearance.BorderColor = Color.Maroon;
            Control_Keys.FlatAppearance.MouseDownBackColor = Color.Firebrick;
            Control_Keys.FlatAppearance.MouseOverBackColor = SystemColors.Info;
            Tips.BackColor = SystemColors.Info;
            MeetHello.ForeColor = SystemColors.Info;
            Record.ForeColor = SystemColors.Info;
            Jungle.BackColor = Color.DarkRed;
            Jungle.FlatAppearance.BorderColor = Color.Maroon;
            Jungle.FlatAppearance.MouseDownBackColor = Color.Firebrick;
            Jungle.FlatAppearance.MouseOverBackColor = SystemColors.Info;
            Beach.BackColor = Color.DarkRed;
            Beach.FlatAppearance.BorderColor = Color.Maroon;
            Beach.FlatAppearance.MouseDownBackColor = Color.Firebrick;
            Beach.FlatAppearance.MouseOverBackColor = SystemColors.Info;
            Volcano.BackColor = Color.DarkRed;
            Volcano.FlatAppearance.BorderColor = Color.Maroon;
            Volcano.FlatAppearance.MouseDownBackColor = Color.Firebrick;
            Volcano.FlatAppearance.MouseOverBackColor = SystemColors.Info;
            Easy.BackColor = Color.DarkRed;
            Easy.FlatAppearance.BorderColor = Color.Maroon;
            Easy.FlatAppearance.MouseDownBackColor = Color.Firebrick;
            Easy.FlatAppearance.MouseOverBackColor = SystemColors.Info;
            Medium.BackColor = Color.DarkRed;
            Medium.FlatAppearance.BorderColor = Color.Maroon;
            Medium.FlatAppearance.MouseDownBackColor = Color.Firebrick;
            Medium.FlatAppearance.MouseOverBackColor = SystemColors.Info;
            Hard.BackColor = Color.DarkRed;
            Hard.FlatAppearance.BorderColor = Color.Maroon;
            Hard.FlatAppearance.MouseDownBackColor = Color.Firebrick;
            Hard.FlatAppearance.MouseOverBackColor = SystemColors.Info;
            Back.BackColor = Color.DarkRed;
            Back.FlatAppearance.BorderColor = Color.Maroon;
            Back.FlatAppearance.MouseDownBackColor = Color.Firebrick;
            Back.FlatAppearance.MouseOverBackColor = SystemColors.Info;
            #endregion
        }

        private void Jungle_Click(object sender, EventArgs e)
        {
            if (Account.ScoreRecord < 10000)
            {
                return;
            }
            ToStartWindow();
            level = 2;
            LevelDif();
            #region Design
            BackgroundImage = Properties.Resources.kartinki_me_763;
            Start.BackColor = Color.SeaGreen;
            Start.FlatAppearance.BorderColor = Color.SeaGreen;
            Start.FlatAppearance.MouseDownBackColor = Color.ForestGreen;
            Start.FlatAppearance.MouseOverBackColor = Color.MediumSeaGreen;
            Level.BackColor = Color.SeaGreen;
            Level.FlatAppearance.BorderColor = Color.SeaGreen;
            Level.FlatAppearance.MouseDownBackColor = Color.ForestGreen;
            Level.FlatAppearance.MouseOverBackColor = Color.MediumSeaGreen;
            Difficulty.BackColor = Color.SeaGreen;
            Difficulty.FlatAppearance.BorderColor = Color.SeaGreen;
            Difficulty.FlatAppearance.MouseDownBackColor = Color.ForestGreen;
            Difficulty.FlatAppearance.MouseOverBackColor = Color.MediumSeaGreen;
            Control_Keys.BackColor = Color.SeaGreen;
            Control_Keys.FlatAppearance.BorderColor = Color.SeaGreen;
            Control_Keys.FlatAppearance.MouseDownBackColor = Color.ForestGreen;
            Control_Keys.FlatAppearance.MouseOverBackColor = Color.MediumSeaGreen;
            Tips.BackColor = Color.ForestGreen;
            MeetHello.ForeColor = Color.ForestGreen;
            Record.ForeColor = Color.MediumSeaGreen;
            Jungle.BackColor = Color.SeaGreen;
            Jungle.FlatAppearance.BorderColor = Color.SeaGreen;
            Jungle.FlatAppearance.MouseDownBackColor = Color.ForestGreen;
            Jungle.FlatAppearance.MouseOverBackColor = Color.MediumSeaGreen;
            Beach.BackColor = Color.SeaGreen;
            Beach.FlatAppearance.BorderColor = Color.SeaGreen;
            Beach.FlatAppearance.MouseDownBackColor = Color.ForestGreen;
            Beach.FlatAppearance.MouseOverBackColor = Color.MediumSeaGreen;
            Volcano.BackColor = Color.SeaGreen;
            Volcano.FlatAppearance.BorderColor = Color.SeaGreen;
            Volcano.FlatAppearance.MouseDownBackColor = Color.ForestGreen;
            Volcano.FlatAppearance.MouseOverBackColor = Color.MediumSeaGreen;
            Easy.BackColor = Color.SeaGreen;
            Easy.FlatAppearance.BorderColor = Color.SeaGreen;
            Easy.FlatAppearance.MouseDownBackColor = Color.ForestGreen;
            Easy.FlatAppearance.MouseOverBackColor = Color.MediumSeaGreen;
            Medium.BackColor = Color.SeaGreen;
            Medium.FlatAppearance.BorderColor = Color.SeaGreen;
            Medium.FlatAppearance.MouseDownBackColor = Color.ForestGreen;
            Medium.FlatAppearance.MouseOverBackColor = Color.MediumSeaGreen;
            Hard.BackColor = Color.SeaGreen;
            Hard.FlatAppearance.BorderColor = Color.SeaGreen;
            Hard.FlatAppearance.MouseDownBackColor = Color.ForestGreen;
            Hard.FlatAppearance.MouseOverBackColor = Color.MediumSeaGreen;
            Back.BackColor = Color.SeaGreen;
            Back.FlatAppearance.BorderColor = Color.SeaGreen;
            Back.FlatAppearance.MouseDownBackColor = Color.ForestGreen;
            Back.FlatAppearance.MouseOverBackColor = Color.MediumSeaGreen;
            #endregion
        }
        #endregion
        void ToStartWindow()
        {
            Start.BringToFront();
            Level.BringToFront();
            Difficulty.BringToFront();
            Load_Pic.BringToFront();
            Easy.SendToBack();
            Medium.SendToBack();
            Hard.SendToBack();
            Beach.SendToBack();
            Jungle.SendToBack();
            Volcano.SendToBack();
            Control_Keys.Visible = true;
            Back.Location = new Point(96, 377);
            Easy.Enabled = false;
            Medium.Enabled = false;
            Hard.Enabled = false;
            Beach.Enabled = false;
            Jungle.Enabled = false;
            Volcano.Enabled = false;
            Back.Visible = false;
            Tips.Visible = false;
        }

        #region MouseMove
        private void Easy_MouseDown(object sender, MouseEventArgs e)
        {
            Tips.Visible = true;
            if (MenuForm.enru)
            {
                Tips.Text = "Сетка поля, тени фигур - включены. Отключена генерация препятствий на поле. Очки х1.";
            }
            else
            {
                Tips.Text = "Grid, shadow of shapes - included. Disabled generation of obstacles on the field. Scores x1.";
            }
        }

        private void Medium_MouseDown(object sender, MouseEventArgs e)
        {
            Tips.Visible = true;
            if (MenuForm.enru)
            {
                Tips.Text = "Отключена сетка поля. Начальная скорость падения фигур немного увеличена. Очки х1.5.";
            }
            else
            {
                Tips.Text = "Grid is disabled. The initial speed of falling pieces is slightly increased. Scores x1.5.";
            }
        }

        private void Hard_MouseDown(object sender, MouseEventArgs e)
        {
            Tips.Visible = true;
            if (MenuForm.enru)
            {
                Tips.Text = "Сетка, тени фигур - отключены. Случайно генеруются препятствия на поле. Начальная скорость падения фигур значительно увеличена. Очки х2.5.";
            }
            else
            {
                Tips.Text = "Grid, shadow shapes - disabled. Randomly generate obstacles on the field. The initial speed of falling pieces is significantly increased. Scores x2.5.";
            }
        }
        private void Back_MouseMove(object sender, MouseEventArgs e)
        {
            Tips.Visible = false;
        }
        private void Jungle_MouseDown(object sender, MouseEventArgs e)
        {
            Tips.Visible = true;
            if (Account.ScoreRecord < 10000)
            {
                if (MenuForm.enru)
                {
                    Tips.Text = "Чтобы открыть этот уровень необходимо 10,000 очков.";
                }
                else
                {
                    Tips.Text = "To open this level you need 10,000 points.";
                }
            }
            else if (Account.ScoreRecord >= 10000)
            {
                if (MenuForm.enru)
                {
                    Tips.Text = "Уровень 2. Джунгли.";
                }
                else
                {
                    Tips.Text = "Level 2. Jungle.";
                }
            }
        }
        private void Volcano_MouseDown(object sender, MouseEventArgs e)
        {
            Tips.Visible = true;
            if (Account.ScoreRecord < 13000)
            {
                if (MenuForm.enru)
                {
                    Tips.Text = "Чтобы открыть этот уровень необходимо 13,000 очков.";
                }
                else
                {
                    Tips.Text = "To open this level you need 13,000 points.";
                }
            }
            else if (Account.ScoreRecord >= 13000)
            {
                if (MenuForm.enru)
                {
                    Tips.Text = "Уровень 3. Вулкан.";
                }
                else
                {
                    Tips.Text = "Level 3. Volcano.";
                }
            }
        }
        private void Beach_MouseDown(object sender, MouseEventArgs e)
        {
            Tips.Visible = true;
            if (MenuForm.enru)
            {
                Tips.Text = "Уровень 1. Песочный берег.";
            }
            else
            {
                Tips.Text = "Level 1. Sandy beach.";
            }
        }

        #endregion
        private void MouseLeave(object sender, EventArgs e)
        {
            Tips.Visible = false;
        }

        private void UserControl1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
                Start_Click(sender, new EventArgs());
        }
    }
}
