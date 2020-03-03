/*
 * Author: Matt Schweder
 * Class Name: Drink.cs
 * Purpose: This class is the overarching abstract class for all drinks which holds the size, price, calories, special instructions for the drinks and if the drink holds ice
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    public abstract class Drink : IOrderItem
    {
        /// <summary>
        /// Gets the size of the side
        /// </summary>
        public Size Size { get; set; } = Size.Small;

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
        public virtual bool Ice { get; set; } = true;

        /// <summary>
        /// Gets the special instructions list for the drink
        /// </summary>
        public abstract IEnumerable<string> SpecialInstructions { get; }
    }
}
