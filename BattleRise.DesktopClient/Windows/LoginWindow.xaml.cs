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
using BattleRise.SaveStorage;

namespace BattleRise.DesktopClient.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private TempSaveStorage _saveStorage = new TempSaveStorage();
        public LoginWindow()
        {
            InitializeComponent();
        }

        public void Ok_Click(object sender, RoutedEventArgs e)
        {
            var userId = 0;
            if (_tb.Text == "yura" && _pb.Password == "Yura2006")
            {
                userId = 2;
            }
            if (userId != 0) {
                var save = _saveStorage.Load(userId);
                if (save == null)
                {
                    save = new Save(DateTime.Now, userId, new Resources(100, 0), new Army(new List<IFighter>()), new List<int>(), 1);
                }
                var window = new StartGameWindow(save) { Owner = this };
                window.Show();
            }
            else
            {
                throw new Exception("Непраильный логин или пароль");
            }
        }
    }
}
