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
using CowboyCafe.Extensions;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderControl.xaml
    /// </summary>
    public partial class MenuItemSelectionControl : UserControl
    {
        public MenuItemSelectionControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles all the button clicks and based on the tag passes the appropriate item instance and customize screen instance into the AddItemAndOpenCustomizatoinScreen method
        /// </summary>
        /// <param name="sender">The button clicked</param>
        /// <param name="e">The event arguments</param>
        void OnItemAddButtonClicked(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                switch (button.Tag)
                {
                    case "AngryChicken":
                        AddItemAndOpenCustomizationScreen(new AngryChicken(), new CustomizeAngryChicken());
                        break;
                    case "BakedBeans":
                        AddItemAndOpenCustomizationScreen(new BakedBeans(), new CustomizeSide("Baked Beans"));
                        break;
                    case "ChiliCheeseFries":
                        AddItemAndOpenCustomizationScreen(new ChiliCheeseFries(), new CustomizeSide("Chili Cheese Fries"));
                        break;
                    case "CornDodgers":
                        AddItemAndOpenCustomizationScreen(new CornDodgers(), new CustomizeSide("Corn Dodgers"));
                        break;
                    case "CowboyCoffee":
                        AddItemAndOpenCustomizationScreen(new CowboyCoffee(), new CustomizeCowboyCoffee());
                        break;
                    case "CowpokeChili":
                        AddItemAndOpenCustomizationScreen(new CowpokeChili(), new CustomizeCowpokeChili());
                        break;
                    case "DakotaDoubleBurger":
                        AddItemAndOpenCustomizationScreen(new DakotaDoubleBurger(), new CustomizeDakotaDoubleBurger());
                        break;
                    case "JerkedSoda":
                        AddItemAndOpenCustomizationScreen(new JerkedSoda(), new CustomizeJerkedSoda());
                        break;
                    case "PanDeCampo":
                        AddItemAndOpenCustomizationScreen(new PanDeCampo(), new CustomizeSide("Pan de Campo"));
                        break;
                    case "PecosPulledPork":
                    AddItemAndOpenCustomizationScreen(new PecosPulledPork(), new CustomizePecosPulledPork());
                        break;
                    case "RustlersRibs":
                        AddItemAndOpenCustomizationScreen(new RustlersRibs(), null);
                        break;
                    case "TexasTea":
                        AddItemAndOpenCustomizationScreen(new TexasTea(), new CustomizeTexasTea());
                        break;
                    case "TexasTripleBurger":
                        AddItemAndOpenCustomizationScreen(new TexasTripleBurger(), new CustomizeTexasTripleBurger());
                        break;
                    case "TrailBurger":
                        AddItemAndOpenCustomizationScreen(new TrailBurger(), new CustomizeTrailBurger());
                        break;
                    case "Water":
                        AddItemAndOpenCustomizationScreen(new Water(), new CustomizeWater());
                        break;
                }
            }
        }

        /// <summary>
        /// If the order instance isn't null the item is added to the order and if the screen isn't null the Order Control swaps screens with the instance of the passed in screen.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="screen"></param>
        void AddItemAndOpenCustomizationScreen(IOrderItem item, FrameworkElement screen)
        {
            var order = DataContext as Order;
            if (order == null) throw new Exception("DataContext expected be an Order instead of null");

            if (screen != null)
            {
                var orderControl = this.FindAncestor<OrderControl>();
                if (orderControl == null) throw new Exception("An ancestor of OrderControl expected be an OrderControl instead of null");

                screen.DataContext = item;
                orderControl.SwapScreen(screen);
            }

            order.Add(item);
        }
    }
}
