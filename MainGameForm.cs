using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Tetris_
{
    public partial class MainGameForm : Form
    {
        #region Main variables

        public static readonly WindowsMediaPlayer player = new WindowsMediaPlayer();
        readonly WindowsMediaPlayer player2 = new WindowsMediaPlayer();
        readonly WindowsMediaPlayer player3 = new WindowsMediaPlayer();
        bool bottom = false;
        int value = 0, count = 0, valuee = 0, lenght = 0;
        static public int Score { get; set; }
        public bool Gameover { get; set; }
        double x = 1;
        public bool End { get; set; }
        Random rnd = new Random();
        bool grid = true;
        bool shadowON = true;
        #endregion
        public MainGameForm()
        {
            InitializeComponent();
            l.ForeColor = Color.Blue;
            WhatsIsTheLevel();
            //language
            if (MenuForm.enru)
            {
                fileToolStripMenuItem.Text = "Меню";
                newGameToolStripMenuItem.Text = "Новая игра";
                authorToolStripMenuItem.Text = "Автор";
                menuToolStripMenuItem.Text = "Главное меню";
                ForNext.Text = "Для следующего уровня:";
                ForNext.Font = new Font(ForNext.Font.Name, 15, ForNext.Font.Style);
                Next.Text = "Следующая фигура";
                Next.Font = new Font(Next.Font.Name, 14, Next.Font.Style);
                ScoreLab.Text = "Счет";
            }
            else
            {
                fileToolStripMenuItem.Text = "Menu";
                newGameToolStripMenuItem.Text = "New Game";
                authorToolStripMenuItem.Text = "Author";
                menuToolStripMenuItem.Text = "Main";
                ForNext.Text = "Scores for next level:";
                ForNext.Font = new Font(ForNext.Font.Name, 17, ForNext.Font.Style);
                Next.Text = "Next";
                Next.Font = new Font(Next.Font.Name, 22, Next.Font.Style);
                ScoreLab.Text = "Score";
            }
            //Random value for pictureboxes (value - picturebox2, valuee - picturebox2)
            value = rnd.Next(0, 6);
            valuee = rnd.Next(0, 6);
            //Music
            if (!MenuForm.music)
            {
                musicStripMenuItem1.Image = Properties.Resources.ВЫКЛЛ;
            }
            else
            {
                musicStripMenuItem1.Image = Properties.Resources.ВКЛЛ;
            }
            player2.settings.volume = 28;
            player3.settings.volume = 24;
            //Initial state of KeyDown
            //label (очки)
            l.Parent = TetrisField;
            l.BackColor = Color.Transparent;
            l.AutoSize = true;
            Controls.Add(l);
            l.Font = new Font("MV_Boli", 14, FontStyle.Bold);
            //label (HowCoolAreYou)
            cooler.BackColor = Color.Transparent;
            cooler.Dock = DockStyle.Fill;
            cooler.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(cooler);
        }

        #region Render
        public void WhatsIsTheLevel()
        {
            PicLevelTexture();
            if (UserControl1.level == 2)
            {
                BackgroundImage = Properties.Resources._438х607Jungle;
                ForNext.ForeColor = Color.White;
                button1.FlatAppearance.BorderColor = Color.LimeGreen;
                button2.FlatAppearance.BorderColor = Color.LimeGreen;
                button3.FlatAppearance.BorderColor = Color.LimeGreen;
                GoalScore.ForeColor = Color.FromArgb(0, 31, 0);
                GoalScore.Font = new Font(GoalScore.Font.Name, 19, GoalScore.Font.Style);
                GoalScore.Image = Properties.Resources.PalmLeaf3;
                GoalScore.Text = "13000";
                Next.ForeColor = Color.Linen;
                ScoreLab.ForeColor = Color.Linen;
                ScoreNum.ForeColor = Color.Linen;
                frime.Color = Color.ForestGreen;
                l.ForeColor = Color.Red;
            }
            else if (UserControl1.level == 3)
            {
                ForNext.ForeColor = Color.White;
                BackgroundImage = Properties.Resources.Dragon_438x607;
                button1.FlatAppearance.BorderColor = Color.DarkRed;
                button2.FlatAppearance.BorderColor = Color.DarkRed;
                button3.FlatAppearance.BorderColor = Color.DarkRed;
                GoalScore.Image = Properties.Resources.ForScores;
                frime.Color = Color.Red;
                Next.ForeColor = Color.Linen;
                ScoreLab.ForeColor = Color.Linen;
                ScoreNum.ForeColor = Color.Linen;
                GoalScore.ForeColor = Color.FromArgb(80, 0, 0);
                GoalScore.Font = new Font(GoalScore.Font.Name, 22, GoalScore.Font.Style);
                GoalScore.Text = "20000";
                l.ForeColor = Color.Lime;
            }
            if (UserControl1.difficulty >= 2)
            {
                grid = false;
                FallingTimer.Interval = 600;
                x = 1.5;
                if (UserControl1.difficulty == 3)
                {
                    x = 2.5;
                    FallingTimer.Interval = 400;
                    shadowON = false;
                    ObstaclesGenerator.Enabled = true;
                    ObstaclesDelete.Enabled = true;
                    ObstaclesGenerator.Start();
                    ObstaclesDelete.Start();
                }
            }
        }
        /// <summary>
        /// Рендеринг (отрисовка) всех объектов на основной форме игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            //Отрисовка фигур, поля, тени, сетки
            if (!bottom)
            {
                TetrisField.Refresh();
            }
            else if (bottom)
            {
                bottom = false;
                value = valuee;
                valuee = rnd.Next(0, 6);
                TetrisField.Refresh();
            }
        }

        /// <summary>
        /// Отвечает за обработку падения фигур
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer3_Tick(object sender, EventArgs e)
        {
            NextBlockPic.Refresh();
            PictureBox1_Paint(sender, new PaintEventArgs(NextBlockPic.CreateGraphics(), NextBlockPic.Bounds));
            //Падение фигур (свой таймер)
            switch (value)
            {
                case 0:
                    Falling(fangle);
                    TextureFalling(angle);
                    if (obstaclesBool == true)
                    {
                        StopingFigureByObstacles(fangle);
                    }
                    if (bottom)
                    {
                        player3.URL = "Состыковка.mp3";
                        player3.settings.volume = 15;
                        player3.controls.play();
                        angle.ResetTransform();
                        listangles.AddRange(fangle);
                        list.AddRange(fangle);
                        fangle[0] = new Rectangle(80, 20, 20, 20); // восстанавливаем фигуру
                        fangle[1] = new Rectangle(100, -20, 20, 20);
                        fangle[2] = new Rectangle(100, 0, 20, 20);
                        fangle[3] = new Rectangle(100, 20, 20, 20);
                        count = 0; // вставляем нулевое положение поворота
                        Timer1_Tick(sender, new EventArgs());
                        CurrentList(fangle);
                    }
                    break;
                case 1:
                    Falling(fsquare);
                    TextureFalling(square);
                    if (obstaclesBool == true)
                    {
                        StopingFigureByObstacles(fsquare);
                    }
                    if (bottom)
                    {
                        player3.URL = "Состыковка.mp3";
                        player3.settings.volume = 15;
                        player3.controls.play();
                        square.ResetTransform();
                        listsquares.AddRange(fsquare);
                        list.AddRange(fsquare);
                        fsquare[0] = new Rectangle(80, 0, 20, 20);
                        fsquare[1] = new Rectangle(100, 0, 20, 20);
                        fsquare[2] = new Rectangle(80, 20, 20, 20);
                        fsquare[3] = new Rectangle(100, 20, 20, 20);
                        Timer1_Tick(sender, new EventArgs());
                        CurrentList(fsquare);
                    }
                    break;
                case 2:
                    Falling(fline);
                    TextureFalling(line);
                    if (obstaclesBool == true)
                    {
                        StopingFigureByObstacles(fline);
                    }
                    if (bottom)
                    {
                        player3.URL = "Состыковка.mp3";
                        player3.settings.volume = 15;
                        player3.controls.play();
                        line.ResetTransform();
                        listlines.AddRange(fline);
                        list.AddRange(fline);
                        fline[0] = new Rectangle(80, -40, 20, 20);
                        fline[1] = new Rectangle(80, -20, 20, 20);
                        fline[2] = new Rectangle(80, 0, 20, 20);
                        fline[3] = new Rectangle(80, 20, 20, 20);
                        count = 0; // вставляем нулевое положение поворота
                        Timer1_Tick(sender, new EventArgs());
                        CurrentList(fline);
                    }
                    break;
                case 3:
                    Falling(fzigzag);
                    TextureFalling(zigzag);
                    if (obstaclesBool == true)
                    {
                        StopingFigureByObstacles(fzigzag);
                    }
                    if (bottom)  //доходит до дна
                    {
                        player3.URL = "Состыковка.mp3";
                        player3.settings.volume = 15;
                        player3.controls.play();
                        zigzag.ResetTransform();
                        listzigzags.AddRange(fzigzag);
                        list.AddRange(fzigzag);
                        fzigzag[0] = new Rectangle(60, 0, 20, 20);
                        fzigzag[1] = new Rectangle(80, 0, 20, 20);
                        fzigzag[2] = new Rectangle(80, 20, 20, 20);
                        fzigzag[3] = new Rectangle(100, 20, 20, 20);
                        count = 0; // вставляем нулевое положение поворота
                        Timer1_Tick(sender, new EventArgs());
                        CurrentList(fzigzag);
                    }
                    break;
                case 4:
                    Falling(fhump);
                    TextureFalling(hump);
                    if (obstaclesBool == true)
                    {
                        StopingFigureByObstacles(fhump);
                    }
                    if (bottom)
                    {
                        player3.URL = "Состыковка.mp3";
                        player3.settings.volume = 15;
                        player3.controls.play();
                        hump.ResetTransform();
                        listhumps.AddRange(fhump);
                        list.AddRange(fhump);
                        fhump[0] = new Rectangle(80, 0, 20, 20);
                        fhump[1] = new Rectangle(60, 20, 20, 20);
                        fhump[2] = new Rectangle(80, 20, 20, 20);
                        fhump[3] = new Rectangle(100, 20, 20, 20);
                        count = 0; // вставляем нулевое положение поворота
                        Timer1_Tick(sender, new EventArgs());
                        CurrentList(fhump);
                    }
                    break;
                case 5:
                    Falling(fbed);
                    TextureFalling(bed);
                    if (obstaclesBool == true)
                    {
                        StopingFigureByObstacles(fbed);
                    }
                    if (bottom)
                    {
                        player3.URL = "Состыковка.mp3";
                        player3.settings.volume = 15;
                        player3.controls.play();
                        bed.ResetTransform();
                        listbeds.AddRange(fbed);
                        list.AddRange(fbed);
                        fbed[0] = new Rectangle(100, 0, 20, 20);
                        fbed[1] = new Rectangle(60, 20, 20, 20);
                        fbed[2] = new Rectangle(80, 20, 20, 20);
                        fbed[3] = new Rectangle(100, 20, 20, 20);
                        count = 0; // вставляем нулевое положение поворота
                        Timer1_Tick(sender, new EventArgs());
                        CurrentList(fbed);
                    }
                    break;
            }
        }

        List<Rectangle> CurrentList(List<Rectangle> rec)
        {
            current = rec;
            return current;
        }
        #endregion

        #region Tools
        SolidBrush frime = new SolidBrush(Color.Aqua);
        //TEXTURES
        static Bitmap obstaclesImage = Properties.Resources.wire;
        TextureBrush obstacles = new TextureBrush(obstaclesImage);
        //pic1
        TextureBrush angless = new TextureBrush(imAnglelev1);
        TextureBrush squaress = new TextureBrush(imSquarelev1);
        TextureBrush liness = new TextureBrush(imLinelev1);
        TextureBrush zigzagss = new TextureBrush(imZigzaglev1);
        TextureBrush humpss = new TextureBrush(imHumplev1);
        TextureBrush bedss = new TextureBrush(imBedlev1);
        //main
        TextureBrush all = new TextureBrush(imAlllev1);
        TextureBrush angle = new TextureBrush(imAnglelev1);
        TextureBrush square = new TextureBrush(imSquarelev1);
        TextureBrush line = new TextureBrush(imLinelev1);
        TextureBrush zigzag = new TextureBrush(imZigzaglev1);
        TextureBrush hump = new TextureBrush(imHumplev1);
        TextureBrush bed = new TextureBrush(imBedlev1);
        void PicLevelTexture()
        {
            if (UserControl1.level == 2)
            {
                //pic1
                angless = new TextureBrush(imAnglelev2);
                squaress = new TextureBrush(imSquarelev2);
                liness = new TextureBrush(imLinelev2);
                zigzagss = new TextureBrush(imZigzaglev2);
                humpss = new TextureBrush(imHumplev2);
                bedss = new TextureBrush(imBedlev2);
                //main
                all = new TextureBrush(imAlllev2);
                angle = new TextureBrush(imAnglelev2);
                square = new TextureBrush(imSquarelev2);
                line = new TextureBrush(imLinelev2);
                zigzag = new TextureBrush(imZigzaglev2);
                hump = new TextureBrush(imHumplev2);
                bed = new TextureBrush(imBedlev2);
            }
            else if (UserControl1.level == 3)
            {
                //picturebox1
                angless = new TextureBrush(imAnglelev3);
                squaress = new TextureBrush(imSquarelev3);
                liness = new TextureBrush(imLinelev3);
                zigzagss = new TextureBrush(imZigzaglev3);
                humpss = new TextureBrush(imHumplev3);
                bedss = new TextureBrush(imBedlev3);
                //main
                all = new TextureBrush(imAlllev3);
                angle = new TextureBrush(imAnglelev3);
                square = new TextureBrush(imSquarelev3);
                line = new TextureBrush(imLinelev3);
                zigzag = new TextureBrush(imZigzaglev3);
                hump = new TextureBrush(imHumplev3);
                bed = new TextureBrush(imBedlev3);
            }
            angless.TranslateTransform(5, 12);
            squaress.TranslateTransform(15, 2);
            liness.TranslateTransform(5, 2);
            zigzagss.TranslateTransform(5, 2);
            humpss.TranslateTransform(5, 2);
            bedss.TranslateTransform(5, 2);
        }

        //all
        static Bitmap imAlllev3 = Properties.Resources.stan2lev3;
        static Bitmap imAlllev2 = Properties.Resources.stan2lev2;
        static Bitmap imAlllev1 = Properties.Resources.stan2lev1;

        //angel
        static Bitmap imAnglelev3 = Properties.Resources.anglelev3;
        static Bitmap imAnglelev2 = Properties.Resources.anglelev2;
        static Bitmap imAnglelev1 = Properties.Resources.anglelev1;
        //square
        static Bitmap imSquarelev3 = Properties.Resources.squarelev3;
        static Bitmap imSquarelev2 = Properties.Resources.squarelev2;
        static Bitmap imSquarelev1 = Properties.Resources.squarelev1;
        //line
        static Bitmap imLinelev3 = Properties.Resources.linelev3;
        static Bitmap imLinelev2 = Properties.Resources.linelev2;
        static Bitmap imLinelev1 = Properties.Resources.linelev1;
        //zigzag
        static Bitmap imZigzaglev3 = Properties.Resources.zigzaglev3;
        static Bitmap imZigzaglev2 = Properties.Resources.zigzaglev2;
        static Bitmap imZigzaglev1 = Properties.Resources.zigzaglev1;
        //hump
        static Bitmap imHumplev3 = Properties.Resources.humplev3;
        static Bitmap imHumplev2 = Properties.Resources.humplev2;
        static Bitmap imHumplev1 = Properties.Resources.humplev1;
        //bed
        static Bitmap imBedlev3 = Properties.Resources.bedlev3;
        static Bitmap imBedlev2 = Properties.Resources.bedlev2;
        static Bitmap imBedlev1 = Properties.Resources.bedlev1;
        void TextureFalling(TextureBrush brush)
        {
            if (count == 0)
            {
                brush.TranslateTransform(0, 20);
            }
            else if (count == 1)
            {
                brush.TranslateTransform(20, 0);
            }
            else if (count == 2)
            {
                brush.TranslateTransform(0, -20);
            }
            else if (count == 3)
            {
                brush.TranslateTransform(-20, 0);
            }
        }
        /// <summary>
        /// Сдвигает текстуру вслед за фигурой.
        /// </summary>
        /// <param name="brush"></param>
        /// <param name="right"></param>
        void TextureShifting(TextureBrush brush, bool right)
        {
            if (count == 0) // смещение текстуры
            {
                if (right)
                {
                    brush.TranslateTransform(20, 0);
                }
                else
                {
                    brush.TranslateTransform(-20, 0);
                }
            }
            else if (count == 1)
            {
                if (right)
                {
                    brush.TranslateTransform(0, -20);
                }
                else
                {
                    brush.TranslateTransform(0, 20);
                }
            }
            else if (count == 2)
            {
                if (right)
                {
                    brush.TranslateTransform(-20, 0);
                }
                else
                {
                    brush.TranslateTransform(20, 0);
                }
            }
            else if (count == 3)
            {
                if (right)
                {
                    brush.TranslateTransform(0, 20);
                }
                else
                {
                    brush.TranslateTransform(0, -20);
                }
            }
        }
        void ResetTools()
        {
            listangles.Add(new Rectangle(-999999, -999999, 0, 0));
            listsquares.Add(new Rectangle(-999999, -999999, 0, 0));
            listlines.Add(new Rectangle(-999999, -999999, 0, 0));
            listzigzags.Add(new Rectangle(-999999, -999999, 0, 0));
            listhumps.Add(new Rectangle(-999999, -999999, 0, 0));
            listbeds.Add(new Rectangle(-999999, -999999, 0, 0));
            fangle.Add(new Rectangle(80, 20, 20, 20)); // восстанавливаем фигуру
            fangle.Add(new Rectangle(100, -20, 20, 20));
            fangle.Add(new Rectangle(100, 0, 20, 20));
            fangle.Add(new Rectangle(100, 20, 20, 20));
            fsquare.Add(new Rectangle(80, 0, 20, 20));
            fsquare.Add(new Rectangle(100, 0, 20, 20));
            fsquare.Add(new Rectangle(80, 20, 20, 20));
            fsquare.Add(new Rectangle(100, 20, 20, 20));
            fline.Add(new Rectangle(80, -40, 20, 20));
            fline.Add(new Rectangle(80, -20, 20, 20));
            fline.Add(new Rectangle(80, 0, 20, 20));
            fline.Add(new Rectangle(80, 20, 20, 20));
            fzigzag.Add(new Rectangle(60, 0, 20, 20));
            fzigzag.Add(new Rectangle(80, 0, 20, 20));
            fzigzag.Add(new Rectangle(80, 20, 20, 20));
            fzigzag.Add(new Rectangle(100, 20, 20, 20));
            fhump.Add(new Rectangle(80, 0, 20, 20));
            fhump.Add(new Rectangle(60, 20, 20, 20));
            fhump.Add(new Rectangle(80, 20, 20, 20));
            fhump.Add(new Rectangle(100, 20, 20, 20));
            fbed.Add(new Rectangle(100, 0, 20, 20));
            fbed.Add(new Rectangle(60, 20, 20, 20));
            fbed.Add(new Rectangle(80, 20, 20, 20));
            fbed.Add(new Rectangle(100, 20, 20, 20));
            count = 0; // вставляем нулевое положение поворота
        }
        //current falling figure
        List<Rectangle> current = new List<Rectangle>
        {new Rectangle() };
        //square
        List<Rectangle> fsquare = new List<Rectangle>
        {
            new Rectangle(80, 0, 20, 20),
            new Rectangle(100, 0, 20, 20),
            new Rectangle(80, 20, 20, 20),
            new Rectangle(100, 20 ,20, 20) };
        //angle
        List<Rectangle> fangle = new List<Rectangle>
        {
            new Rectangle(80, 20, 20, 20),
            new Rectangle(100, -20, 20, 20),
            new Rectangle(100, 0, 20, 20),
            new Rectangle(100, 20, 20, 20) };

        //line
        List<Rectangle> fline = new List<Rectangle>
        {
            new Rectangle(80, -40, 20, 20),
            new Rectangle(80, -20, 20, 20),
            new Rectangle(80, 0, 20, 20),
            new Rectangle(80, 20, 20, 20) };

        //zigzag
        List<Rectangle> fzigzag = new List<Rectangle>
        {
            new Rectangle(60, 0, 20, 20),
            new Rectangle(80, 0, 20, 20),
            new Rectangle(80, 20, 20, 20),
            new Rectangle(100, 20, 20, 20)
        };
        //hump
        List<Rectangle> fhump = new List<Rectangle>
        {
            new Rectangle(80, 0, 20, 20),
            new Rectangle(60, 20, 20, 20),
            new Rectangle(80, 20, 20, 20),
            new Rectangle(100, 20, 20, 20) };
        //beg
        List<Rectangle> fbed = new List<Rectangle>
        {
            new Rectangle(100, 0, 20, 20),
            new Rectangle(60, 20, 20, 20),
            new Rectangle(80, 20, 20, 20),
            new Rectangle(100, 20, 20, 20) };

        //для отрисовки сборок из фигур
        List<Rectangle> listsquares = new List<Rectangle>() { new Rectangle(-1000, -1000, 0, 0) };
        List<Rectangle> listlines = new List<Rectangle>() { new Rectangle(-1000, -1000, 0, 0) };
        List<Rectangle> listangles = new List<Rectangle>() { new Rectangle(-1000, -1000, 0, 0) };
        List<Rectangle> listzigzags = new List<Rectangle>() { new Rectangle(-1000, -1000, 0, 0) };
        List<Rectangle> listhumps = new List<Rectangle>() { new Rectangle(-1000, -1000, 0, 0) };
        List<Rectangle> listbeds = new List<Rectangle>() { new Rectangle(-1000, -1000, 0, 0) };

        //mutual list
        List<Rectangle> list = new List<Rectangle>() { };

        #endregion

        #region Handing of KeyCodes

        int saveintervale;
        void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (!MovingTimer.Enabled && !(e.KeyValue == (char)Keys.Escape))
            {
                return;
            }

            if (e.KeyValue == (char)Keys.Escape)
            {
                Application.Exit();
            }

            #region UP
            if (e.KeyValue == (char)Keys.Up || e.KeyValue == (char)Keys.W)
            {
                if (count == 0) // 1 поворот.
                {
                    //angle.
                    if (value == 0 && !StuckWhenRotating(fangle))
                    {
                        fangle[0] = new Rectangle(new Point(fangle[0].X, fangle[0].Y - 40), new Size(20, 20));        //
                        fangle[1] = new Rectangle(new Point(fangle[1].X + 20, fangle[1].Y + 20), new Size(20, 20));   // Поворот.
                        fangle[3] = new Rectangle(new Point(fangle[3].X - 20, fangle[3].Y - 20), new Size(20, 20));   //
                        angle.RotateTransform(90); // Поровачивает текстуру на 90 градусов.
                        //shadow
                        if (shadowON)
                        {
                            shadow[0] = new Rectangle(new Point(shadow[0].X, shadow[0].Y - 20), new Size(20, 20));        //
                            shadow[1] = new Rectangle(new Point(shadow[1].X + 20, shadow[1].Y + 40), new Size(20, 20));   // Поворот тени фигуры.
                            shadow[2] = new Rectangle(new Point(shadow[2].X, shadow[2].Y + 20), new Size(20, 20));        //
                            shadow[3] = new Rectangle(new Point(shadow[3].X - 20, shadow[3].Y), new Size(20, 20));        //
                        }
                        count++; // Счетчик, чтобы определять номер повора.
                        Check(fangle);
                    }
                    //line
                    if (value == 2 && !StuckWhenRotating(fline))
                    {
                        fline[0] = new Rectangle(new Point(fline[0].X + 40, fline[0].Y + 40), new Size(20, 20));
                        fline[1] = new Rectangle(new Point(fline[1].X + 20, fline[1].Y + 20), new Size(20, 20));
                        fline[3] = new Rectangle(new Point(fline[3].X - 20, fline[3].Y - 20), new Size(20, 20));
                        line.RotateTransform(90);
                        if (shadowON)
                        {
                            shadow[0] = new Rectangle(new Point(shadow[0].X + 40, shadow[0].Y + 60), new Size(20, 20));
                            shadow[1] = new Rectangle(new Point(shadow[1].X + 20, shadow[1].Y + 40), new Size(20, 20));
                            shadow[2] = new Rectangle(new Point(shadow[2].X, shadow[2].Y + 20), new Size(20, 20));
                            shadow[3] = new Rectangle(new Point(shadow[3].X - 20, shadow[3].Y), new Size(20, 20));
                        }
                        count++;
                        Check(fline);
                    }
                    //zigzag
                    if (value == 3 && !StuckWhenRotating(fzigzag))
                    {
                        fzigzag[0] = new Rectangle(new Point(fzigzag[0].X + 40, fzigzag[0].Y), new Size(20, 20));
                        fzigzag[1] = new Rectangle(new Point(fzigzag[1].X + 20, fzigzag[1].Y + 20), new Size(20, 20));
                        fzigzag[3] = new Rectangle(new Point(fzigzag[3].X - 20, fzigzag[3].Y + 20), new Size(20, 20));
                        zigzag.RotateTransform(90);
                        if (shadowON)
                        {
                            shadow[0] = new Rectangle(new Point(shadow[0].X + 40, shadow[0].Y - 20), new Size(20, 20));
                            shadow[1] = new Rectangle(new Point(shadow[1].X + 20, shadow[1].Y), new Size(20, 20));
                            shadow[2] = new Rectangle(new Point(shadow[2].X, shadow[2].Y - 20), new Size(20, 20));
                            shadow[3] = new Rectangle(new Point(shadow[3].X - 20, shadow[3].Y), new Size(20, 20));
                        }
                        count++;
                        Check(fzigzag);
                    }
                    //hump
                    if (value == 4 && !StuckWhenRotating(fhump))
                    {
                        fhump[0] = new Rectangle(new Point(fhump[0].X + 20, fhump[0].Y + 20), new Size(20, 20));
                        fhump[1] = new Rectangle(new Point(fhump[1].X + 20, fhump[1].Y - 20), new Size(20, 20));
                        fhump[3] = new Rectangle(new Point(fhump[3].X - 20, fhump[3].Y + 20), new Size(20, 20));
                        hump.RotateTransform(90);
                        if (shadowON)
                        {
                            shadow[0] = new Rectangle(new Point(shadow[0].X + 20, shadow[0].Y), new Size(20, 20));
                            shadow[1] = new Rectangle(new Point(shadow[1].X + 20, shadow[1].Y - 40), new Size(20, 20));
                            shadow[2] = new Rectangle(new Point(shadow[2].X, shadow[2].Y - 20), new Size(20, 20));
                            shadow[3] = new Rectangle(new Point(shadow[3].X - 20, shadow[3].Y), new Size(20, 20));
                        }
                        count++;
                        Check(fhump);
                    }
                    //bed
                    if (value == 5 && !StuckWhenRotating(fbed))
                    {
                        fbed[0] = new Rectangle(new Point(fbed[0].X, fbed[0].Y + 40), new Size(20, 20));
                        fbed[1] = new Rectangle(new Point(fbed[1].X + 20, fbed[1].Y - 20), new Size(20, 20));
                        fbed[3] = new Rectangle(new Point(fbed[3].X - 20, fbed[3].Y + 20), new Size(20, 20));
                        bed.RotateTransform(90);
                        if (shadowON)
                        {
                            shadow[0] = new Rectangle(new Point(shadow[0].X + 40, shadow[0].Y - 20), new Size(20, 20));
                            shadow[1] = new Rectangle(new Point(shadow[1].X + 20, shadow[1].Y - 40), new Size(20, 20));
                            shadow[2] = new Rectangle(new Point(shadow[2].X, shadow[2].Y - 20), new Size(20, 20));
                            shadow[3] = new Rectangle(new Point(shadow[3].X - 20, shadow[3].Y), new Size(20, 20));
                        }
                        count++;
                        Check(fbed);
                    }
                }
                else if (count == 1) // 2 поворот
                {
                    //angle
                    if (value == 0 && !StuckWhenRotating(fangle))
                    {
                        fangle[0] = new Rectangle(new Point(fangle[0].X + 40, fangle[0].Y), new Size(20, 20));
                        fangle[1] = new Rectangle(new Point(fangle[1].X - 20, fangle[1].Y + 20), new Size(20, 20));
                        fangle[3] = new Rectangle(new Point(fangle[3].X + 20, fangle[3].Y - 20), new Size(20, 20));
                        angle.RotateTransform(90);
                        if (shadowON)
                        {
                            shadow[0] = new Rectangle(new Point(shadow[0].X + 40, shadow[0].Y - 20), new Size(20, 20));
                            shadow[1] = new Rectangle(new Point(shadow[1].X - 20, shadow[1].Y), new Size(20, 20));
                            shadow[2] = new Rectangle(new Point(shadow[2].X, shadow[2].Y - 20), new Size(20, 20));
                            shadow[3] = new Rectangle(new Point(shadow[3].X + 20, shadow[3].Y - 40), new Size(20, 20));
                        }
                        count++;
                        Check(fangle);
                    }
                    //line
                    if (value == 2 && !StuckWhenRotating(fline))
                    {
                        fline[0] = new Rectangle(new Point(fline[0].X - 40, fline[0].Y + 40), new Size(20, 20));
                        fline[1] = new Rectangle(new Point(fline[1].X - 20, fline[1].Y + 20), new Size(20, 20));
                        fline[3] = new Rectangle(new Point(fline[3].X + 20, fline[3].Y - 20), new Size(20, 20));
                        line.RotateTransform(90);
                        if (shadowON)
                        {
                            shadow[0] = new Rectangle(new Point(shadow[0].X - 40, shadow[0].Y), new Size(20, 20));
                            shadow[1] = new Rectangle(new Point(shadow[1].X - 20, shadow[1].Y - 20), new Size(20, 20));
                            shadow[2] = new Rectangle(new Point(shadow[2].X, shadow[2].Y - 40), new Size(20, 20));
                            shadow[3] = new Rectangle(new Point(shadow[3].X + 20, shadow[3].Y - 60), new Size(20, 20));
                        }
                        count++;
                        Check(fline);
                    }
                    //zigzag
                    if (value == 3 && !StuckWhenRotating(fzigzag))
                    {
                        fzigzag[0] = new Rectangle(new Point(fzigzag[0].X, fzigzag[0].Y + 40), new Size(20, 20));
                        fzigzag[1] = new Rectangle(new Point(fzigzag[1].X - 20, fzigzag[1].Y + 20), new Size(20, 20));
                        fzigzag[3] = new Rectangle(new Point(fzigzag[3].X - 20, fzigzag[3].Y - 20), new Size(20, 20));
                        zigzag.RotateTransform(90);
                        if (shadowON)
                        {
                            shadow[0] = new Rectangle(new Point(shadow[0].X, shadow[0].Y + 40), new Size(20, 20));
                            shadow[1] = new Rectangle(new Point(shadow[1].X - 20, shadow[1].Y + 20), new Size(20, 20));
                            shadow[3] = new Rectangle(new Point(shadow[3].X - 20, shadow[3].Y - 20), new Size(20, 20));
                        }
                        count++;
                        Check(fzigzag);
                    }
                    //hump
                    if (value == 4 && !StuckWhenRotating(fhump))
                    {
                        fhump[0] = new Rectangle(new Point(fhump[0].X - 20, fhump[0].Y + 20), new Size(20, 20));
                        fhump[1] = new Rectangle(new Point(fhump[1].X + 20, fhump[1].Y + 20), new Size(20, 20));
                        fhump[3] = new Rectangle(new Point(fhump[3].X - 20, fhump[3].Y - 20), new Size(20, 20));
                        hump.RotateTransform(90);
                        if (shadowON)
                        {
                            shadow[0] = new Rectangle(new Point(shadow[0].X - 20, shadow[0].Y + 20), new Size(20, 20));
                            shadow[1] = new Rectangle(new Point(shadow[1].X + 20, shadow[1].Y + 20), new Size(20, 20));
                            shadow[3] = new Rectangle(new Point(shadow[3].X - 20, shadow[3].Y - 20), new Size(20, 20));
                        }
                        count++;
                        Check(fhump);
                    }
                    //bed
                    if (value == 5 && !StuckWhenRotating(fbed))
                    {
                        fbed[0] = new Rectangle(new Point(fbed[0].X - 40, fbed[0].Y), new Size(20, 20));
                        fbed[1] = new Rectangle(new Point(fbed[1].X + 20, fbed[1].Y + 20), new Size(20, 20));
                        fbed[3] = new Rectangle(new Point(fbed[3].X - 20, fbed[3].Y - 20), new Size(20, 20));
                        bed.RotateTransform(90);
                        if (shadowON)
                        {
                            shadow[0] = new Rectangle(new Point(shadow[0].X, shadow[0].Y + 40), new Size(20, 20));
                            shadow[1] = new Rectangle(new Point(shadow[1].X + 20, shadow[1].Y + 20), new Size(20, 20));
                            shadow[3] = new Rectangle(new Point(shadow[3].X - 20, shadow[3].Y - 20), new Size(20, 20));
                        }
                        count++;
                        Check(fbed);
                    }
                }
                else if (count == 2) // 3 поворот
                {
                    //angle
                    if (value == 0 && !StuckWhenRotating(fangle))
                    {
                        fangle[0] = new Rectangle(new Point(fangle[0].X, fangle[0].Y + 40), new Size(20, 20));
                        fangle[1] = new Rectangle(new Point(fangle[1].X - 20, fangle[1].Y - 20), new Size(20, 20));
                        fangle[3] = new Rectangle(new Point(fangle[3].X + 20, fangle[3].Y + 20), new Size(20, 20));
                        angle.RotateTransform(90);
                        if (shadowON)
                        {
                            shadow[0] = new Rectangle(new Point(shadow[0].X, shadow[0].Y + 40), new Size(20, 20));
                            shadow[1] = new Rectangle(new Point(shadow[1].X - 20, shadow[1].Y - 20), new Size(20, 20));
                            shadow[3] = new Rectangle(new Point(shadow[3].X + 20, shadow[3].Y + 20), new Size(20, 20));
                        }
                        count++;
                        Check(fangle);
                    }
                    //line
                    if (value == 2 && !StuckWhenRotating(fline))
                    {
                        fline[0] = new Rectangle(new Point(fline[0].X - 40, fline[0].Y - 40), new Size(20, 20));
                        fline[1] = new Rectangle(new Point(fline[1].X - 20, fline[1].Y - 20), new Size(20, 20));
                        fline[3] = new Rectangle(new Point(fline[3].X + 20, fline[3].Y + 20), new Size(20, 20));
                        line.RotateTransform(90);
                        if (shadowON)
                        {
                            shadow[0] = new Rectangle(new Point(shadow[0].X - 40, shadow[0].Y), new Size(20, 20));
                            shadow[1] = new Rectangle(new Point(shadow[1].X - 20, shadow[1].Y + 20), new Size(20, 20));
                            shadow[2] = new Rectangle(new Point(shadow[2].X, shadow[2].Y + 40), new Size(20, 20));
                            shadow[3] = new Rectangle(new Point(shadow[3].X + 20, shadow[3].Y + 60), new Size(20, 20));
                        }
                        count++;
                        Check(fline);
                    }
                    //zigzag
                    if (value == 3 && !StuckWhenRotating(fzigzag))
                    {
                        fzigzag[0] = new Rectangle(new Point(fzigzag[0].X - 40, fzigzag[0].Y), new Size(20, 20));
                        fzigzag[1] = new Rectangle(new Point(fzigzag[1].X - 20, fzigzag[1].Y - 20), new Size(20, 20));
                        fzigzag[3] = new Rectangle(new Point(fzigzag[3].X + 20, fzigzag[3].Y - 20), new Size(20, 20));
                        zigzag.RotateTransform(90);
                        if (shadowON)
                        {
                            shadow[0] = new Rectangle(new Point(shadow[0].X - 40, shadow[0].Y), new Size(20, 20));
                            shadow[1] = new Rectangle(new Point(shadow[1].X - 20, shadow[1].Y - 20), new Size(20, 20));
                            shadow[3] = new Rectangle(new Point(shadow[3].X + 20, shadow[3].Y - 20), new Size(20, 20));
                        }
                        count++;
                        Check(fzigzag);
                    }
                    //hump
                    if (value == 4 && !StuckWhenRotating(fhump))
                    {
                        fhump[0] = new Rectangle(new Point(fhump[0].X - 20, fhump[0].Y - 20), new Size(20, 20));
                        fhump[1] = new Rectangle(new Point(fhump[1].X - 20, fhump[1].Y + 20), new Size(20, 20));
                        fhump[3] = new Rectangle(new Point(fhump[3].X + 20, fhump[3].Y - 20), new Size(20, 20));
                        hump.RotateTransform(90);
                        if (shadowON)
                        {
                            shadow[0] = new Rectangle(new Point(shadow[0].X - 20, shadow[0].Y - 20), new Size(20, 20));
                            shadow[1] = new Rectangle(new Point(shadow[1].X - 20, shadow[1].Y + 20), new Size(20, 20));
                            shadow[3] = new Rectangle(new Point(shadow[3].X + 20, shadow[3].Y - 20), new Size(20, 20));
                        }
                        count++;
                        Check(fhump);
                    }
                    //bed
                    if (value == 5 && !StuckWhenRotating(fbed))
                    {
                        fbed[0] = new Rectangle(new Point(fbed[0].X, fbed[0].Y - 40), new Size(20, 20));
                        fbed[1] = new Rectangle(new Point(fbed[1].X - 20, fbed[1].Y + 20), new Size(20, 20));
                        fbed[3] = new Rectangle(new Point(fbed[3].X + 20, fbed[3].Y - 20), new Size(20, 20));
                        bed.RotateTransform(90);
                        if (shadowON)
                        {
                            shadow[0] = new Rectangle(new Point(shadow[0].X - 40, shadow[0].Y), new Size(20, 20));
                            shadow[1] = new Rectangle(new Point(shadow[1].X - 20, shadow[1].Y + 20), new Size(20, 20));
                            shadow[3] = new Rectangle(new Point(shadow[3].X + 20, shadow[3].Y - 20), new Size(20, 20));
                        }
                        count++;
                        Check(fbed);
                    }
                }
                else if (count == 3) // 4 поворот
                {
                    //angle
                    if (value == 0 && !StuckWhenRotating(fangle))
                    {
                        fangle[0] = new Rectangle(new Point(fangle[0].X - 40, fangle[0].Y), new Size(20, 20));
                        fangle[1] = new Rectangle(new Point(fangle[1].X + 20, fangle[1].Y - 20), new Size(20, 20));
                        fangle[3] = new Rectangle(new Point(fangle[3].X - 20, fangle[3].Y + 20), new Size(20, 20));
                        angle.RotateTransform(90);
                        if (shadowON)
                        {
                            shadow[0] = new Rectangle(new Point(shadow[0].X - 40, shadow[0].Y), new Size(20, 20));
                            shadow[1] = new Rectangle(new Point(shadow[1].X + 20, shadow[1].Y - 20), new Size(20, 20));
                            shadow[3] = new Rectangle(new Point(shadow[3].X - 20, shadow[3].Y + 20), new Size(20, 20));
                        }
                        count = 0;
                        Check(fangle);
                    }
                    //line
                    if (value == 2 && !StuckWhenRotating(fline))
                    {
                        fline[0] = new Rectangle(new Point(fline[0].X + 40, fline[0].Y - 40), new Size(20, 20));
                        fline[1] = new Rectangle(new Point(fline[1].X + 20, fline[1].Y - 20), new Size(20, 20));
                        fline[3] = new Rectangle(new Point(fline[3].X - 20, fline[3].Y + 20), new Size(20, 20));
                        line.RotateTransform(90);
                        if (shadowON)
                        {
                            shadow[0] = new Rectangle(new Point(shadow[0].X + 40, shadow[0].Y - 60), new Size(20, 20));
                            shadow[1] = new Rectangle(new Point(shadow[1].X + 20, shadow[1].Y - 40), new Size(20, 20));
                            shadow[2] = new Rectangle(new Point(shadow[2].X, shadow[2].Y - 20), new Size(20, 20));
                            shadow[3] = new Rectangle(new Point(shadow[3].X - 20, shadow[3].Y), new Size(20, 20));
                        }
                        count = 0;
                        Check(fline);
                    }
                    //zigzag
                    if (value == 3 && !StuckWhenRotating(fzigzag))
                    {
                        fzigzag[0] = new Rectangle(new Point(fzigzag[0].X, fzigzag[0].Y - 40), new Size(20, 20));
                        fzigzag[1] = new Rectangle(new Point(fzigzag[1].X + 20, fzigzag[1].Y - 20), new Size(20, 20));
                        fzigzag[3] = new Rectangle(new Point(fzigzag[3].X + 20, fzigzag[3].Y + 20), new Size(20, 20));
                        zigzag.RotateTransform(90);
                        if (shadowON)
                        {
                            shadow[0] = new Rectangle(new Point(shadow[0].X, shadow[0].Y - 20), new Size(20, 20));
                            shadow[1] = new Rectangle(new Point(shadow[1].X + 20, shadow[1].Y), new Size(20, 20));
                            shadow[2] = new Rectangle(new Point(shadow[2].X, shadow[2].Y + 20), new Size(20, 20));
                            shadow[3] = new Rectangle(new Point(shadow[3].X + 20, shadow[3].Y + 40), new Size(20, 20));
                        }
                        count = 0;
                        Check(fzigzag);
                    }
                    //hump
                    if (value == 4 && !StuckWhenRotating(fhump))
                    {
                        fhump[0] = new Rectangle(new Point(fhump[0].X + 20, fhump[0].Y - 20), new Size(20, 20));
                        fhump[1] = new Rectangle(new Point(fhump[1].X - 20, fhump[1].Y - 20), new Size(20, 20));
                        fhump[3] = new Rectangle(new Point(fhump[3].X + 20, fhump[3].Y + 20), new Size(20, 20));
                        hump.RotateTransform(90);
                        if (shadowON)
                        {
                            shadow[0] = new Rectangle(new Point(shadow[0].X + 20, shadow[0].Y), new Size(20, 20));
                            shadow[1] = new Rectangle(new Point(shadow[1].X - 20, shadow[1].Y), new Size(20, 20));
                            shadow[2] = new Rectangle(new Point(shadow[2].X, shadow[2].Y + 20), new Size(20, 20));
                            shadow[3] = new Rectangle(new Point(shadow[3].X + 20, shadow[3].Y + 40), new Size(20, 20));
                        }
                        count = 0;
                        Check(fhump);
                    }
                    //bed
                    if (value == 5 && !StuckWhenRotating(fbed))
                    {
                        fbed[0] = new Rectangle(new Point(fbed[0].X + 40, fbed[0].Y), new Size(20, 20));
                        fbed[1] = new Rectangle(new Point(fbed[1].X - 20, fbed[1].Y - 20), new Size(20, 20));
                        fbed[3] = new Rectangle(new Point(fbed[3].X + 20, fbed[3].Y + 20), new Size(20, 20));
                        bed.RotateTransform(90);
                        if (shadowON)
                        {
                            shadow[0] = new Rectangle(new Point(shadow[0].X, shadow[0].Y - 20), new Size(20, 20));
                            shadow[1] = new Rectangle(new Point(shadow[1].X - 20, shadow[1].Y), new Size(20, 20));
                            shadow[2] = new Rectangle(new Point(shadow[2].X, shadow[2].Y + 20), new Size(20, 20));
                            shadow[3] = new Rectangle(new Point(shadow[3].X + 20, shadow[3].Y + 40), new Size(20, 20));
                        }
                        count = 0;
                        Check(fbed);
                    }
                }
            }
            #endregion

            #region Right
            if (e.KeyValue == (char)Keys.Right || e.KeyValue == (char)Keys.D)
            {
                if (value == 0)
                {
                    right(fangle, angle);
                }
                else if (value == 1)
                {
                    right(fsquare, square);
                }
                else if (value == 2)
                {
                    right(fline, line);
                }
                else if (value == 3)
                {
                    right(fzigzag, zigzag);
                }
                else if (value == 4)
                {
                    right(fhump, hump);
                }
                else if (value == 5)
                {
                    right(fbed, bed);
                }
            }
            #endregion

            #region Left
            else if (e.KeyValue == (char)Keys.Left || e.KeyValue == (char)Keys.A)
            {
                if (value == 0)
                {
                    left(fangle, angle);
                }
                else if (value == 1)
                {
                    left(fsquare, square);
                }

                else if (value == 2)
                {
                    left(fline, line);
                }
                else if (value == 3)
                {
                    left(fzigzag, zigzag);
                }
                else if (value == 4)
                {
                    left(fhump, hump);
                }
                else if (value == 5)
                {
                    left(fbed, bed);
                }
            }
            #endregion

            #region Down
            if (e.KeyValue == (char)Keys.Down || e.KeyValue == (char)Keys.S)
            {
                if (FallingTimer.Interval > 35)
                {
                    saveintervale = FallingTimer.Interval; // Сохраняем старый интервал.
                    FallingTimer.Interval = 35; // Выставляем интервал равный 35.
                }
            }
            #endregion
        }
        void Form_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Down || e.KeyValue == (char)Keys.S)
            {
                FallingTimer.Interval = saveintervale; // Возвращаем предыдущее значение.
            }
        }
        void right(List<Rectangle> rec, TextureBrush brush)
        {
            for (int q = 0; q <= 3; q++) //Обработка правой границы движения.
            {
                if (rec[q].X == 180) // Правая граница
                {
                    return;
                }
            }
            RightLeftShifting(true, rec, brush);
        }
        /// <summary>
        /// Реализует движение фигуры в стороны
        /// </summary>
        /// <param name="right"></param>
        /// <param name="rec"></param>
        void RightLeftShifting(bool right, List<Rectangle> rec, TextureBrush brush)
        {
            for (int q = 0; q <= 3; q++)
            {
                foreach (Rectangle item in list) // Проверка на застревание фигуры в уже установленных.
                {
                    if (right ? rec[q].X == item.X - 20 && rec[q].Y == item.Y : rec[q].X == item.X + 20 && rec[q].Y == item.Y)
                    { return; }
                }
                if (obstaclesBool)
                {
                    foreach (Rectangle item in obstaclesList) // Проверка на застревание фигуры в припятствии (Уровень сложности - профи).
                    {
                        if (right ? rec[q].X == item.X - 20 && rec[q].Y == item.Y : rec[q].X == item.X + 20 && rec[q].Y == item.Y)
                        { return; }
                    }
                }
            }
            for (int q = 0; q <= 3; q++) // Движение фигуры вправо/влево.
            {
                if (right)
                { rec[q] = new Rectangle(new Point(rec[q].X + 20, rec[q].Y), new Size(20, 20)); }
                else
                { rec[q] = new Rectangle(new Point(rec[q].X - 20, rec[q].Y), new Size(20, 20)); }
            }
            if (right)
            { TextureShifting(brush, true); }
            else
            { TextureShifting(brush, false);}
        }
        void left(List<Rectangle> rec, TextureBrush brush)
        {
            for (int q = 0; q <= 3; q++) //Обработка левой границы движения.
            {
                if (rec[q].X == 0) // Левая граница.
                {
                    return;
                }
            }
            RightLeftShifting(false, rec, brush);
        }
        /// <summary>
        /// Проверка на застревание поворачивающийся фигуры в других фигурах.
        /// </summary>
        /// <param name="rec"></param>
        /// <returns></returns>
        bool StuckWhenRotating(List<Rectangle> rec)
        {
            for (int i = 0; i < rec.Count; i++)
            {
                if (list.Exists(ex => (ex.Location.X == rec[i].Location.X - 20 && ex.Location.Y == rec[i].Location.Y) ||
                (ex.Location.X == rec[i].Location.X + 20 && ex.Location.Y == rec[i].Location.Y)))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Проверка на завстревание в границах стакана при поворатах фигур.
        /// </summary>
        /// <param name="rec"></param>
        void Check(List<Rectangle> rec)
        {
            for (int q = 0; q < 6; q++)
            {
                if (rec.Exists(ex => ex.X < 0)) // Левая граница.
                {
                    for (int i = 0; i < rec.Count; i++)
                    {
                        rec[i] = new Rectangle(new Point(rec[i].X + 20, rec[i].Y), new Size(20, 20));

                    }
                }
                else if (rec.Exists(ex => ex.X > 180)) // Правая граница.
                {
                    for (int i = 0; i < rec.Count; i++)
                    {
                        rec[i] = new Rectangle(new Point(rec[i].X - 20, rec[i].Y), new Size(20, 20));

                    }
                }
                else { return; }
            }
        }

        #endregion

        #region Crusher 

        // Уничтожение слоев и сдвиг фигур
        List<int> mas = new List<int>(26) { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        Label cooler = new Label();
        Random random = new Random();
        Label l = new Label();

        /// <summary>
        /// Отвечает за появление текста при удалении больше одного слоя.
        /// </summary>
        /// <param name="numOfLayer"></param>
        async void HowCoolAreYou(int[] numOfLayer)
        {
            if (lenght == 1) // lenght - кол-во удаленных слоев.
            {
                cooler.Text = "DOUBLE KILL";
            }
            else if (lenght == 2)
            {
                cooler.Text = "TRIPLE KILL";
            }
            else
            {
                cooler.Text = "GODLIKE";
            }
            cooler.BringToFront(); // Появление текста.
            l.Text = "";
            for (int r = 247, g = 143, b = 143, size = 24; g >= 13 & b >= 13; g -= 10, b -= 10, size += 2, await Task.Delay(15))
            {
                cooler.ForeColor = Color.FromArgb(r, g, b);
                cooler.Font = new Font("Segoe Print", size, FontStyle.Bold);
            }
            Thread.Sleep(350);
            cooler.Text = "";
            cooler.SendToBack();
            Scoring(numOfLayer[lenght]);
        }

        /// <summary>
        /// Сдвиг фигур, находящихся после(выше) удаленного слоя кубиков.
        /// </summary>
        /// <param name="ii"></param>
        void Shift(int[] deletedLayers)
        {
            for (int q = 0; q < list.Count; q++)
            {
                if (list[q].Y < deletedLayers[lenght] * 20) // Сдвигаем все верхние слои из основного списка.
                {
                    list[q] = new Rectangle(new Point(list[q].X, list[q].Y + (lenght + 1) * 20), new Size(20, 20));
                }
            }
            // Сдвиг слоев из дополнительных списков, необходимых для отрисовки фигур разными текстурами.
            for (int q = 0; q < listsquares.Count; q++) // squares
            {
                if (listsquares[q].Y < deletedLayers[lenght] * 20)
                {
                    listsquares[q] = new Rectangle(new Point(listsquares[q].X, listsquares[q].Y + (lenght + 1) * 20), new Size(20, 20));
                }
            }
            for (int q = 0; q < listlines.Count; q++) // lines
            {
                if (listlines[q].Y < deletedLayers[lenght] * 20)
                {
                    listlines[q] = new Rectangle(new Point(listlines[q].X, listlines[q].Y + (lenght + 1) * 20), new Size(20, 20));
                }
            }
            for (int q = 0; q < listangles.Count; q++) // angeles
            {
                if (listangles[q].Y < deletedLayers[lenght] * 20)
                {
                    listangles[q] = new Rectangle(new Point(listangles[q].X, listangles[q].Y + (lenght + 1) * 20), new Size(20, 20));
                }
            }
            for (int q = 0; q < listzigzags.Count; q++) // zigzages
            {
                if (listzigzags[q].Y < deletedLayers[lenght] * 20)
                {
                    listzigzags[q] = new Rectangle(new Point(listzigzags[q].X, listzigzags[q].Y + (lenght + 1) * 20), new Size(20, 20));
                }
            }
            for (int q = 0; q < listhumps.Count; q++) // humps
            {
                if (listhumps[q].Y < deletedLayers[lenght] * 20)
                {
                    listhumps[q] = new Rectangle(new Point(listhumps[q].X, listhumps[q].Y + (lenght + 1) * 20), new Size(20, 20));
                }
            }
            for (int q = 0; q < listbeds.Count; q++) // beds
            {
                if (listbeds[q].Y < deletedLayers[lenght] * 20)
                {
                    listbeds[q] = new Rectangle(new Point(listbeds[q].X, listbeds[q].Y + (lenght + 1) * 20), new Size(20, 20));
                }
            }
        }

        /// <summary>
        /// Удаление заполненного слоя кубиков (номера заполненных слоев передаются в аргумент функции).
        /// </summary>
        /// <param name="ii"></param>
        void ClearLayers(int[] numOfLayer)

        {
            lenght = numOfLayer.Length - 1;
            if (lenght >= 0)
            {
                Music(); // Проигрывает музыку при удалении нескольких слоев и звуки удаления.
            }
            for (int i = 0; i < numOfLayer.Length; i++)
            {
                list.RemoveAll(ex => ex.Y == numOfLayer[i] * 20); // Непосредственное удаление слоя.
            }
            // Удаление слоев из дополнительных списков, необходимых для отрисовки фигур разными текстурами.
            for (int i = 0; i < numOfLayer.Length; i++)
            {
                listsquares.RemoveAll(ex => ex.Y == numOfLayer[i] * 20);
            }
            for (int i = 0; i < numOfLayer.Length; i++)
            {
                listlines.RemoveAll(ex => ex.Y == numOfLayer[i] * 20);
            }
            for (int i = 0; i < numOfLayer.Length; i++)
            {
                listangles.RemoveAll(ex => ex.Y == numOfLayer[i] * 20);
            }
            for (int i = 0; i < numOfLayer.Length; i++)
            {
                listzigzags.RemoveAll(ex => ex.Y == numOfLayer[i] * 20);
            }
            for (int i = 0; i < numOfLayer.Length; i++)
            {
                listhumps.RemoveAll(ex => ex.Y == numOfLayer[i] * 20);
            }
            for (int i = 0; i < numOfLayer.Length; i++)
            {
                listbeds.RemoveAll(ex => ex.Y == numOfLayer[i] * 20); 
            }
            if (numOfLayer.Length == 1) // Если удалили только один слой.
            {
                Shift(numOfLayer);
                ScoreNum.Text = (Convert.ToInt32(ScoreNum.Text) + 200 * x).ToString();
                l.Text = "+200";
                Scoring(numOfLayer[lenght]);
            }
            else if (numOfLayer.Length == 2)
            {
                //Передвижение на 2 слоя.
                Shift(numOfLayer);
                ScoreNum.Text = (Convert.ToInt32(ScoreNum.Text) + 350 * x).ToString();
                HowCoolAreYou(numOfLayer);
            }
            else if (numOfLayer.Length == 3)
            {
                //Передвижение на 3 слоя.             
                Shift(numOfLayer);
                ScoreNum.Text = (Convert.ToInt32(ScoreNum.Text) + 500 * x).ToString();
                HowCoolAreYou(numOfLayer);
            }
            else
            {
                //Передвижение на  n слоев.
                Shift(numOfLayer);
                ScoreNum.Text = (Convert.ToInt32(ScoreNum.Text) + 600 * x).ToString();
                HowCoolAreYou(numOfLayer); // cooler.Text = GODLIKE
            }
            if (FallingTimer.Interval >= 100 || FallingTimer.Interval == 35) // Ускорение фигур после удаления слоя(слоев) и добавления очков.
            {
                FallingTimer.Interval -= (int)(FallingTimer.Interval * 0.05); // Ускорение на 5%.
            }
        }

        /// <summary>
        /// Проигрывает музыку при удалении нескольких слоев и звуки удаления слоев.
        /// </summary>
        void Music()
        {
            if ((lenght + 1) == 1) // Звуки при удалении слоя(слоев) на разных уровнях игры.
            {
                player3.URL = "Всплеск.mp3";
                if (UserControl1.level == 2)
                {
                    player3.URL = "Топор.mp3";
                }
                if (UserControl1.level == 3)
                {
                    player3.URL = "Вулкан.mp3";
                }
                player3.settings.volume = 20; // Громкость.
                player3.controls.play();
                return;
            }
            // Музыка.
            else if ((lenght + 1) == 2)
            {
                player2.URL = "DoubleKill.mp3";
            }
            else if ((lenght + 1) == 3)
            {
                player2.URL = "TripleKill.mp3";
            }
            else if ((lenght + 1) > 3)
            {
                player2.URL = "GodLike.mp3";
            }

            player2.controls.play();
        }

        /// <summary>
        /// Проверяет слоя на заполнение и отправляет данные о заполненных слоях.
        /// </summary>
        void Glass()
        {
            List<int> layerNum = new List<int>();
            layerNum.Clear();
            for (int i = 0; i < mas.Count; i++) // Обнуляем массив, он нужен для отображения количества фигур на каждом слое.
            {
                mas[i] = 0;
            } 
            foreach (Rectangle item in list)
            {
                for (int i = 24; i >= 0; i--) // Снизу вверх проверяем заполненность слоев.
                {
                    if (item.Y == i * 20)
                    {
                        mas[i]++; // Считаем сколько элементов находится на слое i.
                        break;
                    }
                }
            }
            for (int i = 24; i >= 0; i--) // Если один из элементов массива = 10, значит по его индексу слой заполнен.
            {
                if (mas[i] == 10)
                {
                    layerNum.Add(i); // Добавляем номер слоя, который нужно удалить, так как он заполнен.
                }
            }
            if (layerNum.Count != 0)
            {
                ClearLayers(layerNum.ToArray()); // Передаем значения.
            }
        }
        #endregion

        #region Scoring
        /// <summary>
        /// Отображение полученных очков при уничтожении слоя(слоев).
        /// </summary>
        /// <param name="numOfLayer"></param>
        void Scoring(int numOfLayer)
        {
            l.Parent = TetrisField; // Прозрачность контрола относительно игрового поля.
            // Случайное положение текста в области удаленного слоя.
            l.Location = new Point(random.Next(20, 150), random.Next(numOfLayer * 20 - 20, numOfLayer * 20 - 10)); 
            ClearL();
        }
        /// <summary>
        /// Выводит очки и запускает таймеры движения фигур.
        /// </summary>
        async private void ClearL() 
        {
            MovingTimer.Start();   // Запуск таймеров для продолжение игры.
            FallingTimer.Start();  // 
            l.BringToFront();       //
            l.Visible = true;       // Вывод очков на экран.
            await Task.Delay(800);  //
            l.Visible = false;      
        }
        #endregion

        #region ToolBar
        private void authorToolStripMenuItem_Click(object sender, EventArgs e) //Author click
        {
            if (MenuForm.enru)
            {
                MessageBox.Show("Ткачев Даниил", "Автор", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Tkachev Daniil", "Author", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        bool pause = false;
        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pause)
            {
                MovingTimer.Stop();
                FallingTimer.Stop();
                pause = true;
                PauseBut.Visible = true;
                pauseStripMenuItem1.Image = Properties.Resources.Play;
            }
            else
            {
                MovingTimer.Start();
                FallingTimer.Start();
                pause = false;
                PauseBut.Visible = false;
                pauseStripMenuItem1.Image = Properties.Resources.Pause;
            }
        }
        private void pauseToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            if (!pause)
            {
                pauseStripMenuItem1.Image = Properties.Resources.Play;
            }
            else
            {
                pauseStripMenuItem1.Image = Properties.Resources.Pause;
            }
        }

        private void pauseToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            if (!pause)
            {
                pauseStripMenuItem1.Image = Properties.Resources.Pause;
            }
            else
            {
                pauseStripMenuItem1.Image = Properties.Resources.Play;
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #region Music
        private void musicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MenuForm.music)
            {
                player.controls.pause(); // не работает переключение музыки
                musicStripMenuItem1.Image = Properties.Resources.ВЫКЛЛ;
                MenuForm.music = !MenuForm.music;
            }
            else
            {
                player.controls.play();
                musicStripMenuItem1.Image = Properties.Resources.ВКЛЛ;
                MenuForm.music = !MenuForm.music;
            }
        }
        private void musicToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            if (MenuForm.music)
            {
                musicStripMenuItem1.Image = Properties.Resources.ВЫКЛЛ;
            }
            else
            {
                musicStripMenuItem1.Image = Properties.Resources.ВКЛЛ;
            }
        }

        private void musicToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            if (MenuForm.music)
            {
                musicStripMenuItem1.Image = Properties.Resources.ВКЛЛ;
            }
            else
            {
                musicStripMenuItem1.Image = Properties.Resources.ВЫКЛЛ;
            }
        }
        #endregion
        public void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MovingTimer.Stop();
            FallingTimer.Stop();
            obstaclesBool = false;
            FallingTimer.Interval = 800;
            if (UserControl1.difficulty >= 2)
            {
                grid = false;
                FallingTimer.Interval = 600;
                x = 1.5;
                if (UserControl1.difficulty == 3)
                {
                    x = 2.5;
                    FallingTimer.Interval = 400;
                    shadowON = false;
                    ObstaclesGenerator.Enabled = true;
                    ObstaclesDelete.Enabled = true;
                    ObstaclesGenerator.Start();
                    ObstaclesDelete.Start();
                }
            }
            value = rnd.Next(6);
            list.Clear();
            bottom = false;
            listangles.Clear();
            fangle.Clear();
            listzigzags.Clear();
            fzigzag.Clear();
            listsquares.Clear();
            fsquare.Clear();
            listlines.Clear();
            fline.Clear();
            listbeds.Clear();
            fbed.Clear();
            listhumps.Clear();
            fhump.Clear();
            if (Gameover)
            {
                Gameover = false;
                if (MenuForm.enru)
                {
                    alertwin.OK.Text = "Еще раз";
                    alertwin.Alert.Text = $"Ваш счет: { ScoreNum.Text}";
                }
                else
                {
                    alertwin.OK.Text = "Again";
                    alertwin.Alert.Text = $"Your score: { ScoreNum.Text}";
                }

            }
            else
            {
                alertwin.OK.Text = "OK";
                if (MenuForm.enru)
                {
                    alertwin.Alert.Text = "Новая игра";
                }
                else
                {
                    alertwin.Alert.Text = "New Game";
                }
            }
            alertwin.Alert.Font = new Font(alertwin.Alert.Font.Name, 16);
            alertwin.OK.Click += new EventHandler(NewGame);
            alertwin.Exit.Click += new EventHandler(Exit);
            void NewGame(object s, EventArgs ex)
            {
                MovingTimer.Start(); FallingTimer.Start();
                alertwin.Close();
            }
            void Exit(object s, EventArgs ex)
            {
                alertwin.Close();
            }
            alertwin.StartPosition = FormStartPosition.CenterParent;
            alertwin.Opacity = 0.97;
            alertwin.ShowDialog();
            try
            {
                Score = Convert.ToInt32(ScoreNum.Text);
            }
            catch
            {
                Score = (int)Convert.ToDouble(ScoreNum.Text);
            }
            if (Account.ScoreRecord < Score)
            {
                Account.ScoreRecord = Score;
            }
            ScoreNum.Text = "0";
            Thread.Sleep(500);
            ResetTools();
        }

        AlertWin alertwin = new AlertWin();
        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Score = Convert.ToInt32(ScoreNum.Text);
            MovingTimer.Stop();
            FallingTimer.Stop();
            UserControl1 userControl = new UserControl1();
            Form form = Application.OpenForms[0];
            MenuForm.close = false;
            this.Hide();
            form.Show();
            if (Account.ScoreRecord < Score)
            {
                Account.ScoreRecord = Score;
            }
            ScoreNum.Text = "0";
        }

        private void OK_Click(object sender, EventArgs args)
        {
            alertwin.Close();
        }
        bool noClose = false;
        private void Exit_Click(object sender, EventArgs args)
        {
            noClose = true;
            alertwin.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            ((Control)sender).Capture = false;
            Message m = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        #endregion

        #region Falling

        /// <summary>
        /// Реализует падение фигуры
        /// </summary>
        /// <param name="rec"></param>
        void Falling(List<Rectangle> rec)
        {
            foreach (Rectangle item in list) //Если фигура касается существующих, то начинается падание новой фигуры.
            {
                if (rec.Exists(ex => ex.Location == new Point(item.X, item.Y - 20)))
                {
                    bottom = true; // Имитация касания фигурой нижний границы.
                    break;
                }

            }
            if (!bottom)
            {
                for (int g = 0; g < 4; g++) //Реализация падения фигур.
                {
                    rec[g] = new Rectangle(rec[g].Location.X, rec[g].Location.Y + 20, 20, 20);
                }

                if (rec.Exists(ex => ex.Y == 480)) //Обработка касания дна стакана.
                {
                    bottom = true;
                }
            }
            IfStuckInFigure(rec); //Проверка на застревание в уже существующих фигурах при опускании.
            StuckInTheBottom(rec);
        }
        /// <summary>
        /// Выталкивает фигуру, если она застряла в дне стакана.
        /// </summary>
        /// <param name="rec"></param>
        void StuckInTheBottom(List<Rectangle> rec)
        {
        L:
            if (rec.Exists(ex => ex.Y > 480)) // Если фигура расположена ниже границы стакана.
            {
                for (int g = 0; g < 4; g++) // Выталкивание.
                {
                    rec[g] = new Rectangle(new Point(rec[g].X, rec[g].Y - 20), new Size(20, 20));
                }
                goto L; // Многократная проверка застревания.
            }
        }
        #endregion

        #region Obstacles
        private void ObstaclesGenerator_Tick(object sender, EventArgs e)
        {
            GeneratingObstacles(current);
        }
        int type = 0;
        bool obstaclesBool = false;
        Random types = new Random();
        Random RanShape = new Random();
        List<Rectangle> obstaclesList = new List<Rectangle>();
        /// <summary>
        /// Генерирует препятствия.
        /// </summary>
        /// <param name="rec"></param>
        void GeneratingObstacles(List<Rectangle> rec)
        {
            obstaclesBool = true; // Отвечает за включение препятствий в игре.
            type = types.Next(5); // Случайное число для выбора типа преграды.
            switch (type) // Генерация одного из 5 типов барьера.
            {
                case 0:
                    obstaclesList.Add(new Rectangle(RanShape.Next(0, 9) * 20, RanShape.Next(7, 15) * 20, 20, 20));
                    obstaclesList.Add(new Rectangle(obstaclesList[0].X + 20, obstaclesList[0].Y, 20, 20));
                    break;
                case 1:
                case 2:
                    obstaclesList.Add(new Rectangle(RanShape.Next(0, 9) * 20, RanShape.Next(7, 15) * 20, 20, 20));
                    obstaclesList.Add(new Rectangle(obstaclesList[0].X - 20, obstaclesList[0].Y, 20, 20));
                    obstaclesList.Add(new Rectangle(obstaclesList[0].X + 20, obstaclesList[0].Y, 20, 20));
                    obstaclesList.Add(new Rectangle(obstaclesList[0].X + 20, obstaclesList[0].Y - 20, 20, 20));
                    break;
                case 3:
                    obstaclesList.Add(new Rectangle(RanShape.Next(0, 9) * 20, RanShape.Next(7, 15) * 20, 20, 20));
                    obstaclesList.Add(new Rectangle(obstaclesList[0].X - 20, obstaclesList[0].Y, 20, 20));
                    obstaclesList.Add(new Rectangle(obstaclesList[0].X - 20, obstaclesList[0].Y + 20, 20, 20));
                    obstaclesList.Add(new Rectangle(obstaclesList[0].X, obstaclesList[0].Y + 20, 20, 20));
                    break;
                case 4:
                    obstaclesList.Add(new Rectangle(RanShape.Next(0, 9) * 20, RanShape.Next(7, 15) * 20, 20, 20));
                    obstaclesList.Add(new Rectangle(obstaclesList[0].X - 20, obstaclesList[0].Y, 20, 20));
                    obstaclesList.Add(new Rectangle(obstaclesList[0].X + 20, obstaclesList[0].Y, 20, 20));
                    break;
            }
            DeleteIfOverlay(); // Удаляет преградау если она перекрывает установленные фигуры. 
            if (TooCloseToFigure(rec)) // Если препятствие появляется сразу под фигурой - оно удаляется.
            {
                obstaclesList.Clear();
                obstaclesList.Add(new Rectangle());
            }
        }
        /// <summary>
        /// Осведомляет о генерации препятствия под падающей фигурой.
        /// </summary>
        /// <param name="rec"></param>
        /// <returns></returns>
        bool TooCloseToFigure(List<Rectangle> rec)
        {
            foreach (Rectangle item in obstaclesList)
            {
                // Если преграда в границе, то она удаляется.
                if (!rec.Exists(ex => (ex.Location.X == item.Location.X) && (ex.Location.Y >= item.Location.Y + 60)))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Удаление препятствий.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ObstaclesDelete_Tick(object sender, EventArgs e)
        {
            if (obstaclesList.Count == 0) { return; }
            else
            {
                obstaclesList.Clear();
            }
        }
        /// <summary>
        /// Останавливает фигуры, если они касаются препятствия.
        /// </summary>
        /// <param name="rec"></param>
        void StopingFigureByObstacles(List<Rectangle> rec)
        {
            // Если фигура касается припятствия, начинается падание новой фигуры.
            foreach (Rectangle item in obstaclesList) 
            {
                if (rec.Exists(ex => ex.Location == new Point(item.X, item.Y - 20)))
                {
                    bottom = true; // Имитация касания нижний границы.
                    break;
                }
            }
            //Проверка на застревание фигуры в препятствии.
        L:
            for (int i = 0; i < rec.Count; i++)
            {
                if (obstaclesList.Exists(ex => ex.Location == rec[i].Location))
                {
                    // Выталкивание из преграды.
                    rec[i] = new Rectangle(new Point(rec[i].X, rec[i].Y - 20), new Size(20, 20)); 
                }
                else { return; }
            }
            goto L;
        }
        /// <summary>
        /// Если препятствие перекрывает существующие фигуры - оно удаляется.
        /// </summary>
        void DeleteIfOverlay()
        {
            for (int q = 0; q < list.Count; q++)
            {
                // Если препятствие перекрывает установленную фигуру(фигуры), мы его удаляем.
                if (obstaclesList.Exists(ex => (ex.Location == list[q].Location)))
                {
                    obstaclesList.Clear();
                    obstaclesList.Add(new Rectangle());
                    return;
                }
            }
        }
        #endregion

        #region Blackout
        /// <summary>
        /// Этот метод срабатывает, если под фигурой нет других фигур.
        /// </summary>
        void WhenNothing()
        {
            while (!shadow.Exists(ex => ex.Y == 480)) // Пока не произошло застревание фигуры.
            {
                for (int i = 0; i < shadow.Count; i++) // Опускаем тень на нижнюю границу.
                {
                    shadow[i] = new Rectangle(new Point(shadow[i].X, shadow[i].Y + 20), new Size(20, 20));
                }
            }
        }
        /// <summary>
        /// Находит на каком уровне должна находится тень, чтобы не пересекать фигуры.
        /// </summary>
        /// <param name="shadow"></param>
        /// <returns></returns>
        int SeekingRightPositionForShadow(List<Rectangle> shadow)
        {
            // Опускание до соприкосновения с фигурой в стакане. Каждая итерация для каждой высоты.
            do
            {
                if (list.Count == 0) // Если еще нет установленных фигур.
                {
                    WhenNothing();
                    return 0;
                }
                foreach (Rectangle item in shadow)
                {
                    for (int q = 0; q < list.Count; q++)
                    {
                        // Условие на соответствие диапазону по координате Х. Где min, max границы тени фигуры по координате Х.
                        if (list[q].X >= min & list[q].X <= max) 
                        {
                            // Ничего не делаем, если под тенью еще есть свободное пространство.
                            if (list[q].Y != item.Y + 20 * counter & list[q].X == item.X)
                            {  }
                            else if (list[q].Y == item.Y + 20 * counter & list[q].X == item.X)
                            { return counter - 1; } // Возвращаем номер слоя до контакта с фигурами.
                        }
                    }
                }
                counter++; // Следующая высота.
                // Если в диапазоне по координате Х нет фигур, возвращаем 0.
                if (!list.Exists(ex => ex.X >= min & ex.X <= max))
                { WhenNothing(); return 0; }
            }
            while (true);
        }

        List<Rectangle> shadow = new List<Rectangle>(4) { new Rectangle(), new Rectangle(), new Rectangle(), new Rectangle() };
        int max = 0, min = 0, counter = 0;
        /// <summary>
        /// Формирует тень под фигурой
        /// </summary>
        /// <param name="rec"></param>
        void Blackout(List<Rectangle> rec)
        {
            // Копируем rec в список shadow.
            for (int i = 0; i < shadow.Count & rec.Count == shadow.Count; i++)
            {
                shadow[i] = new Rectangle(new Point(rec[i].X, rec[i].Y), new Size(20, 20));
            }
            for (int i = 0; i < shadow.Count; i++)
            {
                if (i == 0 || shadow[i].X > max)
                {
                    max = shadow[i].X; // Максимальное знач. Х
                }

                if (i == 0 || shadow[i].X < min)
                {
                    min = shadow[i].X; // Минимальное знач. Х
                }
            }
            counter = SeekingRightPositionForShadow(shadow); // Уровень на который нужно опустить тень.
            for (int i = 0; i < shadow.Count; i++) // Опускаем тень на дно стакана.
            {
                shadow[i] = new Rectangle(new Point(shadow[i].X, shadow[i].Y + 20 * counter), new Size(20, 20));
            }
            counter = 0; // Обнуляем уровень.
            StuckInTheBottom(shadow);
            IfStuckInFigure(shadow);
        }
        /// <summary>
        /// Проверка застревания в фигурах.
        /// </summary>
        /// <param name="rec"></param>
        void IfStuckInFigure(List<Rectangle> rec)
        {
        L:
            for (int i = 0; i < rec.Count; i++)
            {
                if (list.Exists(ex => ex.Location == rec[i].Location))
                {
                    rec[i] = new Rectangle(new Point(rec[i].X, rec[i].Y - 20), new Size(20, 20));
                }
                else { return; }
            }
            goto L;
        }
        #endregion

        #region Drawing
        Random r = new Random();
        private void ChangingBackGround_Tick(object sender, EventArgs e)
        {
            int i = r.Next(3);
            switch (i)
            {
                case 0:
                    if (UserControl1.level == 1)
                    {
                        BackgroundImage = Properties.Resources.Пляж2;
                    }
                    else if (UserControl1.level == 2)
                    {
                        BackgroundImage = Properties.Resources.Ручей;
                    }
                    else if (UserControl1.level == 3)
                    {
                        BackgroundImage = Properties.Resources.Dragon_438x607;
                    }

                    break;

                case 1:
                    if (UserControl1.level == 1)
                    {
                        BackgroundImage = Properties.Resources.Пляж3;
                    }
                    else if (UserControl1.level == 2)
                    {
                        BackgroundImage = Properties.Resources.Водопад;
                    }
                    else if (UserControl1.level == 3)
                    {
                        BackgroundImage = Properties.Resources.Дракон2;
                    }

                    break;

                case 2:
                    if (UserControl1.level == 1)
                    {
                        BackgroundImage = Properties.Resources.Пляж1;
                    }
                    else if (UserControl1.level == 2)
                    {
                        BackgroundImage = Properties.Resources._438х607Jungle;
                    }
                    else if (UserControl1.level == 3)
                    {
                        BackgroundImage = Properties.Resources.Дракон3;
                    }

                    break;
            }
        }

        /// <summary>
        /// Отрисовка фигур, которые появятся следующими
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {

            switch (valuee) // 190, 164 (95,82) - середина
            {
                case 0:
                    //angle
                    e.Graphics.FillRectangles(angless, new Rectangle[] { new Rectangle(new Point(85, 52), new Size(20, 60)), new Rectangle(new Point(65, 92), new Size(20, 20)) });
                    break;
                case 1:
                    //square
                    e.Graphics.FillRectangles(squaress, new Rectangle[] { new Rectangle(new Point(75, 62), new Size(40, 40)) });
                    break;
                case 2:
                    //line
                    e.Graphics.FillRectangle(liness, new Rectangle(new Point(85, 42), new Size(20, 80)));
                    break;
                case 3:
                    //zigzag
                    e.Graphics.FillRectangles(zigzagss, new Rectangle[] { new Rectangle(new Point(65, 62), new Size(40, 20)), new Rectangle(new Point(85, 82), new Size(40, 20)) });
                    break;
                case 4:
                    //hump
                    e.Graphics.FillRectangles(humpss, new Rectangle[] { new Rectangle(new Point(65, 82), new Size(60, 20)), new Rectangle(new Point(85, 62), new Size(20, 20)) });
                    break;
                case 5:
                    //bed
                    e.Graphics.FillRectangles(bedss, new Rectangle[] { new Rectangle(new Point(65, 82), new Size(60, 20)), new Rectangle(new Point(105, 62), new Size(20, 20)) });
                    break;
            }
        }
        /// <summary>
        /// Отрисовка основной формы игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox2_Paint(object sender, PaintEventArgs e)
        {
            //create borders
            e.Graphics.DrawRectangle(new Pen(frime, 2), new Rectangle(1, 1, 198, 498));
            //Grid
            if (grid)
            {
                //Строим координатную сетку вдоль Х
                for (int i = 1; i <= TetrisField.Height / 20; i++)
                {
                    e.Graphics.DrawLine(new Pen(Brushes.DarkGray, 1), new Point(2, i * 20), new Point(TetrisField.Width - 2, i * 20));
                }
                //Строим координатную сетку вдоль Y
                for (int i = 1; i <= TetrisField.Width / 20; i++)
                {
                    e.Graphics.DrawLine(new Pen(Brushes.DarkGray, 1), new Point(i * 20, 2), new Point(i * 20, TetrisField.Height - 2));
                }
            }
            if (list.Exists(ex => ex.Y == 20))
            {
                Gameover = true;
                newGameToolStripMenuItem_Click(sender, new EventArgs());
                return;
            }
            switch (value)
            {
                case 0:
                    #region angle
                    if (shadowON)
                    {
                        Blackout(fangle);
                        e.Graphics.FillRectangles(Brushes.Gray, shadow.ToArray());
                    }
                    if (fangle.Count > 0)
                    {
                        e.Graphics.FillRectangles(angle, fangle.ToArray());
                    }
                    #endregion
                    break;
                case 1:
                    #region square                   
                    if (shadowON)
                    {
                        Blackout(fsquare);
                        e.Graphics.FillRectangles(Brushes.Gray, shadow.ToArray());
                    }
                    if (fsquare.Count > 0)
                    {
                        e.Graphics.FillRectangles(square, fsquare.ToArray());
                    }
                    #endregion
                    break;
                case 2:
                    #region line
                    if (shadowON)
                    {
                        Blackout(fline);
                        e.Graphics.FillRectangles(Brushes.Gray, shadow.ToArray());
                    }
                    if (fline.Count > 0)
                    {
                        e.Graphics.FillRectangles(line, fline.ToArray());
                    }
                    #endregion
                    break;
                case 3:
                    #region zigzag
                    if (shadowON)
                    {
                        Blackout(fzigzag);
                        e.Graphics.FillRectangles(Brushes.Gray, shadow.ToArray());
                    }
                    if (fzigzag.Count > 0)
                    {
                        e.Graphics.FillRectangles(zigzag, fzigzag.ToArray());
                    }
                    #endregion
                    break;
                case 4:
                    #region hump
                    if (shadowON)
                    {
                        Blackout(fhump);
                        e.Graphics.FillRectangles(Brushes.Gray, shadow.ToArray());
                    }
                    if (fhump.Count > 0)
                    {
                        e.Graphics.FillRectangles(hump, fhump.ToArray());
                    }
                    #endregion
                    break;
                case 5:
                    #region bed
                    if (shadowON)
                    {
                        Blackout(fbed);
                        e.Graphics.FillRectangles(Brushes.Gray, shadow.ToArray());
                    }
                    if (fbed.Count > 0)
                    {
                        e.Graphics.FillRectangles(bed, fbed.ToArray());
                    }
                    #endregion
                    break;
            }
            if (list.Count >= 10)
            {
                Glass();
            }

            try
            {
                e.Graphics.FillRectangles(all, listangles.ToArray());
                e.Graphics.FillRectangles(all, listsquares.ToArray());
                e.Graphics.FillRectangles(all, listlines.ToArray());
                e.Graphics.FillRectangles(all, listzigzags.ToArray());
                e.Graphics.FillRectangles(all, listhumps.ToArray());
                e.Graphics.FillRectangles(all, listbeds.ToArray());
                if (obstaclesBool)
                {
                    e.Graphics.FillRectangles(obstacles, obstaclesList.ToArray());
                }
            }
            catch
            { }

        }
        #endregion
        public void MainGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Account.ScoreRecord < Convert.ToInt32(ScoreNum.Text))
            {
                Account.ScoreRecord = Convert.ToInt32(ScoreNum.Text);
            }
        }
    }
}
