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

        void OnItemAddButtonClicked(object sender, RoutedEventArgs e)
        {
            var orderControl = this.FindAncestor<OrderControl>();
            if (DataContext is Order data)
            {
                if (sender is Button button)
                {
                    switch (button.Tag)
                    {
                        case "AngryChicken":
                            data.Add(new AngryChicken());
                            //orderControl.SwapScreen(new something());
                            break;
                        case "BakedBeans":
                            data.Add(new BakedBeans());
                            //orderControl.SwapScreen(new something());
                            break;
                        case "ChiliCheeseFries":
                            data.Add(new ChiliCheeseFries());
                            //orderControl.SwapScreen(new something());
                            break;
                        case "CornDodgers":
                            data.Add(new CornDodgers());
                            //orderControl.SwapScreen(new something());
                            break;
                        case "CowboyCoffee":
                            data.Add(new CowboyCoffee());
                            //orderControl.SwapScreen(new something());
                            break;
                        case "CowpokeChili":
                            var item = new CowpokeChili();
                            var screen = new CustomizeCowpokeChili();
                            AddItemAndOpenCustomizationScreen(item, screen);
                            break;
                        case "DakotaDoubleBurger":
                            data.Add(new DakotaDoubleBurger());
                            //orderControl.SwapScreen(new something());
                            break;
                        case "JerkedSoda":
                            data.Add(new JerkedSoda());
                            //orderControl.SwapScreen(new something());
                            break;
                        case "PanDeCampo":
                            data.Add(new PanDeCampo());
                            //orderControl.SwapScreen(new something());
                            break;
                        case "PecosPulledPork":
                            data.Add(new PecosPulledPork());
                            //orderControl.SwapScreen(new something());
                            break;
                        case "RustlersRibs":
                            data.Add(new RustlersRibs());
                            //orderControl.SwapScreen(new something());
                            break;
                        case "TexasTea":
                            data.Add(new TexasTea());
                            //orderControl.SwapScreen(new something());
                            break;
                        case "TexasTripleBurger":
                            data.Add(new TexasTripleBurger());
                            //orderControl.SwapScreen(new something());
                            break;
                        case "TrailBurger":
                            data.Add(new TrailBurger());
                            //orderControl.SwapScreen(new something());
                            break;
                        case "Water":
                            data.Add(new Water());
                            //orderControl.SwapScreen(new something());
                            break;
                    }
                }
            }
        }

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
