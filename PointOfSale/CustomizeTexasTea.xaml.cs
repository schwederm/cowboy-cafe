using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CowboyCafe.Data;
using Size = CowboyCafe.Data.Size;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for CustomizeTexasTea.xaml
    /// </summary>
    public partial class CustomizeTexasTea : UserControl
    {
        public CustomizeTexasTea()
        {
            InitializeComponent();
            SmallRadioButton.IsChecked = true;// Sets the small radio button to checked when the screen is loaded
        }

        /// <summary>
        /// Handles all the radio button clicks and changes the size of the Texas Tea.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButtonClick(object sender, RoutedEventArgs e)
        {
            Drink drink = (TexasTea)DataContext;
            switch (((RadioButton)sender).Name)
            {
                case "SmallRadioButton":
                    drink.Size = Size.Small;
                    break;
                case "MediumRadioButton":
                    drink.Size = Size.Medium;
                    break;
                case "LargeRadioButton":
                    drink.Size = Size.Large;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
