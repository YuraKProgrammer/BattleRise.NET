﻿using BattleRise.Models;
using BattleRise.Models.Fighters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BattleRise.DesktopClient.UserControls;
using System.Diagnostics;

namespace BattleRise.DesktopClient.Windows
{
    /// <summary>
    /// Interaction logic for BattleWindow.xaml
    /// </summary>
    public partial class BattleWindow : Window
    {
        private Battle _battle;
        private Army _army;
        private int _coins;
        private int _diamonds;
        private int _reward;
        private int _userId;
        private int _castleLevel;
        private int[] _fightersLevels;
        private int _fighterImageSize = 40;
        private MainWindow _mainWindow;
        private readonly System.Timers.Timer _timer;
        private static readonly TimeSpan TimerInterval = TimeSpan.FromMilliseconds(150);
        public BattleWindow(Save save, Level level, MainWindow mainWindow)
        {
            InitializeComponent();
            _battle = new Battle(level, 1920, 1080);
            _army = save.army;
            _coins = save.res.coins;
            _diamonds = save.res.diamonds;
            _userId = save.userId;
            _reward = level._reward;
            _fightersLevels = save.fightersLevels;
            _castleLevel = save.castleLevel;
            DrawBattleField();
            ArmyToFightersPanel();
            _timer = new System.Timers.Timer() { Interval = TimerInterval.TotalMilliseconds, AutoReset = true };
            _timer.Elapsed += OnTimer;
            _mainWindow = mainWindow;
        }

        private void ArmyToFightersPanel()
        {
            var fighters = _army.GetFighters();
            var groups = fighters
                .GroupBy(f => f.GetHashCode())
                .Select(gr => new FightersGroup(gr.First(), gr.Count()))
                .ToArray();
            _fp._lb.ItemsSource = groups;
        }

        private void OnTimer(object sender, ElapsedEventArgs e)
        {
            this.Do(() =>
            {
                _battle.Act();
                DrawBattleField();
                WinnerCheck();
                ArmyToFightersPanel();
            });
        }

        private void WinnerCheck()
        {
            if (_battle._fullArmy.GetFighters().Count() == 0)
            {
                _timer.Stop();
                Start.IsEnabled = false;
                Pause.IsEnabled = false;
                MessageBox.Show("Ничья!", "Ничья");
                Task.Delay(2000);
                this.Close();
            }
            else
            {
                if (_battle._fullArmy.GetFighters().Where(f => f.GetSide() == Side.Enemy).Count() == 0)
                {
                    _timer.Stop();
                    Start.IsEnabled = false;
                    Pause.IsEnabled = false;
                    MessageBox.Show("Вы победили!", "Победа");
                    _coins = _coins + _reward;
                    var window = new GameWindow(new Save(DateTime.Now, _userId, new Models.Resources(_coins,_diamonds), _army, _fightersLevels, _castleLevel), _mainWindow);
                    window.ShowDialog();
                }
                if (_battle._fullArmy.GetFighters().Where(f => f.GetSide() == Side.Friend).Count() == 0)
                {
                    _timer.Stop();
                    Start.IsEnabled = false;
                    Pause.IsEnabled = false;
                    MessageBox.Show("Вы проиграли!", "Проигрыш");
                    var window = new GameWindow(new Save(DateTime.Now, _userId, new Models.Resources(_coins, _diamonds), _army, _fightersLevels, _castleLevel), _mainWindow);
                    window.ShowDialog();
                }
            }
        }

        private void StartClick(object sender, EventArgs e)
        {
            if (s1.IsChecked == true)
            {
                TimeSpan ts = TimeSpan.FromMilliseconds(300);
                _timer.Interval = ts.TotalMilliseconds;
            }
            if (s2.IsChecked == true)
            {
                TimeSpan ts = TimeSpan.FromMilliseconds(225);
                _timer.Interval = ts.TotalMilliseconds;
            }
            if (s3.IsChecked == true)
            {
                TimeSpan ts = TimeSpan.FromMilliseconds(150);
                _timer.Interval = ts.TotalMilliseconds;
            }
            if (s4.IsChecked == true)
            {
                TimeSpan ts = TimeSpan.FromMilliseconds(112);
                _timer.Interval = ts.TotalMilliseconds;
            }
            if (s5.IsChecked == true)
            {
                TimeSpan ts = TimeSpan.FromMilliseconds(75);
                _timer.Interval = ts.TotalMilliseconds;
            }
            _timer.Start();
            Start.IsEnabled = false;
            Pause.IsEnabled = true;
        }

        private void PauseClick(object sender, EventArgs e)
        {
            _timer.Stop();
            Pause.IsEnabled = false;
            Start.IsEnabled = true;
        }

        private void OnExit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DrawBackground()
        {
            BitmapImage bitmapImage = new BitmapImage(new Uri(@"/BattleRise.DesktopClient;component/images/background.jpg", UriKind.RelativeOrAbsolute));
            System.Windows.Controls.Image backgroundImage = new System.Windows.Controls.Image();
            backgroundImage.Source = bitmapImage;
            Canvas.SetLeft(backgroundImage, 0);
            Canvas.SetTop(backgroundImage, 0);
            _canvas.Children.Add(backgroundImage);
        }

        private void DrawBattleField()
        {
            _canvas.Children.Clear();
            DrawBackground();
            DrawArmy();
        }

        private void DrawArmy()
        {
            var fighters = _battle._fullArmy.GetFighters();
            foreach (var fighter in fighters)
            {
                DrawFighter(fighter);
            }
        }

        private void DrawFighter(IFighter fighter)
        {
            var bitmapImage = new BitmapImage();
            if (fighter.GetSide() == Side.Friend)
            {
                bitmapImage = new BitmapImage(fighter.GetFileFolder());
            }
            else
            {
                bitmapImage = new BitmapImage(fighter.GetFileFolderEnemy());
            }
            System.Windows.Controls.Image image = new System.Windows.Controls.Image();
            image.Width = _fighterImageSize;
            image.Height = _fighterImageSize;
            image.Source = bitmapImage;
            Canvas.SetLeft(image, fighter.GetX());
            Canvas.SetTop(image, fighter.GetY());
            _canvas.Children.Add(image);
        }

        private void SetFighterOnField(object sender, MouseButtonEventArgs e)
        {
            var pos = e.GetPosition(_canvas);
            var px = (int)(pos.X - _fighterImageSize / 2);
            var py = (int)(pos.Y - _fighterImageSize / 2);
            IFighter currentFighter = null;
            currentFighter = _fp.GetSelectedFighter();
            if (currentFighter != null)
            {
                currentFighter.SetX(px);
                currentFighter.SetY(py);
                _army = _battle.AddFighterToBattle(_army, currentFighter); 
            }
            ArmyToFightersPanel();
            DrawBattleField();
        }
    }
}
