/*
 * Author: Matt Schweder
 * Class Name: Rustlers Ribs.cs
 * Purpose: This class holds the price and calories for the Rustler's Ribs
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    public class RustlersRibs : Entree
    {
        /// <summary>
        /// The price of the Rustlers Ribs
        /// </summary>
        public override double? Price
        {
            get
            {
                return 7.50;
            }
        }

        /// <summary>
        /// The calories of the Rustlers Ribs
        /// </summary>
        public override uint? Calories
        {
            get
            {
                return 894;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of the Rustlers Ribs
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                var instructions = new List<string>();

                return instructions;
            }
        }

        /// <summary>
        /// Returns the name of the Rustler's Ribs
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Rustler's Ribs";
        }
    }
}