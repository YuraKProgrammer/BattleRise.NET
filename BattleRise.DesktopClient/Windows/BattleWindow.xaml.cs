using BattleRise.Models;
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
        private int _fighterImageSize = 40;
        private FighterType _selectedFighter;
        private readonly System.Timers.Timer _timer;
        private static readonly TimeSpan TimerInterval = TimeSpan.FromMilliseconds(150);
        public BattleWindow(Save save, Level level)
        {
            InitializeComponent();
            _battle = new Battle(level, 1920, 1080);
            _army = save.army;
            _coins = save.res.coins;
            DrawBattleField();
            _timer = new System.Timers.Timer() { Interval = TimerInterval.TotalMilliseconds, AutoReset = true };
            _timer.Elapsed += OnTimer;
        }

        private void OnTimer(object sender, ElapsedEventArgs e)
        {
            this.Do(() =>
            {
                _battle.Act();
                DrawBattleField();
                WinnerCheck();
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
                    Task.Delay(2000);
                    this.Close();
                }
                if (_battle._fullArmy.GetFighters().Where(f => f.GetSide() == Side.Friend).Count() == 0)
                {
                    _timer.Stop();
                    Start.IsEnabled = false;
                    Pause.IsEnabled = false;
                    MessageBox.Show("Вы проиграли!", "Проигрыш");
                    Task.Delay(2000);
                    this.Close();
                }
            }
        }

        private void StartClick(object sender, EventArgs e)
        {
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
            BitmapImage bitmapImage = new BitmapImage(new Uri(@"D:\images\background.jpg", UriKind.Absolute));
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
                bitmapImage = new BitmapImage(new Uri(fighter.GetFileFolder(), UriKind.Absolute));
            }
            else
            {
                bitmapImage = new BitmapImage(new Uri(fighter.GetFileFolderEnemy(), UriKind.Absolute));
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
            var x = (int)(pos.X - _fighterImageSize / 2);
            var y = (int)(pos.Y - _fighterImageSize / 2);
            IFighter currentFighter = null;
            _battle.AddFighterToBattle(_army, currentFighter);
            DrawBattleField();
        }
    }
}
