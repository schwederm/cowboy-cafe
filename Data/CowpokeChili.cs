/*
 * Author: Nathan Bean
 * Edited By: Matt Schweder
 * Class Name: CowpokeChilli.cs
 * Purpose: This class holds all the optional ingredients, price, calories, and the special instructions for the Cowpoke Chilli
*/

using System;
using System.Collections.Generic;

namespace CowboyCafe.Data
{
    /// <summary>
    /// A class representing the Cowpoke Chili entree
    /// </summary>
    public class CowpokeChili : Entree
    {
        private bool cheese = true;
        /// <summary>
        /// If the Cowpoke Chili is topped with cheese
        /// </summary>
        public bool Cheese 
        {
            get { return cheese; }
            set { cheese = value; }
        }

        private bool sourCream = true;
        /// <summary>
        /// If the Cowpoke Chili is topped with sour cream
        /// </summary>
        public bool SourCream 
        {
            get { return sourCream; }
            set { sourCream = value; }
        }

        private bool greenOnions = true;
        /// <summary>
        /// If the Cowpoke Chili is topped with green onions
        /// </summary>
        public bool GreenOnions 
        {
            get { return greenOnions; }
            set { greenOnions = value; }
        }

        private bool tortillaStrips = true;
        /// <summary>
        /// If the Cowpoke Chili is topped with tortilla strips
        /// </summary>
        public bool TortillaStrips
        {
            get { return tortillaStrips; }
            set { tortillaStrips = value; }
        }

        /// <summary>
        /// The price of the Cowpoke Chili
        /// </summary>
        public override double Price
        {
            get
            {
                return 6.10;
            }
        }

        /// <summary>
        /// The calories of the Cowpoke Chili
        /// </summary>
        public override uint Calories
        {
            get
            {
                return 171;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of the Cowpoke Chili
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                var instructions = new List<string>();

                if (!cheese) instructions.Add("hold cheese");
                if (!sourCream) instructions.Add("hold sour cream");
                if (!greenOnions) instructions.Add("hold green onions");
                if (!tortillaStrips) instructions.Add("hold tortilla strips");

                return instructions;
            }
        }

        /// <summary>
        /// Returns the name of the Cowpoke Chili
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Cowpoke Chili";
        }
    }
}

