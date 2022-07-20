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
        private int _count;
        private IFighter _fighter;
        public IFighter Fighter
        {
            get
            {
                return _fighter;
            }
            set
            {
                _fighter = value;
                _image.Source = new BitmapImage(new Uri(_fighter.GetFileFolder(), UriKind.Absolute));
            }
        }

        public int Count
        { 
            get 
            { 
                return _count; 
            }
            set
            {
                _count = value;
                _text.Text = value.ToString();
            }
        }
        public FighterButton(IFighter fighter, int count)
        { 
            InitializeComponent();
            _count = count;
            _fighter = fighter;
            Fighter = fighter;
            _image.Source=new BitmapImage(new Uri(fighter.GetFileFolder(), UriKind.Absolute));
            UpdateText();
        }

        private void FighterButton_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Fighter = DataContext as IFighter;
        }

        public FighterButton()
        {
            InitializeComponent();
            DataContextChanged += FighterButton_DataContextChanged;
        }

        public void UpdateText()
        {
            _text.Text = _count.ToString();
        }

        public IFighter GetFighter()
        {
            return _fighter;
        }

        public int GetCount()
        {
            return _count;
        }
    }
}
