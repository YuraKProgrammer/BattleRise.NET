using BattleRise.DesktopClient.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BattleRise.DesktopClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var sett = new Settings();
            if (sett.Version != null)
            {
                text_version.Text = "Версия: " + sett.Version;
            }
        }

        private void OnAboutClick(object sender, RoutedEventArgs e)
        {
            var window = new AboutWindow() { Owner = this };
            window.ShowDialog();
        }

        private void OnLoginClick(object sender, RoutedEventArgs e)
        {
            var window = new LoginWindow() { Owner = this };
            window.ShowDialog();
        }

        private void OnRegisterClick(object sender, RoutedEventArgs e)
        {
            //Не реализовано
        }
    }
}
