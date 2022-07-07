using BattleRise.Models;
using BattleRise.Models.Fighters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for BattleWindow.xaml
    /// </summary>
    public partial class BattleWindow : Window
    {
        private Battle _battle;
        private Army _army;
        private int _coins;
        private int _fighterImageSize = 40;
        public BattleWindow(Save save, Level level)
        {
            InitializeComponent();
            _battle = new Battle(level, 1920, 1080);
            _army = save.army;
            _coins = save.res.coins;
            DrawBackground();
            DrawArmy();
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
    }
}
