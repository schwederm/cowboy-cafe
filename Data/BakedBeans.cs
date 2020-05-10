/*
 * Author: Matt Schweder
 * Class Name: BakedBeans.cs
 * Purpose: This class holds the size, price, and calories of the Baked Beans.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    public class BakedBeans : Side
    {
        /// <summary>
        /// The calories of the Baked Beans
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 312;
                    case Size.Medium:
                        return 378;
                    case Size.Large:
                        return 410;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// The price of the Baked Beans
        /// </summary>
        public override double Price
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 1.59;
                    case Size.Medium:
                        return 1.79;
                    case Size.Large:
                        return 1.99;
                    default:
                        return 1.59;
                }
            }
        }

        /// <summary>
        /// Special instructions for the Baked Beans
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
        public BakedBeans() { }

        /// <summary>
        /// Constructor with size parameter
        /// </summary>
        /// <param name="s">Passed in size</param>
        public BakedBeans(Size s)
        {
            this.Size = s;
        }

        /// <summary>
        /// Returns the size and name of the Baked Beans
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Size.ToString() + " Baked Beans";
        }
    }
}
