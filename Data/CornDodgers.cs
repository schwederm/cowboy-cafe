/*
 * Author: Matt Schweder
 * Class Name: CornDodgers.cs
 * Purpose: This class holds the size, price, and calories of the Corn Dodgers.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    public class CornDodgers : Side
    {   
        /// <summary>
        /// The calories of Corn Dodgers
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 512;
                    case Size.Medium:
                        return 685;
                    case Size.Large:
                        return 717;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// The price of the Corn Dodgers
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

        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                var instructions = new List<string>();

                return instructions;
            }
        }

        /// <summary>
        /// Returns the size and name of the Corn Dodgers
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Size.ToString() + " Corn Dodgers";
        }
    }
}
