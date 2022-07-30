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
using BattleRise.Models.Fighters;

namespace BattleRise.DesktopClient.Windows
{
    /// <summary>
    /// Interaction logic for StartGameWindow.xaml
    /// </summary>
    public partial class StartGameWindow : Window
    {
        private Save _save;
        private bool _nw;
        private MainWindow _mainWindow;
        public StartGameWindow(Save save, bool nw, MainWindow mainWindow)
        {
            InitializeComponent();
            this._save = save;
            _nw = nw;
            _mainWindow = mainWindow;
            TuneControls();
        }

        public void OnExitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void OnContinueClick(object sender, RoutedEventArgs e)
        {
            var window = new GameWindow(_save, _mainWindow) {Owner=this };
            window.ShowDialog();
        }

        public void OnNewClick(object sender, RoutedEventArgs e)
        {
            var window = new GameWindow(new Save(DateTime.Now, _save.userId, new Resources(100, 0), new Army(new List<IFighter>()), new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 1), _mainWindow) { Owner = this };
            window.ShowDialog();
        }

        private void TuneControls()
        {
            if (_nw==true)
                button_continue.IsEnabled = false;
        }
    }
}
