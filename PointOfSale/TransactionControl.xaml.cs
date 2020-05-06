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
using CashRegister;
using CowboyCafe.Data;
using CowboyCafe.Extensions;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for TransactionControl.xaml
    /// </summary>
    public partial class TransactionControl : UserControl
    {
        /// <summary>
        /// Used to pass the appropriate CashDrawer instance to CashControl
        /// </summary>
        public CashDrawer drawer;
        public TransactionControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Calculates the tax and total variables and displays them with the appropriate labels
        /// </summary>
        public void CalculateTaxAndTotal()
        {
            var order = DataContext as Order;
            double tax = order.Subtotal * 0.16;
            double total = order.Subtotal + tax;
            TaxLabel.Text = tax.ToString("c");
            TotalLabel.Text = total.ToString("c");
        }

        /// <summary>
        /// Handles the credit button clicked, the card terminal instance then produces a code from the ProcessTransaction method a switch
        /// statement handles the ResultCode produced with a MessageBox that shows the appropriate message except for the ResultCode.Success which
        /// uses a StringBuilder to build a reciept using the order number, date and time, the list array of IOrderItem with the according prices 
        /// and SpecialInstructions, the subtotal, total, and that credit used to pay for the transaction which is then printed by the 
        /// RecieptPrinter instance. The container is then swapped back to the OrderControl.
        /// </summary>
        /// <param name="sender">The credit button</param>
        /// <param name="e">Event arguments</param>
        private void CreditButtonClicked(object sender, RoutedEventArgs e)
        {
            var terminal = new CardTerminal();
            string totalText = TotalLabel.Text.Substring(1);
            double total = Convert.ToDouble(totalText);
            ResultCode code = terminal.ProcessTransaction(total);
            switch (code)
            {
                case ResultCode.CancelledCard:
                    MessageBox.Show("Cancelled Card.");
                    break;
                case ResultCode.InsufficentFunds:
                    MessageBox.Show("Card has insufficent funds.");
                    break;
                case ResultCode.ReadError:
                    MessageBox.Show("Card reader error.");
                    break;
                case ResultCode.Success:
                    var printer = new ReceiptPrinter();
                    var sb = new StringBuilder();
                    var order = DataContext as Order;
                    sb.Append("Order " + order.OrderNumber.ToString() + "\n");
                    sb.Append(DateTime.Today.ToString() + "\n");
                    var list = OrderList.ItemsSource as IOrderItem[];
                    foreach(IOrderItem item in list)
                    {
                        sb.Append(item.ToString() + "\t\t" + item.Price.ToString("c") + "\n");
                        if (item.SpecialInstructions != null)
                        {
                            foreach(string instruction in item.SpecialInstructions)
                            {
                                sb.Append("\t" + instruction + "\n");
                            }
                        }
                    }
                    sb.Append("\nSubtotal:\t" + order.Subtotal.ToString("c") + "\n");
                    sb.Append("Total:\t" + TotalLabel.Text + "\n");
                    sb.Append("Credit\t" + TotalLabel.Text);
                    printer.Print(sb.ToString());

                    var screen = new MenuItemSelectionControl();

                    var orderControl = this.FindAncestor<OrderControl>();
                    if (orderControl == null) throw new Exception("An ancestor of OrderControl expected be an OrderControl instead of null");

                    orderControl.SwapScreen(screen);
                    orderControl.DataContext = new Order();
                    break;
                case ResultCode.UnknownErrror:
                    MessageBox.Show("Unknown error occurred.");
                    break;
            }
        }

        /// <summary>
        /// Handles the cash button clicked the container is then swapped to the CashControl.
        /// </summary>
        /// <param name="sender">The cash button clicked</param>
        /// <param name="e">Event arguments</param>
        private void CashButtonClicked(object sender, RoutedEventArgs e)
        {
            var screen = new CashControl();

            var orderControl = this.FindAncestor<OrderControl>();
            if (orderControl == null) throw new Exception("An ancestor of OrderControl expected be an OrderControl instead of null");

            screen.DataContext = this.DataContext;
            screen.drawer = drawer;
            screen.list = OrderList.ItemsSource as IOrderItem[];
            screen.TotalLabel.Text = TotalLabel.Text;
            orderControl.SwapScreen(screen);
        }

        /// <summary>
        /// Handles the cancel button click and swaps the Container with the OrderControl.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButtonClicked(object sender, RoutedEventArgs e)
        {
            var screen = new MenuItemSelectionControl();

            var orderControl = this.FindAncestor<OrderControl>();
            if (orderControl == null) throw new Exception("An ancestor of OrderControl expected be an OrderControl instead of null");

            orderControl.SwapScreen(screen);
            orderControl.DataContext = new Order();
        }
    }
}
