using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using WMPLib;

namespace Tetris_
{
    public partial class MenuForm : Form
    {
        public static bool music = true;
        static public string Hi { get; set; }
        string timeHello { get; set; }
        public static bool enru { get; set; }
        public ToolTip tip = new ToolTip();
        public static bool close { get; set; }
        int error = 0;
        SqlConnection sqlCon;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Acer\Desktop\Tetris+\Tetris+\Database.mdf;Integrated Security=True";
        public MenuForm()
        {
            InitializeComponent();
            Music2();
            if (Properties.Settings.Default.UserName != string.Empty)
            {
                textBox.Text = Properties.Settings.Default.UserName;
                checkBox.Checked = true;
            }
            sqlCon = new SqlConnection(connectionString);
            tip.SetToolTip(Music, $"Background music ON/OFF.");
        }
        void Music2()
        {
            IWMPPlaylist list = openPlaylist("playlist");
            MainGameForm.player.settings.volume = 7;
            if (list.count > 0)
            {
                MainGameForm.player.currentPlaylist = list;
                MainGameForm.player.settings.setMode("loop", true);
                MainGameForm.player.controls.play();
            }
        }
        /// <summary>
        /// Создает плейлист с музыкой, составленной в случайной последовательности.
        /// </summary>
        /// <param name="playlistName"></param>
        /// <returns></returns>
        private IWMPPlaylist openPlaylist(string playlistNam)
        {
            IWMPPlaylist playlist = MainGameForm.player.newPlaylist(playlistNam, null); // Создание пустого плейлиста.
            string[] original = File.ReadAllLines(playlistNam + ".txt"); // Читает содержимое файла.
            string[] shuffled = original.OrderBy(line => Guid.NewGuid()).ToArray(); // Перемещивание списка песен.
            File.WriteAllLines("playlistName.txt", shuffled); // Записывает список музыки в файл "playlistName.txt".
            // Создаем SteamReader для списка музыки.
            using (System.IO.StreamReader sr =
                new System.IO.StreamReader(System.IO.Directory.GetCurrentDirectory() + @"\" + "playlistName.txt"))
            {               
                while (sr.Peek() >= 0) // Выполняется пока есть символы в файле.
                {
                    string mediaUrl = sr.ReadLine(); // Чтение строки.
                    IWMPMedia media = MainGameForm.player.newMedia(mediaUrl); //Создание медиа по URL.
                    playlist.appendItem(media); // Добавляем медиа к плейлисту.
                }
                return playlist; // Возвращаем плейлист.
            }
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Accept_Click(object sender, EventArgs e)
        {
            userControl11.Load_Frame(false, 1500);
            SqlCommands();
            if (error == 1)
            {
                Application.Restart();
                return;
            }
            Accountization();
            Remember();
            ChangingDesign();
            userControl11.MeetHello.Text = $"{timeHello}, {Account.AccountName}";
            textBox.Hide();
            Accept.Hide();
            Hello.Hide();
            checkBox.Hide();
            Exit.Location = new Point(398, 0);
            Music.Location = new Point(358, 0);
            EnRu.Location = new Point(322, 0);
            userControl11.Focus();
            userControl11.Visible = true;           
            this.Size = new Size(438, 577);
            this.Location = new Point(this.Location.X, this.Location.Y - 130);
        }

        void Remember()
        {
            if (checkBox.Checked)
            {
                Properties.Settings.Default.UserName = textBox.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.UserName = string.Empty;
                Properties.Settings.Default.Save();
            }
        }

        List<string> Names = new List<string>();
        /// <summary>
        /// Выполнение запросов в базу данных.
        /// </summary>
        async void SqlCommands()
        {
            AlertWin alertwin = new AlertWin(); // Создание окна выдачи ошибок.
            // Запросы в базу данных
            string sqlExpressionAllName = $"SELECT Name FROM DB";                                     
            string sqlExpressionScoreAtName = $"SELECT Score FROM DB WHERE Name = '{textBox.Text}'"; 
            bool nameIsExist = false;
            try
            {
                await sqlCon.OpenAsync(); // Асинхронное открытие соединения. Для предотвращения зависания приложения.
                // Проверка имени введенного пользователем.
                if (!string.IsNullOrWhiteSpace(textBox.Text) && !string.IsNullOrEmpty(textBox.Text)) 
                {
                    // Создание Sql комманд
                    SqlCommand comAllName = new SqlCommand(sqlExpressionAllName, sqlCon);                            
                    SqlCommand comScoreAtName = new SqlCommand(sqlExpressionScoreAtName, sqlCon);                    
                    SqlCommand com = new SqlCommand("INSERT INTO [DB] (Name, Score)VALUES(@Name, @Score)", sqlCon);  
                    SqlDataReader reader = await comAllName.ExecuteReaderAsync(); // Вызывается столбец Name.
                    while (await reader.ReadAsync()) // Все полученные значения записываются в список Names.
                    {
                        Names.Add(reader.GetString(0));
                    }
                    reader.Close();
                    foreach (string name in Names) // Проверка каждого name на соответствие с textbox.Text.
                    {
                        if (textBox.Text == name)
                        {
                            // В ScoreRecord, InitialScore записывается значение соот. имени пользователя.
                            Account.ScoreRecord = Convert.ToInt32(await comScoreAtName.ExecuteScalarAsync());
                            //Для дополнительной проверки на соответствие.
                            Account.InitialScore = Convert.ToInt32(await comScoreAtName.ExecuteScalarAsync());
                            nameIsExist = true;
                        }
                    }
                    // Если такое имя пользователя используется впервые, то Score = 0.
                    if (!nameIsExist)
                    {
                        com.Parameters.AddWithValue("Name", textBox.Text);
                        com.Parameters.AddWithValue("Score", 0);
                        await com.ExecuteNonQueryAsync();
                    }
                    error = 0; // Блок успешно завершился.
                }
                else // Имя пользователя не заполнено.
                {
                    if (MenuForm.enru)
                    {
                        alertwin.Alert.Text = $"Поле с именем пользователя должно быть заполнено.";
                    }
                    else
                    {
                        alertwin.Alert.Text = $"Username must be filled out";
                    }
                    alertwin.Alert.Font = new Font(alertwin.Alert.Font.Name, 16);
                    alertwin.OK.Click += new EventHandler(OK);
                    alertwin.Exit.Click += new EventHandler(OK);
                    void OK(object s, EventArgs ex)
                    {
                        alertwin.Close();
                    }
                    alertwin.StartPosition = FormStartPosition.CenterParent;
                    alertwin.Opacity = 0.97;
                    alertwin.ShowDialog();
                    error = 1; // Вывод текста на экран и отправка номера ошибки.
                }
            }
            catch (Exception e) 
            {
                alertwin.Alert.Text = e.Message;
                alertwin.Alert.Font = new Font(alertwin.Alert.Font.Name, 12);
                alertwin.OK.Click += new EventHandler(OK);
                alertwin.Exit.Click += new EventHandler(OK);
                void OK(object s, EventArgs ex)
                {
                    alertwin.Close();
                }
                alertwin.StartPosition = FormStartPosition.CenterParent;
                alertwin.Opacity = 0.97;
                alertwin.ShowDialog();
                error = 2; // В случае непредвиденной ситуации вывод текст ошибки и отправка ее номера.
            }
            finally
            {
                if (sqlCon.State != System.Data.ConnectionState.Closed && sqlCon != null)
                {
                    sqlCon.Close(); // Закрываем соединение.
                }

            }
        }
        void ChangingDesign()
        {
            switch (UserControl1.level)
            {
                case 1:
                case 0:
                    Exit.BackColor = SystemColors.GradientInactiveCaption;
                    Exit.FlatAppearance.MouseDownBackColor = SystemColors.GradientActiveCaption;
                    Exit.FlatAppearance.MouseOverBackColor = SystemColors.Control;
                    Music.BackColor = SystemColors.GradientInactiveCaption;
                    Music.FlatAppearance.MouseDownBackColor = SystemColors.GradientActiveCaption;
                    Music.FlatAppearance.MouseOverBackColor = SystemColors.Control;
                    EnRu.BackColor = SystemColors.GradientInactiveCaption;
                    EnRu.FlatAppearance.MouseDownBackColor = SystemColors.GradientActiveCaption;
                    EnRu.FlatAppearance.MouseOverBackColor = SystemColors.Control;
                    break;
                case 2:
                    Exit.BackColor = Color.SeaGreen;
                    Exit.FlatAppearance.MouseDownBackColor = Color.ForestGreen;
                    Exit.FlatAppearance.MouseOverBackColor = Color.MediumSeaGreen;
                    Music.BackColor = Color.SeaGreen;
                    Music.FlatAppearance.MouseDownBackColor = Color.ForestGreen;
                    Music.FlatAppearance.MouseOverBackColor = Color.MediumSeaGreen;
                    EnRu.BackColor = Color.SeaGreen;
                    EnRu.FlatAppearance.MouseDownBackColor = Color.ForestGreen;
                    EnRu.FlatAppearance.MouseOverBackColor = Color.MediumSeaGreen;
                    break;
                case 3:
                    Exit.BackColor = Color.DarkRed;
                    Exit.FlatAppearance.MouseDownBackColor = Color.Firebrick;
                    Exit.FlatAppearance.MouseOverBackColor = SystemColors.Info;
                    Music.BackColor = Color.DarkRed;
                    Music.FlatAppearance.MouseDownBackColor = Color.Firebrick;
                    Music.FlatAppearance.MouseOverBackColor = SystemColors.Info;
                    EnRu.BackColor = Color.DarkRed;
                    EnRu.FlatAppearance.MouseDownBackColor = Color.Firebrick;
                    EnRu.FlatAppearance.MouseOverBackColor = SystemColors.Info;
                    break;
            }
        }

        void Accountization()
        {
            Time();
            Account.AccountName = $"{textBox.Text}";
        }

        void Time()
        {
            int time = DateTime.Now.Hour;

            if (time >= 12 & time <= 18)
            {
                if (enru)
                {
                    timeHello = "Добрый день";
                }
                else
                {
                    timeHello = "Good afternoon";
                }
            }
            else if (time >= 4 & time < 12)
            {
                if (enru)
                {
                    timeHello = "Доброе утро";
                }
                else
                {
                    timeHello = "Good morning";
                }
            }
            else if (time > 18 & time <= 22)
            {
                if (enru)
                {
                    timeHello = "Добрый вечер";
                }
                else
                {
                    timeHello = "Good evening";
                }
            }
            else if ((time >= 0 & time < 4) || time == 23)
            {
                if (enru)
                {
                    timeHello = "Здравствуйте";
                }
                else
                {
                    timeHello = "Good night";
                }
            }
        }
        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            Capture = false;
            Message m = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            ((Control)sender).Capture = false;
            Message m = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        #region Music
        private void Music_MouseEnter(object sender, EventArgs e)
        {
            if (music)
            {
                Music.BackgroundImage = Properties.Resources.ВЫКЛЛ;
            }
            else
            {
                Music.BackgroundImage = Properties.Resources.ВКЛЛ;
            }
        }

        private void Music_MouseLeave(object sender, EventArgs e)
        {
            if (music)
            {
                Music.BackgroundImage = Properties.Resources.ВКЛЛ;
            }
            else
            {
                Music.BackgroundImage = Properties.Resources.ВЫКЛЛ;
            }
        }
        private void Music_MouseClick(object sender, MouseEventArgs e)
        {
            if (music)
            {
                MainGameForm.player.controls.pause();
                Music.BackgroundImage = Properties.Resources.ВЫКЛЛ;
                music = !music;
            }
            else
            {
                MainGameForm.player.controls.play();
                Music.BackgroundImage = Properties.Resources.ВКЛЛ;
                music = !music;
            }
        }

        #endregion

        private void EnRu_Click(object sender, EventArgs e)
        {
            enru = !enru;
            if (UserControl1.level == 2)
            {
                if (userControl11.lev == "Jungle")
                {
                    userControl11.lev = "Джунгли";
                }
                else
                {
                    userControl11.lev = "Jungle";
                }
            }
            else if (UserControl1.level == 3)
            {
                if (userControl11.lev == "Volcano")
                {
                    userControl11.lev = "Вулкан";
                }
                else
                {
                    userControl11.lev = "Volcano";
                }
            }
            else
            {
                if (userControl11.lev == "Beach")
                {
                    userControl11.lev = "Пляж";
                }
                else
                {
                    userControl11.lev = "Beach";
                }
            }
            if (UserControl1.difficulty == 2)
            {
                if (userControl11.dif == "Medium")
                {
                    userControl11.dif = "Нормально";
                }
                else
                {
                    userControl11.dif = "Medium";
                }
            }
            else if (UserControl1.difficulty == 3)
            {
                if (userControl11.dif == "Hard")
                {
                    userControl11.dif = "Профи";
                }
                else
                {
                    userControl11.dif = "Hard";
                }
            }
            else
            {
                if (userControl11.dif == "Easy")
                {
                    userControl11.dif = "Легко";
                }
                else
                {
                    userControl11.dif = "Easy";
                }
            }
            Time();
            userControl11.LevelDif();
            userControl11.MeetHello.Text = $"{timeHello}, {Account.AccountName}";
            if (enru)
            {
                EnRu.Text = "RU";
                Accept.Text = "Принять";
                Hello.Text = "Введите имя пользователя";
                checkBox.Text = "Запомнить меня";
                userControl11.Start.Text = "Старт";
                userControl11.Difficulty.Text = "Сложность";
                userControl11.Level.Text = "Выбор уровня";
                userControl11.Easy.Text = "Легко";
                userControl11.Medium.Text = "Нормально";
                userControl11.Hard.Text = "Профи";
                userControl11.Back.Text = "Назад";
                userControl11.Beach.Text = "Пляж";
                userControl11.Jungle.Text = "Джунгли";
                userControl11.Volcano.Text = "Вулкан";
                userControl11.Control_Keys.Text = "Управление";
                tip.SetToolTip(Music, $"Музыкальное сопровождение ВКЛ/ВЫКЛ.");
            }
            else
            {
                EnRu.Text = "EN";
                Accept.Text = "Accept";
                Hello.Text = "Enter your profil name";
                checkBox.Text = "Remember me";
                userControl11.Start.Text = "Start";
                userControl11.Difficulty.Text = "Difficulty";
                userControl11.Level.Text = "Select Level";
                userControl11.Easy.Text = "Easy";
                userControl11.Medium.Text = "Medium";
                userControl11.Hard.Text = "Hard";
                userControl11.Back.Text = "Back";
                userControl11.Beach.Text = "Beach";
                userControl11.Jungle.Text = "Jungle";
                userControl11.Volcano.Text = "Volcano";
                userControl11.Control_Keys.Text = "Control keys";
                tip.SetToolTip(Music, $"Background music ON/OFF.");
            }
        }
        int save = 1;
        public static bool first = false;
        private void ChangeButton_Tick(object sender, EventArgs e)
        {
            if (MenuForm.enru)
            {
                userControl11.Record.Text = $"Ваш рекорд: {Account.ScoreRecord}";
            }
            else
            {
                userControl11.Record.Text = $"Your record: {Account.ScoreRecord}";
            }
            if (UserControl1.level != save)
            {
                ChangingDesign();
            }
            save = UserControl1.level;
            if (close)
            {
                Hide();
            }
            if (UserControl1.changeSize)
            {
                this.Size = new Size(560, 577);
                if (first)
                {
                    this.Location = new Point(this.Location.X - 61, this.Location.Y);
                    first = false;
                }
                Exit.Location = new Point(520, 0);
                Music.Location = new Point(480, 0);
                EnRu.Location = new Point(444, 0);
            }
            else if (!UserControl1.changeSize && userControl11.Visible)
            {
                this.Size = new Size(438, 577);
                if (first)
                {
                    this.Location = new Point(this.Location.X + 61, this.Location.Y);
                    first = false;
                }
                Exit.Location = new Point(398, 0);
                Music.Location = new Point(358, 0);
                EnRu.Location = new Point(322, 0);
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainGameForm game = new MainGameForm();
            game.MainGameForm_FormClosing(sender, e);
            if (textBox.Text == string.Empty) { return; }
            try
            {
                if (Account.ScoreRecord > Account.InitialScore)
                {
                    string sqlExpression = $"UPDATE DB SET Score = {Account.ScoreRecord.ToString()} WHERE Name = '{textBox.Text}'";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlExpression, connection);
                        int a = command.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
            }
        }
    }
}

