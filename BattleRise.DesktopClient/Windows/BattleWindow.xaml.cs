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
        private FighterType _selectedFighter;
        public BattleWindow(Save save, Level level)
        {
            InitializeComponent();
            _battle = new Battle(level, 1920, 1080);
            _army = save.army;
            _coins = save.res.coins;
            DrawBattleField();
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
        }

        private void SetFighterOnField(object sender, MouseButtonEventArgs e)
        {
            var pos = e.GetPosition(_canvas);
            var x = (int)(pos.X - _fighterImageSize / 2);
            var y = (int)(pos.Y - _fighterImageSize / 2);
            IFighter currentFighter = new Warrior(1, x, y, Side.Friend);
            CheckSelectedFighter();
            if (_selectedFighter == FighterType.Warrior)
            {
                currentFighter = new Warrior(1, x, y, Side.Friend);
            }
            if (_selectedFighter == FighterType.Archer)
            {
                currentFighter = new Archer(1, x, y, Side.Friend);
            }
            if (_selectedFighter == FighterType.Zombie)
            {
                currentFighter = new Zombie(1, x, y, Side.Friend);
            }
            if (_selectedFighter == FighterType.Skeleton)
            {
                currentFighter = new Skeleton(1, x, y, Side.Friend);
            }
            if (_selectedFighter == FighterType.LittleGiant)
            {
                currentFighter = new LittleGiant(1, x, y, Side.Friend);
            }
            _battle.AddFighterToBattle(_army, currentFighter);
            DrawBattleField();
        }
    }
}
