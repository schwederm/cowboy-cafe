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
        private bool bread = true;
        public bool Bread
        {
            get { return bread; }
            set
            {
                bread = value;
                NotifyPropertyChanged("Bread");
            }
        }

        /// <summary>
        /// If the Pecos Pulled Pork comes with a pickle
        /// </summary>
        private bool pickle = true;
        public bool Pickle
        {
            get { return pickle; }
            set
            {
                pickle = value;
                NotifyPropertyChanged("Pickle");
            }
        }

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
            return "Peco's Pulled Pork";
        }
    }
}
