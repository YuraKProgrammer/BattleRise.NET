using BattleRise.Models;
using BattleRise.Models.Fighters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            var types = typeof(IFighter).Assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Where(t => typeof(IFighter).IsAssignableFrom(t));
            types = types.OrderBy(t =>
            {
                var atr = t.GetCustomAttribute<FighterAttribute>();
                return atr.Name;
            });
            foreach (var type in types)
            {
                var atr = type.GetCustomAttribute<FighterAttribute>();
                MenuItem mi = new MenuItem
                {
                    Header = atr.Name,
                    IsCheckable = true,
                    Tag = type
                };
                mi.Checked += Mi_Checked;
                mi_type.Items.Add(mi);
            }
            _battle = new Battle(1920, 1080);
            DrawBattleField();
            _timer = new System.Timers.Timer() { Interval = TimerInterval.TotalMilliseconds, AutoReset = true};
            _timer.Elapsed += OnTimer;
        }

        private void Mi_Checked(object sender, RoutedEventArgs e)
        {
            var checkedMi = (MenuItem)sender;
            var t = (Type)checkedMi.Tag;
            var ft = t.GetCustomAttribute<FighterAttribute>().FighterType;
            _selectedFighter = ft;
            foreach(MenuItem mi in mi_type.Items)
            {
                if (mi != checkedMi)
                    mi.IsChecked = false;
            }
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
            var x = (int)(pos.X - _fighterImageSize / 2);
            var y = (int)(pos.Y - _fighterImageSize / 2);
            if (Friend.IsChecked == true)
            {
                _selectedSide = Side.Friend;
            }
            if (Enemy.IsChecked == true)
            {
                _selectedSide = Side.Enemy;
            }
            IFighter currentFighter = new Warrior(_selectedFighterLevel, x, y, _selectedSide);
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
            if (_selectedFighter == FighterType.Goblin)
            {
                currentFighter = new Goblin(_selectedFighterLevel, x, y, _selectedSide);
            }
            if (_selectedFighter == FighterType.Orc)
            {
                currentFighter = new Orc(_selectedFighterLevel, x, y, _selectedSide);
            }
            if (_selectedFighter == FighterType.Troll)
            {
                currentFighter = new Troll(_selectedFighterLevel, x, y, _selectedSide);
            }
            if (_selectedFighter == FighterType.Magician)
            {
                currentFighter = new Magician(_selectedFighterLevel, x, y, _selectedSide);
            }
            _battle.EmptyAddFighterToBattle(currentFighter);
            DrawBattleField();
        }
    }
}

