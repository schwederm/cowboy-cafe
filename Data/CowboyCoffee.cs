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
        public override double? Price
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
        public override uint? Calories
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
        private bool decaf = false;
        public bool Decaf
        {
            get { return decaf; }
            set
            {
                decaf = value;
                NotifyPropertyChanged("Decaf");
            }
        }

        /// <summary>
        /// If the Cowboy Coffee has cream
        /// </summary>
        private bool roomForCream = false;
        public bool RoomForCream
        {
            get { return roomForCream; }
            set
            {
                roomForCream = value;
                NotifyPropertyChanged("RoomForCream");
            }
        }

        /// <summary>
        /// If the Cowboy Coffee has ice
        /// </summary>
        private bool ice = false;
        public override bool Ice
        {
            get { return ice; }
            set
            {
                ice = value;
                NotifyPropertyChanged("Ice");
            }
        }
        
        /// <summary>
        /// Special instructions for the preparation for the Cowboy Coffee
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();

                if (Ice) instructions.Add("Add Ice");
                if (RoomForCream) instructions.Add("Room for Cream");

                return instructions;
            }
        }

        /// <summary>
        /// Constructor with no parameters
        /// </summary>
        public CowboyCoffee() { }

        /// <summary>
        /// Constructor with size parameter
        /// </summary>
        /// <param name="s">Passed in size</param>
        public CowboyCoffee(Size s)
        {
            this.Size = s;
        }

        /// <summary>
        /// Returns the size and name of the Cowboy Coffee and if it's decaf or not
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (Decaf)
                return Size.ToString() + " Decaf Cowboy Coffee";
            else
                return Size.ToString() + " Cowboy Coffee";
        }
    }
}