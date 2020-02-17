/*
 * Author: Matt Schweder
 * Class Name: CowboyCoffee
 * Purpose This class holds the price, calories, and ingredients of the Cowboy Coffee
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    public class CowboyCoffee : Drink
    {
        /// <summary>
        /// The price of the Cowboy Coffee
        /// </summary>
        public override double Price
        {
            get
            {
                switch (Size)
                {
                    case (Size.Small):
                        return 0.60;
                    case (Size.Medium):
                        return 1.10;
                    case (Size.Large):
                        return 1.60;
                    default:
                        return 0.60;
                }
            }
        }

        /// <summary>
        /// The calories of the Cowboy Coffee
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case (Size.Small):
                        return 3;
                    case (Size.Medium):
                        return 5;
                    case (Size.Large):
                        return 7;
                    default:
                        return 3;
                }
            }
        }

        /// <summary>
        /// If the Cowboy Coffee is decaf
        /// </summary>
        public bool Decaf { get; set; } 

        /// <summary>
        /// If the Cowboy Coffee has cream
        /// </summary>
        public bool RoomForCream { get; set; } = false;

        /// <summary>
        /// If the Cowboy Coffee has ice
        /// </summary>
        public override bool Ice { get; set; } = false;
        
        /// <summary>
        /// Special instructions for the preparation for the Cowboy Coffee
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();

                if (Ice) instructions.Add("Add Ice");
                if (RoomForCream) instructions.Add("Room for Cream");

                return instructions;
            }
        }
    }
}