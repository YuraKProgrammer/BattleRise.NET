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
using BattleRise.Models.Fighters;

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
            bool nw = false;
            if (_tb.Text == "test" && _pb.Password == "Test123456789")
            {
                userId = 1;
            }
            if (_tb.Text == "yura" && _pb.Password == "Yura2006")
            {
                userId = 2;
            }
            if (_tb.Text == "yusya" && _pb.Password == "Usost")
            {
                userId = 3;
            }
            if (userId != 0) {
                var save = _saveStorage.Load(userId);
                if (save == null)
                {
                    nw = true;
                    save = new Save(DateTime.Now, userId, new Resources(100, 0), new Army(new List<IFighter>()), new int[]{1,1,1,1,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 1);
                }
                var window = new StartGameWindow(save, nw) { Owner = this };
                window.Show();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль", "Войти");
            }
        }
    }
}
