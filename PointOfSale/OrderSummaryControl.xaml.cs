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
    /// Interaction logic for OrderSummaryControl.xaml
    /// </summary>
    public partial class OrderSummaryControl : UserControl
    {
        public OrderSummaryControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// If the user selects one of the items on the order summary, then the appropriate item instance is passed into the OpenCustomizationScreen method
        /// </summary>
        /// <param name="sender">The ListView clicked</param>
        /// <param name="e">The event arguments</param>
        private void OnOrderItemClicked(object sender, RoutedEventArgs e)
        {
            if (sender is ListView list)
            {
                var orderArr = list.ItemsSource as IOrderItem[];
                int orderItemNum = list.SelectedIndex;
                if (orderItemNum != -1)
                {
                    string orderItem = orderArr[orderItemNum].ToString();
                    string[] item = orderItem.Split(" ");
                    if (item[0] == "Small" || item[0] == "Medium" || item[0] == "Large")
                    {
                        if (item[item.Length - 1] == "Soda")
                            orderItem = item[item.Length - 2] + " " + item[item.Length - 1];
                        else if (item[item.Length - 1] == "Tea")
                            orderItem = item[item.Length - 3] + " " + item[item.Length - 1];
                        else if (item[item.Length - 1] == "Coffee")
                            orderItem = item[item.Length - 2] + " " + item[item.Length - 1];
                        else
                        {
                            orderItem = "";
                            for (int i = 1; i < item.Length; i++)
                            {
                                orderItem = orderItem + item[i] + " ";
                            }
                            orderItem = orderItem.Substring(0, orderItem.Length - 1);
                        }
                    }
                    switch (orderItem)
                    {
                        case "Angry Chicken":
                            OpenCustomizationScreen(orderArr[orderItemNum], new CustomizeAngryChicken());
                            break;
                        case "Baked Beans":
                            OpenCustomizationScreen(orderArr[orderItemNum], new CustomizeSide("Baked Beans"));
                            break;
                        case "Chili Cheese Fries":
                            OpenCustomizationScreen(orderArr[orderItemNum], new CustomizeSide("Chili Cheese Fries"));
                            break;
                        case "Corn Dodgers":
                            OpenCustomizationScreen(orderArr[orderItemNum], new CustomizeSide("Corn Dodgers"));
                            break;
                        case "Cowboy Coffee":
                            OpenCustomizationScreen(orderArr[orderItemNum], new CustomizeCowboyCoffee());
                            break;
                        case "Cowpoke Chili":
                            OpenCustomizationScreen(orderArr[orderItemNum], new CustomizeCowpokeChili());
                            break;
                        case "Dakota Double Burger":
                            OpenCustomizationScreen(orderArr[orderItemNum], new CustomizeDakotaDoubleBurger());
                            break;
                        case "Jerked Soda":
                            OpenCustomizationScreen(orderArr[orderItemNum], new CustomizeJerkedSoda());
                            break;
                        case "Pan de Campo":
                            OpenCustomizationScreen(orderArr[orderItemNum], new CustomizeSide("Pan de Campo"));
                            break;
                        case "Peco's Pulled Pork":
                            OpenCustomizationScreen(orderArr[orderItemNum], new CustomizePecosPulledPork());
                            break;
                        case "Rustler's Ribs":
                            OpenCustomizationScreen(orderArr[orderItemNum], null);
                            break;
                        case "Texas Tea":
                            OpenCustomizationScreen(orderArr[orderItemNum], new CustomizeTexasTea());
                            break;
                        case "Texas Triple Burger":
                            OpenCustomizationScreen(orderArr[orderItemNum], new CustomizeTexasTripleBurger());
                            break;
                        case "Trail Burger":
                            OpenCustomizationScreen(orderArr[orderItemNum], new CustomizeTrailBurger());
                            break;
                        case "Water":
                            OpenCustomizationScreen(orderArr[orderItemNum], new CustomizeWater());
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// If the screen isn't null the Order Control swaps screens with the instance of the passed in screen and item as its DataContext.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="screen"></param>
        private void OpenCustomizationScreen(IOrderItem item, FrameworkElement screen)
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
        }

        /// <summary>
        /// If the user clicks the remove button then the item associated with the button is removed from the list
        /// </summary>
        /// <param name="sender">The remove button</param>
        /// <param name="e">The event arguments</param>
        private void OnRemoveButtonClicked(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                var order = DataContext as Order;
                var item = button.DataContext as IOrderItem;
                order.Remove(item);
            }
        }
    }
}