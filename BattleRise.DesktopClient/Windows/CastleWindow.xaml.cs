using System;
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
        private IFighter _currentFighter = new Warrior(1, 1, 1, Side.Friend);
        private int[] _fightersLevels;
        private Army _army;
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
            if (_castleLevel >= 1)
            {
                if (!_fighters.ContainsKey(0))
                {
                    _fighters.Add(0, new Warrior(_fightersLevels[0], 1, 1, Side.Friend));
                }
                else
                {
                    _fighters.Remove(0);
                    _fighters.Add(0, new Warrior(_fightersLevels[0], 1, 1, Side.Friend));
                }
            }
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
            text_namelevel.Text = _currentFighter.GetName() + " " + _currentFighter.GetLevel() + " уровня";
            text_health.Text = "Здоровье: " + _currentFighter.GetHealth();
            text_damage.Text = "Урон: " + _currentFighter.GetDamage();
            text_speed.Text = "Скорость: " + _currentFighter.GetSpeed();
            text_range.Text = "Дальность: " + _currentFighter.GetRange();
            button_buy.Content = "Купить за " + _currentFighter.GetCost();
            button_levelUp.Content = "Улучшить за " + _currentFighter.GetLevelUpCost();
        }

        public void OnBuyClick(object sender, RoutedEventArgs e)
        {
            if (_currentFighter.GetCost() <= _coins)
            {
                _coins -= _currentFighter.GetCost();
                _army.AddFighter(_currentFighter);
                Update();
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
        }

        public void OnExitClick(object sender, RoutedEventArgs e)
        {
            var window = new GameWindow(new Save(DateTime.Now, _userId, new Resources(_coins, _diamonds), _army, _fightersLevels, _castleLevel)) { Owner = this };
            window.Show();
        }
    }
}
