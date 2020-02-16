using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    public class JerkedSoda : Drink
    {
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

        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case (Size.Small):
                        return 110;
                    case(Size.Medium):
                        return 146;
                    case (Size.Large):
                        return 198;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public SodaFlavor Flavor { get; set; }

        public override List<string> SpecialInstructions
        {

            get
            {
                var instructions = new List<string>();

                if (!ice) instructions.Add("Hold Ice");

                return instructions;
            }
        }
    }
}
