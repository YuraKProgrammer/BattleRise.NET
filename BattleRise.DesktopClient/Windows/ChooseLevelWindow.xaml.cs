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
using BattleRise.Models.Fighters;

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
        private LevelsLoader levelsLoader = new LevelsLoader();
        private MainWindow _mainWindow;
        public ChooseLevelWindow(Save save, MainWindow mainWindow)
        {
            InitializeComponent();
            _save = save;
            _mainWindow = mainWindow;
            if (save.army.GetFighters() != null)
            {
                text_army.Text = "Ваша армия: "+save.army.GetFighters().Count();
            }
            else
            {
                text_army.Text = "Ваша армия: 0";
            }
            LoadLevels();
            Update();
            TuneControls();
        }

        private void Update()
        {
            text_name.Text = _levels.ToArray()[_currentLevelNumber]._name;
            text_reward.Text = "Награда: "+_levels.ToArray()[_currentLevelNumber]._reward+" монет";
            text_countOfFighters.Text = "Вражеская армия: " + _levels.ToArray()[_currentLevelNumber]._enemyArmy.GetArmySize();
        }

        private void LoadLevels()
        {
            _levels = levelsLoader.Load(_levels);
        }

        public void OnStartClick(object sender, RoutedEventArgs e)
        {
            var window = new BattleWindow(_save, _levels.ToArray()[_currentLevelNumber], _mainWindow) { Owner = this };
            window.ShowDialog();
        }

        public void OnPreviousClick(object sender, RoutedEventArgs e)
        {
            if (_currentLevelNumber-1 < 0)
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
            if (_currentLevelNumber+1 > _levels.Count() - 1)
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
