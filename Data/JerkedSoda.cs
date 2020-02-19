/*
 * Author: Matt Schweder
 * Class Name: JerkedSoda.cs
 * Purpose: This class holds the price, calories, soda flavor, and the special ingredients for the Jerked Soda
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    public class JerkedSoda : Drink
    {
        /// <summary>
        /// Gets the price for the Jerked Soda
        /// </summary>
        public override double Price
        {
            get
            {
                switch (Size)
                {
                    case (Size.Small):
                        return 1.59;
                    case (Size.Medium):
                        return 2.10;
                    case (Size.Large):
                        return 2.59;
                    default:
                        return 1.59;
                }
            }
        }

        /// <summary>
        /// Gets the calories for the Jerked Soda
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case (Size.Small):
                        return 110;
                    case (Size.Medium):
                        return 146;
                    case (Size.Large):
                        return 198;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// Gets the soda flavor for the Jerked Soda
        /// </summary>
        public SodaFlavor Flavor { get; set; }

        /// <summary>
        /// Gets the special instructions for the Jerked Soda
        /// </summary>
        public override List<string> SpecialInstructions
        {

            get
            {
                var instructions = new List<string>();

                if (!Ice) instructions.Add("Hold Ice");

                return instructions;
            }
        }

        public override string ToString()
        {
            switch (Flavor) 
            {
                return Size.ToString() + " " + Flavor.ToString() + " Jerked Soda";
            }
        }
    }
}