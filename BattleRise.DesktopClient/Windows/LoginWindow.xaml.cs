using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BattleRise.Models;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        public void Ok_Click(object sender, RoutedEventArgs e)
        {
            var save = new Save(DateTime.Now,2,new Resources(100,0),new Army(new List<IFighter>()),new List<int>());
            var window = new StartGameWindow (save) { Owner = this };
            window.Show();
        }
    }
}
