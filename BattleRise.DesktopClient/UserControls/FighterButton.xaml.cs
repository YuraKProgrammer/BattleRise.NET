using BattleRise.Models.Fighters;
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
    /// Interaction logic for FighterButton.xaml
    /// </summary>
    public partial class FighterButton : UserControl
    {
        private int count;
        public FighterButton(IFighter fighter, int count)
        { 
            InitializeComponent();
            this.count = count;
            _image.Source=new BitmapImage(new Uri(fighter.GetFileFolder(), UriKind.Absolute));
            UpdateText();
        }

        public FighterButton()
        {
            InitializeComponent();
        }

        public void UpdateText()
        {
            _text.Text = count.ToString();
        }

        public void MinusCount()
        {
            count--;
            UpdateText();
        }
    }
}
