﻿using System;
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
using BattleRise.Models;
using BattleRise.Models.Fighters;

namespace BattleRise.DesktopClient.Windows
{
    /// <summary>
    /// Interaction logic for CastleWindow.xaml
    /// </summary>
    public partial class CastleWindow : Window
    {
        private int _coins;
        private int _diamonds;
        private int _castleLevel;
        private int _userId;
        private Dictionary<int, IFighter> _fighters = new Dictionary<int, IFighter>();
        private int _currentfighterNumber;
        private IFighter _currentFighter = new Warrior(1,1,1,Side.Friend);
        private int[] _fightersLevels;
        private Army _army;
        private const int x = 0;
        private const int y = 0;
        private const Side side = Side.Friend;
        private FightersLoader fightersLoader = new FightersLoader();
        public CastleWindow(Save save)
        {
            InitializeComponent();
            _coins = save.res.coins;
            _diamonds = save.res.diamonds;
            _fightersLevels = save.fightersLevels;
            _castleLevel = save.castleLevel;
            _userId = save.userId;
            _currentfighterNumber = 0;
            _army = save.army;
            LoadFighters();
            Update();
        }

        private void LoadFighters()
        {
            _fighters = fightersLoader.Load(_castleLevel,_fighters,_fightersLevels);
        }

        public void Update()
        {
            if (_army.GetFighters() != null)
            {
                text_money.Text = "Монеты: " + _coins + " Алмазы: " + _diamonds + " Армия: " + _army.GetFighters().Count();
            }
            else
            {
                text_money.Text = "Монеты: " + _coins + " Алмазы: " + _diamonds + " Армия: 0";
            }
            _fighters.TryGetValue(_currentfighterNumber, out _currentFighter);
            if (_currentFighter != null)
            {
                text_namelevel.Text = _currentFighter.GetName() + " " + _currentFighter.GetLevel() + " уровня";
                text_health.Text = "Здоровье: " + _currentFighter.GetHealth();
                text_damage.Text = "Урон: " + _currentFighter.GetDamage();
                text_speed.Text = "Скорость: " + _currentFighter.GetSpeed();
                text_range.Text = "Дальность: " + _currentFighter.GetRange();
                var element = _currentFighter.GetElement();
                text_element.Text = "Стихия: " + GetElementName(element);
                button_buy.Content = "Купить за " + _currentFighter.GetCost();
                button_levelUp.Content = "Улучшить за " + _currentFighter.GetLevelUpCost();
                DrawImage();
            }
        }

        private string GetElementName(Element element)
        {
            switch (element)
            {
                case Element.Fire: return "Огонь";
                case Element.Wind: return "Ветер";
                case Element.Earth: return "Земля";
                case Element.Water: return "Вода";
                case Element.Life: return "Жизнь";
                case Element.Energy: return "Энергия";
                case Element.Metal: return "Металл";
                case Element.Strength: return "Сила";
                case Element.Destruction: return "Разрушение";
                case Element.Creation: return "Создание";
                case Element.Shadow: return "Тень";
                case Element.Light: return "Свет";
                case Element.Recovery: return "Восстановление";
                case Element.Random: return "Случайность";
                default: return "Земля";
            }
        }

        private void DrawImage()
        {
            _image.Source = new BitmapImage(_currentFighter.GetFileFolder());
        }

        public void OnBuyClick(object sender, RoutedEventArgs e)
        {
            if (_currentFighter.GetCost() <= _coins)
            {
                _coins -= _currentFighter.GetCost();
                _army.AddFighter(_currentFighter);
                Update();
            }
            else
            {
                MessageBox.Show("Недостаточно монет", "Предупреждение");
            }
        }

        public void OnLevelUpClick(object sender, RoutedEventArgs e)
        {
            if (_currentFighter.GetLevelUpCost() <= _coins)
            {
                _coins -= _currentFighter.GetLevelUpCost();
                _fightersLevels[_currentfighterNumber]++;
                LoadFighters();
                Update();
            }
            else
            {
                MessageBox.Show("Недостаточно монет", "Предупреждение");
            }
        }

        public void OnExitClick(object sender, RoutedEventArgs e)
        {
            var window = new GameWindow(new Save(DateTime.Now, _userId, new Resources(_coins, _diamonds), _army, _fightersLevels, _castleLevel)) { Owner = this };
            window.ShowDialog();
        }

        public void OnNextClick(object sender, RoutedEventArgs e)
        {
            if (_currentfighterNumber+1 > _fighters.Count() - 1)
            {
                _currentfighterNumber = 0;
            }
            else
            {
                _currentfighterNumber++;
            }
            Update();
        }

        public void OnPreviousClick(object sender, RoutedEventArgs e)
        {
            if (_currentfighterNumber-1 < 0)
            {
                _currentfighterNumber = _fighters.Count() - 1;
            }
            else
            {
                _currentfighterNumber--;
            }
            Update();
        }
    }
}
