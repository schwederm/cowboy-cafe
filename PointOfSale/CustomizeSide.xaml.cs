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
    /// Interaction logic for CustomizeSide.xaml
    /// </summary>
    public partial class CustomizeSide : UserControl
    {
        public CustomizeSide(string context)
        {
            InitializeComponent();
            SideName.Text = context;
            SmallRadioButton.IsChecked = true; // Sets the label's name to the appopriate side and the small radio button is clicked when the screen is loaded.
        }

        /// <summary>
        /// Handles all of the radio button clicks and changes the size of the appopriate side
        /// </summary>
        /// <param name="sender">The radio button clicked</param>
        /// <param name="e">The event arguments</param>
        private void RadioButtonClick(object sender, RoutedEventArgs e)
        {
            Side side;
            if (DataContext is BakedBeans)
                side = (BakedBeans)DataContext;
            else if (DataContext is ChiliCheeseFries)
                side = (ChiliCheeseFries)DataContext;
            else if (DataContext is CornDodgers)
                side = (CornDodgers)DataContext;
            else
                side = (PanDeCampo)DataContext;

            switch (((RadioButton)sender).Name)
            {
                case "SmallRadioButton":
                    side.Size = Size.Small;
                    break;
                case "MediumRadioButton":
                    side.Size = Size.Medium;
                    break;
                case "LargeRadioButton":
                    side.Size = Size.Large;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
