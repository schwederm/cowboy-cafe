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
using CowboyCafe.Extensions;
using CowboyCafe.Data;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for CashControl.xaml
    /// </summary>
    public partial class CashControl : UserControl
    {
        /// <summary>
        /// Holds the overall cash transactions of the store in this cash drawer variable. Drawer instance is passed in from TransactionControl
        /// </summary>
        public CashDrawer drawer;
        /// <summary>
        /// Holds the list of items that the customer has picked
        /// </summary>
        public IOrderItem[] list;
        /// <summary>
        /// Holds the total price, relates to the Total label
        /// </summary>
        double total = 0.00;
        /// <summary>
        /// Holds the total paid price, relates to the TotalPaid label
        /// </summary>
        double totalPaid = 0.00;
        /// <summary>
        /// Holds the quantity of bills added to the transaction, relates to the Quantity label
        /// </summary
        int quantity = 1;
        public CashControl()
        {
            InitializeComponent();
            QuantityLabel.Text = quantity.ToString();
            TotalPaidLabel.Text = totalPaid.ToString("c");
        }

        /// <summary>
        /// On the event of a bill or coin button click the amount variable will take the value of the appropriate coin or bill denomination
        /// multiplied with the quantity amount and adds the amount of coin(s)/bill(s) to the register, then TotalPaid label will be updated, 
        /// denomination of money will then be added to the money list view, and quantity will be reset to 1. When totalPaid is greater than or 
        /// equal to total, then change is calculated as an int by and multiplying totalPaid and total by 100 and taking the difference and passed
        /// into the ChangeCalculator method, change is then made into a double by divding the int change by 100 which is displayed with the 
        /// Change label
        /// </summary>
        /// <param name="sender">The button clicked</param>
        /// <param name="e">Event arguments</param>
        private void AddingBillsAndCoinsButtonClicked(object sender, RoutedEventArgs e)
        {
            double amount = 0.00;
            quantity = Convert.ToInt32(QuantityLabel.Text);
            var button = sender as Button;
            switch (button.Tag)
            {
                case "Pennies":
                    drawer.AddCoin(Coins.Penny, quantity);
                    amount = 0.01 * quantity;
                    break;
                case "Nickels":
                    drawer.AddCoin(Coins.Nickel, quantity);
                    amount = 0.05 * quantity;
                    break;
                case "Dimes":
                    drawer.AddCoin(Coins.Dime, quantity);
                    amount = 0.10 * quantity;
                    break;
                case "Quarters":
                    drawer.AddCoin(Coins.Quarter, quantity);
                    amount = 0.25 * quantity;
                    break;
                case "HalfDollars":
                    drawer.AddCoin(Coins.HalfDollar, quantity);
                    amount = 0.50 * quantity;
                    break;
                case "Dollars":
                    drawer.AddCoin(Coins.Dollar, quantity);
                    amount = 1.00 * quantity;
                    break;
                case "Ones":
                    drawer.AddBill(Bills.One, quantity);
                    amount = 1.00 * quantity;
                    break;
                case "Twos":
                    drawer.AddBill(Bills.Two, quantity);
                    amount = 2.00 * quantity;
                    break;
                case "Fives":
                    drawer.AddBill(Bills.Five, quantity);
                    amount = 5.00 * quantity;
                    break;
                case "Tens":
                    drawer.AddBill(Bills.Ten, quantity);
                    amount = 10.00 * quantity;
                    break;
                case "Twenties":
                    drawer.AddBill(Bills.Twenty, quantity);
                    amount = 20.00 * quantity;
                    break;
                case "Fifties":
                    drawer.AddBill(Bills.Fifty, quantity);
                    amount = 50.00 * quantity;
                    break;
                case "Hundreds":
                    drawer.AddBill(Bills.Hundred, quantity);
                    amount = 100.00 * quantity;
                    break;
            }
            totalPaid = totalPaid + amount;
            TotalPaidLabel.Text = totalPaid.ToString("c");
            AddedMoneyList.Items.Add(amount.ToString("c"));
            quantity = 1;
            QuantityLabel.Text = quantity.ToString();
            string totalString = TotalLabel.Text.Substring(1);
            total = Convert.ToDouble(totalString);
            if (totalPaid >= total)
            {
                total = total * 100;
                totalPaid = totalPaid * 100;
                int change = (int)(totalPaid - total);
                double Change = (double)(change / 100.0);
                ChangeTB.Visibility = Visibility.Visible;
                ChangeLabel.Text = Change.ToString("c");
                ChangeCalculator(change);
            }
        }

        /// <summary>
        /// Handles the "-" or "+" button click which effects the quantity label
        /// </summary>
        /// <param name="sender">The button clicked</param>
        /// <param name="e">The event arguments</param>
        private void QuantityButtonClicked(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            switch (button.Tag)
            {
                case "Add":
                    quantity++;
                    QuantityLabel.Text = quantity.ToString();
                    break;
                case "Remove":
                    if (quantity > 1)
                    {
                        quantity--;
                        QuantityLabel.Text = quantity.ToString();
                    }
                    break;
            }
        }

        /// <summary>
        /// Calculates change if there is change, the denomination of the change is then added to the appropriate bills or coins array with the 
        /// change with the appropriate amount subtracted from the change variable and the appropriate the bill or coin removed from the drawer 
        /// this will continue the change is 0. Then a StringBuilder builds the string used to the tell amount of change that needs to be given 
        /// back to the customer. Then another StringBuilder is used to build the reciept using the order number, date and time, the list array of 
        /// IOrderItem with the according prices and SpecialInstructions, the subtotal, total, the cash paid for the transaction, and the change 
        /// given back which is then printed by the RecieptPrinter instance. The container is then swapped back to the OrderControl.
        /// </summary>
        /// <param name="change">Passed in amount of change</param>
        private void ChangeCalculator(int change)
        {
            double Change = change / 100.0;
            int[] bills = { 0, 0, 0, 0, 0, 0, 0 };
            int[] coins = { 0, 0, 0, 0, 0 };
            if (change > 0)
            {
                while (change > 0)
                {
                    if (change >= 10000 && drawer.GetBillQuantity(Bills.Hundred) > 0)
                    {
                        bills[0]++;
                        change -= 10000;
                        drawer.RemoveBill(Bills.Hundred, 1);
                    }
                    else if (change >= 5000 && drawer.GetBillQuantity(Bills.Fifty) > 0)
                    {
                        bills[1]++;
                        change -= 5000;
                        drawer.RemoveBill(Bills.Fifty, 1);
                    }
                    else if (change >= 2000 && drawer.GetBillQuantity(Bills.Twenty) > 0)
                    {
                        bills[2]++;
                        change -= 2000;
                        drawer.RemoveBill(Bills.Twenty, 1);
                    }
                    else if (change >= 1000 && drawer.GetBillQuantity(Bills.Ten) > 0)
                    {
                        bills[3]++;
                        change -= 1000;
                        drawer.RemoveBill(Bills.Ten, 1);
                    }
                    else if (change >= 500 && drawer.GetBillQuantity(Bills.Five) > 0)
                    {
                        bills[4]++;
                        change -= 500;
                        drawer.RemoveBill(Bills.Five, 1);
                    }
                    else if (change >= 200 && drawer.GetBillQuantity(Bills.Two) > 0)
                    {
                        bills[5]++;
                        change -= 200;
                        drawer.RemoveBill(Bills.Two, 1);
                    }
                    else if (change >= 100 && drawer.GetBillQuantity(Bills.One) > 0)
                    {
                        bills[6]++;
                        change -= 100;
                        drawer.RemoveBill(Bills.One, 1);
                    }
                    else if (change >= 50 && drawer.GetCoinQuantity(Coins.HalfDollar) > 0)
                    {
                        coins[0]++;
                        change -= 50;
                        drawer.RemoveCoin(Coins.HalfDollar, 1);
                    }
                    else if (change >= 25 && drawer.GetCoinQuantity(Coins.Quarter) > 0)
                    {
                        coins[1]++;
                        change -= 25;
                        drawer.RemoveCoin(Coins.Quarter, 1);
                    }
                    else if (change >= 10 && drawer.GetCoinQuantity(Coins.Dime) > 0)
                    {
                        coins[2]++;
                        change -= 10;
                        drawer.RemoveCoin(Coins.Dime, 1);
                    }
                    else if (change >= 5 && drawer.GetCoinQuantity(Coins.Nickel) > 0)
                    {
                        coins[3]++;
                        change -= 5;
                        drawer.RemoveCoin(Coins.Nickel, 1);
                    }
                    else if (change >= 1 && drawer.GetCoinQuantity(Coins.Nickel) > 0)
                    {
                        coins[4]++;
                        change -= 1;
                        drawer.RemoveCoin(Coins.Penny, 1);
                    }
                }
                StringBuilder changeList = new StringBuilder();
                changeList.Append("Give customer back:\n");
                if (bills[0] > 0)
                    changeList.Append(bills[0].ToString() + " Hundred dollar bill(s)\n");
                if (bills[1] > 0)
                    changeList.Append(bills[1].ToString() + " Fifty dollar bill\n");
                if (bills[2] > 0)
                    changeList.Append(bills[2].ToString() + " Twenty dollar bill(s)\n");
                if (bills[3] > 0)
                    changeList.Append(bills[3].ToString() + " Ten dollar bill\n");
                if (bills[4] > 0)
                    changeList.Append(bills[4].ToString() + " Five dollar bill\n");
                if (bills[5] > 0)
                    changeList.Append(bills[5].ToString() + " Two dollar bill(s)\n");
                if (bills[6] > 0)
                    changeList.Append(bills[6].ToString() + " One dollar bill\n");
                if (coins[0] > 0)
                    changeList.Append(coins[0].ToString() + " Half-dollar\n");
                if (coins[1] > 0)
                    changeList.Append(coins[1].ToString() + " Quarter\n");
                if (coins[2] > 0)
                    changeList.Append(coins[2].ToString() + " Dime(s)\n");
                if (coins[3] > 0)
                    changeList.Append(coins[3].ToString() + " Nickel\n");
                if (coins[4] > 0)
                    changeList.Append(coins[4].ToString() + " Penny/Pennies\n");
                MessageBox.Show(changeList.ToString() + "\n");
            }

            var printer = new ReceiptPrinter();
            var sb = new StringBuilder();
            var order = DataContext as Order;
            sb.Append("Order " + order.OrderNumber.ToString() + "\n");
            sb.Append(DateTime.Today.ToString() + "\n");
            foreach (IOrderItem item in list)
            {
                sb.Append(item.ToString() + "\t\t" + item.Price.ToString("c") + "\n");
                if (item.SpecialInstructions != null)
                {
                    foreach (string instruction in item.SpecialInstructions)
                    {
                        sb.Append("\t" + instruction + "\n");
                    }
                }
            }
            sb.Append("\nSubtotal:\t" + order.Subtotal.ToString("c") + "\n");
            sb.Append("Total:\t" + TotalLabel.Text + "\n");
            sb.Append("Cash\t" + TotalLabel.Text + "\n");
            sb.Append("Change\t" + Change.ToString("c"));
            printer.Print(sb.ToString());

            var screen = new MenuItemSelectionControl();

            var orderControl = this.FindAncestor<OrderControl>();
            if (orderControl == null) throw new Exception("An ancestor of OrderControl expected be an OrderControl instead of null");

            orderControl.SwapScreen(screen);
            orderControl.DataContext = new Order();
        }
    }
}
