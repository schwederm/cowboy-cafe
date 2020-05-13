using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CowboyCafe.Data
{
    public class Order : INotifyPropertyChanged
    {
        /// <summary>
        /// Every time the Order class is instantiated the OrderNumber takes current value of lastOrderNumber and increments that value.
        /// </summary>
        public Order()
        {
            OrderNumber = lastOrderNumber++;
        }

        /// <summary>
        /// Keeps track of the last order number.
        /// </summary>
        static uint lastOrderNumber = 1;

        /// <summary>
        /// Keeps track of the items the user has ordered.
        /// </summary>
        List<IOrderItem> items = new List<IOrderItem>();
        public IEnumerable<IOrderItem> Items => items.ToArray();
        
        /// <summary>
        /// Keeps track of the subtotal price of the items ordered.
        /// </summary>
        double? subtotal = 0;
        public double? Subtotal => subtotal;

        /// <summary>
        /// Keeps track of the current order number.
        /// </summary>
        public uint OrderNumber { get; }

        /// <summary>
        /// Keeps track if one of the class' properties has changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Adds item to the items list and updates the subtotal and notifies the event handler that both aforementioned properties have changed.
        /// </summary>
        /// <param name="item"></param>
        public void Add(IOrderItem item)
        {
            if (item is INotifyPropertyChanged notifier)
            {
                notifier.PropertyChanged += OnItemPropertyChanged;
            }
            items.Add(item);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Items"));
            subtotal += item.Price;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
        }

        /// <summary>
        /// Removes item from the items list and updates the subtotal and notifies the event handler that both aforementioned properties have changed.
        /// </summary>
        /// <param name="item"></param>
        public void Remove(IOrderItem item)
        {
            if (item is INotifyPropertyChanged notifier)
            {
                notifier.PropertyChanged -= OnItemPropertyChanged;
            }
            items.Remove(item);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Items"));
            subtotal -= item.Price;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
        }

        /// <summary>
        /// Listens to the changed properties of any IOrderItem and if neccessary updates the subtotal price
        /// </summary>
        /// <param name="sender">CheckBox or RadioButton clicks</param>
        /// <param name="e">The event arguments</param>
        private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Items"));
            if (e.PropertyName == "Price")
            {
                subtotal = 0;
                foreach(IOrderItem item in items)
                {
                    subtotal += item.Price;
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
            }
        }
    }
}
