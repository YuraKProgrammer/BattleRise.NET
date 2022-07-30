using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
        private MainWindow _mainWindow;
        private FightersLoader fightersLoader = new FightersLoader();
        public CastleWindow(Save save, MainWindow mainWindow)
        {
            InitializeComponent();
            _coins = save.res.coins;
            _diamonds = save.res.diamonds;
            _fightersLevels = save.fightersLevels;
            _castleLevel = save.castleLevel;
            _userId = save.userId;
            _currentfighterNumber = 0;
            _army = save.army;
            _mainWindow = mainWindow;
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
            var fields = typeof(Element).GetFields().Where(f => f.FieldType == typeof(Element));
            foreach(var field in fields)
            {
                if ((int)field.GetValue(element) == (int)element)
                {
                    var e = field.GetCustomAttribute<ElementAttribute>();
                    return e.Name;
                }
            }
            throw new NotImplementedException();
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
            var window = new GameWindow(new Save(DateTime.Now, _userId, new Resources(_coins, _diamonds), _army, _fightersLevels, _castleLevel), _mainWindow) { Owner = this };
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
