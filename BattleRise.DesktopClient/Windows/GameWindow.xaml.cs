﻿using System;
using System.Collections.Generic;
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
using BattleRise.Models;
using BattleRise.SaveStorage;

namespace BattleRise.DesktopClient.Windows
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private DateTime _saveTime;
        private int _userId;
        private int[] _fightersLevels;
        private Army _army;
        private int _coins;
        private int _diamonds;
        private int _castleLevel;
        private const int _secLevelCost = 2500;
        private const int _maxCatleLevel = 10;
        private int _levelUpCost;
        private MainWindow _mainWindow;
        private TempSaveStorage _saveStorage = new TempSaveStorage();
        public GameWindow(Save save, MainWindow mainWindow)
        {
            InitializeComponent();
            _saveTime = save.saveTime;
            _userId = save.userId;
            _fightersLevels = save.fightersLevels;
            _army = save.army;
            _coins = save.res.coins;
            _diamonds = save.res.diamonds;
            _castleLevel = save.castleLevel;
            _mainWindow = mainWindow;
            Update();
        }

        private void Update()
        {
            if (_army.GetFighters() != null)
            {
                text_Res.Text = "Монеты: " + _coins + " Алмазы: " + _diamonds + " Армия: " + _army.GetFighters().Count();
            }
            else
            {
                text_Res.Text = "Монеты: " + _coins + " Алмазы: " + _diamonds + " Армия: 0";
            }
            text_CastleLevel.Text = "Замок " + _castleLevel.ToString()+" уровня";
            _levelUpCost = (int)(_secLevelCost * Math.Pow(2, _castleLevel - 1));
            button_LevelUp.Content = "Улучшить за " + _levelUpCost;
        }

        public void CastLevelUp(object sender, RoutedEventArgs e)
        {
            if (_coins >= _levelUpCost)
            {
                if (_castleLevel+1 <= _maxCatleLevel)
                {
                    _coins -= _levelUpCost;
                    _castleLevel++;
                    Update();
                }
                else
                {
                    MessageBox.Show("Достигнут максимальный уровень","Предупреждение");
                }
            }
            else
            {
                MessageBox.Show("Недостаточно монет", "Предупреждение");
            }
        }

        public void ComeInClick(object sender, RoutedEventArgs e)
        {
            var window = new CastleWindow(new Save(_saveTime, _userId, new Resources(_coins, _diamonds), _army, _fightersLevels, _castleLevel), _mainWindow);
            window.ShowDialog();
        }

        public void OnSaveClick(object sender, RoutedEventArgs e)
        {
            _saveStorage.Save(new Save(DateTime.Now, _userId, new Resources(_coins, _diamonds), _army, _fightersLevels, _castleLevel));
            MessageBox.Show("Игра сохранена", "Сохранение");
        }

        public void OnSaveExitClick(object sender, RoutedEventArgs e)
        {
            _saveStorage.Save(new Save(DateTime.Now, _userId, new Resources(_coins, _diamonds), _army, _fightersLevels, _castleLevel));
            MessageBox.Show("Игра сохранена", "Сохранение");
            _mainWindow.Close();
            DialogResult = true;
        }

        public void OnChooseLevelClick(object sender, RoutedEventArgs e)
        {
            var window = new ChooseLevelWindow(new Save(_saveTime, _userId, new Resources(_coins, _diamonds), _army, _fightersLevels, _castleLevel), _mainWindow) { Owner = this };
            window.ShowDialog();
        }

        public void OnSandboxClick(object sender, RoutedEventArgs e)
        {
            var window = new SandboxWindow();
            window.ShowDialog();
        }
    }
}