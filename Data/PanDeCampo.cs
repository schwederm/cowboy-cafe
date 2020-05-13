/*
 * Author: Matt Schweder
 * Class Name: PanDeCampo.cs
 * Purpose: This class holds the size, calories, and price of the Pan de Campo
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    public class PanDeCampo : Side
    {
        /// <summary>
        /// The calories of the Pan de Campo
        /// </summary>
        public override uint? Calories
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 227;
                    case Size.Medium:
                        return 269;
                    case Size.Large:
                        return 367;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// The price of the Pan de Campo
        /// </summary>
        public override double? Price
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
        /// Special instructions for Pan de Campo
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
        public PanDeCampo() { }

        /// <summary>
        /// Constructor with size parameter
        /// </summary>
        /// <param name="s">Passed in size</param>
        public PanDeCampo(Size s)
        {
            this.Size = s;
        }

        /// <summary>
        /// Returns the size and name of the Pan de Campo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Size.ToString() + " Pan de Campo";
        }
    }
}
