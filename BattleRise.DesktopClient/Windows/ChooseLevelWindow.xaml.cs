using BattleRise.Models;
using BattleRise.LevelStorage;
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

namespace BattleRise.DesktopClient.Windows
{
    /// <summary>
    /// Interaction logic for ChooseLevelWindow.xaml
    /// </summary>
    ///
    public partial class ChooseLevelWindow : Window
    {
        private Save _save;
        private int _currentLevelNumber = 0;
        private List<Level> _levels = new List<Level>();
        private TempLevelStorage _levelStorage = new TempLevelStorage();
        public ChooseLevelWindow(Save save)
        {
            InitializeComponent();
            _save = save;
            if (save.army.GetFighters() != null)
            {
                text_army.Text = "Армия: "+save.army.GetFighters().Count();
            }
            else
            {
                text_army.Text = "Армия: 0";
            }
            LoadLevels();
            Update();
            TuneControls();
        }

        private void Update()
        {
            text_name.Text = _levels.ToArray()[_currentLevelNumber]._name;
            text_reward.Text = _levels.ToArray()[_currentLevelNumber]._reward+" монет";
            text_countOfFighters.Text = "Вражеская армия:" + _levels.ToArray()[_currentLevelNumber]._enemyArmy.GetArmySize();
        }

        private void LoadLevels()
        {
            _levels.Add(new Level(150, new Army(new List<IFighter>() { new Warrior(1, 500, 100, Side.Enemy) }),"1 level"));
            _levels.Add(new Level(200, new Army(new List<IFighter>() { new Warrior(1, 500, 100, Side.Enemy), new Warrior(1, 500, 200, Side.Enemy) }),"2 level"));
            _levels.Add(new Level(300, new Army(new List<IFighter>() { new Warrior(2, 500, 100, Side.Enemy), new Warrior(2, 500, 200, Side.Enemy) }),"3 level"));
        }

        public void OnStartClick(object sender, RoutedEventArgs e)
        {
        }

        public void OnPreviousClick(object sender, RoutedEventArgs e)
        {
            if (_currentLevelNumber-- < 0)
            {
                _currentLevelNumber = _levels.Count() - 1;
            }
            else
            {
                _currentLevelNumber--;
            }
            Update();
        }
        public void OnNextClick(object sender, RoutedEventArgs e)
        {
            if (_currentLevelNumber++ > _levels.Count() - 1)
            {
                _currentLevelNumber = 0;
            }
            else
            {
                _currentLevelNumber++;
            }
            Update();
        }
        public void OnExitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TuneControls()
        {
            if (_save.army.GetArmySize() == 0)
            {
                button_battle.IsEnabled = false;
            }
        }
    }
}
