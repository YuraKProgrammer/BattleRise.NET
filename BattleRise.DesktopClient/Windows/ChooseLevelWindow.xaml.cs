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
    public partial class ChooseLevelWindow : Window
    {
        private Save _save;
        private Level _currentLevel = new Level(150,new Army(new List<IFighter>() {new Warrior(1,100,100,Side.Enemy) }),"1 уровень");
        private List<Level> _levels;
        private TempLevelStorage _levelStorage;
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
        }

        public void OnStartClick(object sender, RoutedEventArgs e)
        {
        }

        public void OnPreviousClick(object sender, RoutedEventArgs e)
        {
        }
        public void OnNextClick(object sender, RoutedEventArgs e)
        {
        }
        public void OnExitClick(object sender, RoutedEventArgs e)
        {
        }
    }
}
