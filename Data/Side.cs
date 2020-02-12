/*
 * Author: Nathan Bean
 * Edited By: Matt Schweder
 * Class Name: Side.cs
 * Purpose: This class is the overarching abstract class for all sides which holds the size, price, and calories for the sides.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    /// <summary>
    /// A base class representing a side
    /// </summary>
    public abstract class Side
    {
        /// <summary>
        /// Gets the size of the side
        /// </summary>
        public abstract Size Size { get; set; }

        /// <summary>
        /// Gets the price of the side
        /// </summary>
        public abstract double Price { get; }

        /// <summary>
        /// Gets the calories of the side
        /// </summary>
        public abstract uint Calories { get; }
    }
}
