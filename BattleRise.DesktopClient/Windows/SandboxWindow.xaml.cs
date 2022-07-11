using BattleRise.Models;
using BattleRise.Models.Fighters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace BattleRise.DesktopClient.Windows
{
    /// <summary>
    /// Interaction logic for SandboxWindow.xaml
    /// </summary>
    public partial class SandboxWindow : Window
    {
        private Battle _battle;
        private int _fighterImageSize = 40;
        private FighterType _selectedFighter;
        private int _selectedFighterLevel=0;
        private Side _selectedSide=Side.Friend;
        private readonly System.Timers.Timer _timer;
        private static readonly TimeSpan TimerInterval = TimeSpan.FromMilliseconds(150); 

        public SandboxWindow()
        {
            InitializeComponent();
            _battle = new Battle(1920, 1080);
            DrawBattleField();
            _timer = new System.Timers.Timer() { Interval = TimerInterval.TotalMilliseconds, AutoReset = true};
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
            if (_battle._fullArmy.GetFighters().Where(f => f.GetSide() == Side.Enemy) == null)
            {
                _timer.Stop();
                Start.IsEnabled = false;
                Pause.IsEnabled = false;
                MessageBox.Show("Вы победили!", "Победа");
            }
            if (_battle._fullArmy.GetFighters().Where(f => f.GetSide() == Side.Friend) == null)
            {
                _timer.Stop();
                Start.IsEnabled = false;
                Pause.IsEnabled = false;
                MessageBox.Show("Вы проиграли!", "Проигрыш");
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

        private void CheckSelectedFighter()
        {
            if (_warrior.IsChecked == true)
            {
                _selectedFighter = FighterType.Warrior;
            }
            if (_archer.IsChecked == true)
            {
                _selectedFighter = FighterType.Archer;
            }
            if (_zombie.IsChecked == true)
            {
                _selectedFighter = FighterType.Zombie;
            }
            if (_skeleton.IsChecked == true)
            {
                _selectedFighter = FighterType.Skeleton;
            }
            if (_littleGiant.IsChecked == true)
            {
                _selectedFighter = FighterType.LittleGiant;
            }
            if (_knight.IsChecked == true)
            {
                _selectedFighter = FighterType.Knight;
            }
            if (Friend.IsChecked == true)
            {
                _selectedSide = Side.Friend;
            }
            if (Enemy.IsChecked == true)
            {
                _selectedSide = Side.Enemy;
            }
            if (level.Text != null)
            {
                _selectedFighterLevel = Int32.Parse(level.Text);
            }
            else
                _selectedFighterLevel = 1;
        }

        private void SetFighterOnField(object sender, MouseButtonEventArgs e)
        {
            var pos = e.GetPosition(_canvas);
            var x = (int)(pos.X - _fighterImageSize / 2);
            var y = (int)(pos.Y - _fighterImageSize / 2);
            IFighter currentFighter = new Warrior(_selectedFighterLevel, x, y, _selectedSide);
            CheckSelectedFighter();
            if (_selectedFighter == FighterType.Warrior)
            {
                currentFighter = new Warrior(_selectedFighterLevel, x, y, _selectedSide);
            }
            if (_selectedFighter == FighterType.Archer)
            {
                currentFighter = new Archer(_selectedFighterLevel, x, y, _selectedSide);
            }
            if (_selectedFighter == FighterType.Zombie)
            {
                currentFighter = new Zombie(_selectedFighterLevel, x, y, _selectedSide);
            }
            if (_selectedFighter == FighterType.Skeleton)
            {
                currentFighter = new Skeleton(_selectedFighterLevel, x, y, _selectedSide);
            }
            if (_selectedFighter == FighterType.LittleGiant)
            {
                currentFighter = new LittleGiant(_selectedFighterLevel, x, y, _selectedSide);
            }
            if (_selectedFighter == FighterType.Knight)
            {
                currentFighter = new Knight(_selectedFighterLevel, x, y, _selectedSide);
            }
            _battle.EmptyAddFighterToBattle(currentFighter);
            DrawBattleField();
        }
    }
}

