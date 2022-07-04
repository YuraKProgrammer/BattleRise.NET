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
    /// Interaction logic for CastleWindow.xaml
    /// </summary>
    public partial class CastleWindow : Window
    {
        private Save _save;
        public CastleWindow(Save save)
        {
            InitializeComponent();
            _save = save;
        }
    }
}
