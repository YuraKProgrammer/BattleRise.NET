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

namespace BattleRise.DesktopClient.UserControls
{
    /// <summary>
    /// Interaction logic for FightersPanel.xaml
    /// </summary>
    public partial class FightersPanel : UserControl
    {
        public FightersPanel()
        {
            InitializeComponent();
        }

        public FighterButton GetSelectedButton()
        {
            if (_lb.SelectedItem != null)
                return _lb.SelectedItem as FighterButton;
            else
                return null;
        }
    }
}
