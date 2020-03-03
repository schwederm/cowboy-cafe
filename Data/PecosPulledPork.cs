/*
 * Author: Matt Schweder
 * Class Name: PecosPulledPork.cs
 * Purpose: This class holds all the optional ingredients, price, calories, and special instructions for the Peco's Pulled Pork
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    public class PecosPulledPork : Entree
    {
        /// <summary>
        /// If the Pecos Pulled Pork comes with bread
        /// </summary>
        public bool Bread { get; set; } = true;

        /// <summary>
        /// If the Pecos Pulled Pork comes with a pickle
        /// </summary>
        public bool Pickle { get; set; } = true;

        /// <summary>
        /// The price of the Pecos Pulled Pork
        /// </summary>
        public override double Price
        {
            get
            {
                return 5.88;
            }
        }

        /// <summary>
        /// The calories of the Pecos Pulled Pork
        /// </summary>
        public override uint Calories
        {
            get
            {
                return 528;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of the Pecos Pulled Pork
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                var instructions = new List<string>();

                if (!Bread) instructions.Add("hold bread");
                if (!Pickle) instructions.Add("hold pickle");

                return instructions;
            }
        }

        /// <summary>
        /// Returns the name of the Pecos Pulled Pork
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Pecos Pulled Pork";
        }
    }
}
