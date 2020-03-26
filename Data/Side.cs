/*
 * Author: Nathan Bean
 * Edited By: Matt Schweder
 * Class Name: Side.cs
 * Purpose: This class is the overarching abstract class for all sides which holds the size, price, and calories for the sides.
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CowboyCafe.Data
{
    /// <summary>
    /// A base class representing a side
    /// </summary>
    public abstract class Side : IOrderItem , INotifyPropertyChanged
    {
        /// <summary>
        /// Gets the size of the side. Invokes the PropertyChanged event handler for the Size, Price, and Calories properties
        /// </summary>
        private Size size = Size.Small;
        public Size Size
        {
            get { return size; }
            set
            {
                size = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Size"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            }
        }

        /// <summary>
        /// Gets the price of the side
        /// </summary>
        public abstract double Price { get; }

        /// <summary>
        /// Gets the calories of the side
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// Special instructions for the side
        /// </summary>
        public abstract IEnumerable<string> SpecialInstructions { get; }

        /// <summary>
        /// Handles a PropertyChanged event and notifies the Order class that a property has changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Listens to changed property events and invokes the appropriate PropertyChanged event
        /// </summary>
        /// <param name="propertyName">Name of the changed property</param>
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
        }
    }
}
