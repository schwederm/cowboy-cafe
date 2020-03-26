/*
 * Author: Matt Schweder
 * Class Name: Entree.cs
 * Purpose: This class is the overarching abstract class for all entrees which requires them to use the price, calories, and special instructions properties.
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CowboyCafe.Data
{
    public abstract class Entree : IOrderItem , INotifyPropertyChanged
    {
        /// <summary>
        /// Holds the overarching price double for all implented Entree classes
        /// </summary>
        public abstract double Price { get; }

        /// <summary>
        /// Holds the overarching calories uint for all implented Entree classes
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// Holds the overarching special instructions list for all implented Entree classes
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