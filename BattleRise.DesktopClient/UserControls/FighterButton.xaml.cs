using BattleRise.Models;
using BattleRise.Models.Fighters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for FighterButton.xaml
    /// </summary>
    public partial class FighterButton : UserControl
    {
        private FightersGroup _fightersGroup;
        public FightersGroup FightersGroup
        {
            get
            {
                return _fightersGroup;
            }
            set
            {
                _fightersGroup = value;
                _image.Source = new BitmapImage(new Uri(_fightersGroup.fighter.GetFileFolder(), UriKind.Absolute));
                _text.Text = _fightersGroup.count.ToString();
            }
        }
        public FighterButton(FightersGroup fightersGroup)
        { 
            InitializeComponent();
            _fightersGroup = fightersGroup;
            _image.Source=new BitmapImage(new Uri(fightersGroup.fighter.GetFileFolder(), UriKind.Absolute));
        }

        private void FighterButton_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            FightersGroup = DataContext as FightersGroup; 
        }

        public FighterButton()
        {
            InitializeComponent();
            DataContextChanged += FighterButton_DataContextChanged;
        }
    }
}
