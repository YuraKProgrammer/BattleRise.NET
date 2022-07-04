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
    /// Interaction logic for StartGameWindow.xaml
    /// </summary>
    public partial class StartGameWindow : Window
    {
        private Save _save;
        public StartGameWindow(Save save)
        {
            InitializeComponent();
            this._save = save;
        }

        public void OnExitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void OnContinueClick(object sender, RoutedEventArgs e)
        {
            var window = new GameWindow(_save) {Owner=this };
            window.Show();
        }
    }
}
