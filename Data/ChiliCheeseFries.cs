/*
 * Author: Matt Schweder
 * Class Name: ChilliCheeseFries.cs
 * Purpose: This class holds the size, price, and calories of the Chilli Cheese Fries.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    public class ChiliCheeseFries : Side
    {
        /// <summary>
        /// The calories of the Chilli Cheese Fries
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 433;
                    case Size.Medium:
                        return 524;
                    case Size.Large:
                        return 610;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// The price of the Chilli Cheese Fries
        /// </summary>
        public override double Price
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 1.99;
                    case Size.Medium:
                        return 2.99;
                    case Size.Large:
                        return 3.99;
                    default:
                        return 1.99;
                }
            }
        }

        /// <summary>
        /// Special instruction for the Chili Cheese Fries
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
        /// Constructor with no parameters
        /// </summary>
        public ChiliCheeseFries() { }

        /// <summary>
        /// Constructor with size parameter
        /// </summary>
        /// <param name="s">Passed in size</param>
        public ChiliCheeseFries(Size s)
        {
            this.Size = s;
        }

        /// <summary>
        /// Returns the size and name of the Chili Cheese Fries
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Size.ToString() + " Chili Cheese Fries";
        }
    }
}
