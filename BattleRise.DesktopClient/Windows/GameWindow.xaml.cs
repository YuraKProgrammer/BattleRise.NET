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
        private const int secLevelCost = 2500;
        private const int maxCatleLevel = 5;
        private int levelUpCost;
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
            text_Res.Text = "Монеты: " + _coins + " Алмазы: " + _diamonds + " Армия: " + _army.GetFighters().Count();
            text_CastleLevel.Text = "Замок Уровень: "+_castleLevel.ToString();
            levelUpCost = (int)(secLevelCost * Math.Pow(2, _castleLevel - 1));
            button_LevelUp.Content = "Улучшить за " + levelUpCost;
        }
        
        public void CastLevelUp(object sender, RoutedEventArgs e)
        { 
            if (_coins >= levelUpCost && _castleLevel+1<=maxCatleLevel)
            {
                _coins -= levelUpCost;
                _castleLevel++;
                Update();
            }
        }

        public void ComeInClick(object sender, RoutedEventArgs e)
        {
            var window = new CastleWindow(new Save(_saveTime, _userId, new Resources(_coins, _diamonds), _army, _fightersLevels, _castleLevel));
            window.ShowDialog();
        }
    }
}