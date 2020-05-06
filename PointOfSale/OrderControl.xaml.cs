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
using CashRegister;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderControl.xaml
    /// </summary>
    public partial class OrderControl : UserControl
    {
        /// <summary>
        /// Carries the CashDrawer instance for all transactions.
        /// </summary>
        CashDrawer drawer;
        public OrderControl()
        {
            InitializeComponent();
            drawer = new CashDrawer();
        }

        /// <summary>
        /// Handles the Item Selection button click and switches the Border Container screen back to the MenuItemSelectionControl
        /// </summary>
        /// <param name="sender">The Item Selection button</param>
        /// <param name="e">The event arguments</param>
        public void OnItemSelectionButtonClicked(object sender, RoutedEventArgs e)
        {
            Container.Child = new MenuItemSelectionControl();
        }

        /// <summary>
        /// Swaps the screen with the passed in element
        /// </summary>
        /// <param name="element"></param>
        public void SwapScreen(UIElement element)
        {
            Container.Child = element;
        }

        /// <summary>
        /// Handles the Cancel Order Button click and creates a new Order instance
        /// </summary>
        /// <param name="sender">The Cancel Order button</param>
        /// <param name="e">The event arguments</param>
        void OnCancelOrderButtonClicked(object sender, RoutedEventArgs e)
        {
            this.DataContext = new Order();
        }

        /// <summary>
        /// Handles the Complete Order Button click, swaps the Container to the TranscationControl, calculates the tax and total of the current
        /// transaction, and sets the drawer variable of the TransactionControl to this control's drawer variable
        /// </summary>
        /// <param name="sender">The Complete Order button</param>
        /// <param name="e">The event arguments</param>
        void OnCompleteOrderButtonClicked(object sender, RoutedEventArgs e)
        {
            var screen = new TransactionControl();

            var orderControl = this;
            if (orderControl == null) throw new Exception("An ancestor of OrderControl expected be an OrderControl instead of null");

            screen.DataContext = this.DataContext;
            screen.CalculateTaxAndTotal();
            screen.drawer = drawer;
            orderControl.SwapScreen(screen);
        }
    }
}