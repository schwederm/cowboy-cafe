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
    /// Interaction logic for CustomizeCowboyCoffee.xaml
    /// </summary>
    public partial class CustomizeCowboyCoffee : UserControl
    {
        public CustomizeCowboyCoffee()
        {
            InitializeComponent();
            SmallRadioButton.IsChecked = true; //Sets the SmallRadioButton to checked upon opening the screen
        }

        /// <summary>
        /// Handles the all radio button clicks and changes the size of the CowboyCoffee.
        /// </summary>
        /// <param name="sender">The radio button clicked</param>
        /// <param name="e">The event argument</param>
        private void RadioButtonClick(object sender, RoutedEventArgs e)
        {
            Drink drink = (CowboyCoffee)DataContext;
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
