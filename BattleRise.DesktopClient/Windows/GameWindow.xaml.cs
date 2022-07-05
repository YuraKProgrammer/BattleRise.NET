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
        private List<int> _fightersLevels;
        private Army _army;
        private int _coins;
        private int _diamonds;
        private int _castleLevel;
        private const int _secLevelCost = 2500;
        private const int _maxCatleLevel = 5;
        private int _levelUpCost;
        private TempSaveStorage _saveStorage = new TempSaveStorage();
        public GameWindow(Save save)
        {
            InitializeComponent();
            _saveTime = save.saveTime;
            _userId = save.userId;
            _fightersLevels = save.fightersLevels;
            _army = save.army;
            _coins = save.res.coins;
            _diamonds = save.res.diamonds;
            _castleLevel = save.castleLevel;
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
                text_Res.Text = "Монеты: " + _coins + " Алмазы: " + _diamonds + " Армия: НЕТ";
            }
            text_CastleLevel.Text = "Замок Уровень: "+_castleLevel.ToString();
            _levelUpCost = (int)(_secLevelCost * Math.Pow(2, _castleLevel - 1));
            button_LevelUp.Content = "Улучшить за " + _levelUpCost;
        }
        
        public void CastLevelUp(object sender, RoutedEventArgs e)
        { 
            if (_coins >= _levelUpCost && _castleLevel+1<=_maxCatleLevel)
            {
                _coins -= _levelUpCost;
                _castleLevel++;
                Update();
            }
        }

        public void ComeInClick(object sender, RoutedEventArgs e)
        {
            var window = new CastleWindow(new Save(_saveTime, _userId, new Resources(_coins, _diamonds), _army, _fightersLevels, _castleLevel));
            window.ShowDialog();
        }

        public void OnSaveClick(object sender, RoutedEventArgs e)
        {
            _saveStorage.Save(new Save(DateTime.Now, _userId, new Resources(_coins, _diamonds), _army, _fightersLevels, _castleLevel));
        }
    }
}