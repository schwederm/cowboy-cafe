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
using SodaFlavor = CowboyCafe.Data.SodaFlavor;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for CustomizeJerkedSoda.xaml
    /// </summary>
    public partial class CustomizeJerkedSoda : UserControl
    {
        public CustomizeJerkedSoda()
        {
            InitializeComponent();
            SmallRadioButton.IsChecked = true; 
            CreamSodaRadioButton.IsChecked = true; //Sets the Cream Soda and Small radio buttons to checked once the screen is loaded
        }

        /// <summary>
        /// Handles all size radio button clicks and changes the size of the Jerked Soda
        /// </summary>
        /// <param name="sender">The size radio button clicked</param>
        /// <param name="e">The event arguments</param>
        private void SizeRadioButtonClick(object sender, RoutedEventArgs e)
        {
            Drink drink = (JerkedSoda)DataContext;
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

        /// <summary>
        /// Handles all of the Soda Flavor radio button clicks and changes the flavor of the Jerked Soda
        /// </summary>
        /// <param name="sender">The Jerked Soda radio button clicked</param>
        /// <param name="e">The event arguments</param>
        private void SodaFlavorRadioButtonClick(object sender, RoutedEventArgs e)
        {
            JerkedSoda soda = (JerkedSoda)DataContext;
            switch (((RadioButton)sender).Name)
            {
                case "BirchBeerRadioButton":
                    soda.Flavor = SodaFlavor.BirchBeer;
                    break;
                case "CreamSodaRadioButton":
                    soda.Flavor = SodaFlavor.CreamSoda;
                    break;
                case "OrangeSodaRadioButton":
                    soda.Flavor = SodaFlavor.OrangeSoda;
                    break;
                case "RootBeerRadioButton":
                    soda.Flavor = SodaFlavor.RootBeer;
                    break;
                case "SarsparillaRadioButton":
                    soda.Flavor = SodaFlavor.Sarsparilla;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
