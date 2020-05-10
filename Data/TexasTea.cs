/*
 * Author: Matt Schweder
 * Class Name: TexasTea.cs
 * Purpose: This class holds the price, calories, and special ingredients for Texas Tea and if the Texas Tea has lemon and ice.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    public class TexasTea : Drink
    {
        /// <summary>
        /// Gets the price for the Texas Tea
        /// </summary>
        public override double Price
        {
            get
            {
                switch (Size)
                {
                    case (Size.Small):
                        return 1.00;
                    case (Size.Medium):
                        return 1.50;
                    case (Size.Large):
                        return 2.00;
                    default:
                        return 1.00;
                }
            }
        }

        /// <summary>
        /// Gets the calories for the Texas Tea
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case (Size.Small):
                        if (Sweet)
                            return 10;
                        else
                            return 5;
                    case (Size.Medium):
                        if (Sweet)
                            return 22;
                        else
                            return 11;
                    case (Size.Large):
                        if (Sweet)
                            return 36;
                        else
                            return 18;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// Gets if the tea is sweet
        /// </summary>
        private bool sweet = true;
        public bool Sweet
        {
            get { return sweet; }
            set
            {
                sweet = value;
                NotifyPropertyChanged("Sweet");
                NotifyPropertyChanged("Calories");
            }
        }

        /// <summary>
        /// Gets if the tea has lemon
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
        /// Gets the special instructions for the Texas Tea
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
        /// Constructor with no parameters
        /// </summary>
        public TexasTea() { }

        /// <summary>
        /// Constructor with size parameter
        /// </summary>
        /// <param name="s">Passed in size</param>
        public TexasTea(Size s)
        {
            this.Size = s;
        }

        /// <summary>
        /// Returns the name of the Texas Tea and if the tea is sweet or not
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (Sweet)
                return Size.ToString() + " Texas Sweet Tea";
            else
                return Size.ToString() + " Texas Plain Tea"; 
        }
    }
}