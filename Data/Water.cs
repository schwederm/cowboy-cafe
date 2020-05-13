/*
 * Author: Matt Schweder
 * Class Name: Water.cs
 * Purpose: This class holds the price, calories, and special instructions for the Water and if the water has lemon.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    public class Water : Drink
    {
        /// <summary>
        /// Gets the price for the Water
        /// </summary>
        public override double? Price
        {
            get
            {
                return 0.12;
            }
        }

        /// <summary>
        /// Gets the calories for the Water
        /// </summary>
        public override uint? Calories
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets if the water has a lemon
        /// </summary>
        private bool lemon = false;
        public bool Lemon
        {
            get { return lemon; }
            set
            {
                lemon = value;
                NotifyPropertyChanged("Lemon");
            }
        }

        /// <summary>
        /// Gets the special instructions for the water
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();

                if (!Ice) instructions.Add("Hold Ice");
                if (Lemon) instructions.Add("Add Lemon");

                return instructions;
            }
        }

        /// <summary>
        /// Returns the size and name of the Water
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Size.ToString() + " Water";
        }
    }
}