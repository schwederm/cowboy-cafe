/*
 * Author: Matt Schweder
 * Class Name: Drink.cs
 * Purpose: This class is the overarching abstract class for all drinks which holds the size, price, calories, special instructions for the drinks and if the drink holds ice
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CowboyCafe.Data
{
    public abstract class Drink : IOrderItem , INotifyPropertyChanged
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
        /// Gets whether the drink has ice
        /// </summary>
        private bool ice = true;
        public virtual bool Ice
        {
            get { return ice; }
            set
            {
                ice = value;
                NotifyPropertyChanged("Ice");
            }
        }

        /// <summary>
        /// Gets the special instructions list for the drink
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

        public string Type => "Drink";
    }
}