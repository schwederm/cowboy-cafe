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
        public override double? Price
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
        public override uint? Calories
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
        private SodaFlavor flavor = SodaFlavor.CreamSoda;
        public SodaFlavor Flavor
        {
            get { return flavor; }
            set
            {
                flavor = value;
                NotifyPropertyChanged("Flavor");
            }
        }

        /// <summary>
        /// Gets the special instructions for the Jerked Soda
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {

            get
            {
                var instructions = new List<string>();

                if (!Ice) instructions.Add("Hold Ice");

                return instructions;
            }
        }

        /// <summary>
        /// Constructor with no parameters
        /// </summary>
        public JerkedSoda() { }

        /// <summary>
        /// Constructor with size parameter
        /// </summary>
        /// <param name="s">Passed in size</param>
        public JerkedSoda(Size s)
        {
            this.Size = s;
        }

        /// <summary>
        /// Returns the size, flavor and name of the Jerked Soda
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            switch (Flavor) 
            {
                case SodaFlavor.BirchBeer:
                    return Size.ToString() + " Birch Beer Jerked Soda";
                case SodaFlavor.CreamSoda:
                    return Size.ToString() + " Cream Soda Jerked Soda";
                case SodaFlavor.OrangeSoda:
                    return Size.ToString() + " Orange Soda Jerked Soda";
                case SodaFlavor.RootBeer:
                    return Size.ToString() + " Root Beer Jerked Soda";
                default:
                    return Size.ToString() + " " + Flavor.ToString() + " Jerked Soda";
            }
        }
    }
}