using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    public static class Menu
    {
        /// <summary>
        /// Builds a list of entree items
        /// </summary>
        /// <returns>List of entrees</returns>
        public static IEnumerable<IOrderItem> Entrees()
        {
            List<IOrderItem> entrees = new List<IOrderItem>();

            entrees.Add(new AngryChicken());
            entrees.Add(new CowpokeChili());
            entrees.Add(new DakotaDoubleBurger());
            entrees.Add(new PecosPulledPork());
            entrees.Add(new RustlersRibs());
            entrees.Add(new TexasTripleBurger());
            entrees.Add(new TrailBurger());

            return entrees;
        }

        /// <summary>
        /// Builds a list of sides with each size
        /// </summary>
        /// <returns>List of sides in each size</returns>
        public static IEnumerable<IOrderItem> Sides()
        {
            List<IOrderItem> sides = new List<IOrderItem>();

            sides.Add(new BakedBeans(Size.Small));
            sides.Add(new BakedBeans(Size.Medium));
            sides.Add(new BakedBeans(Size.Large));

            sides.Add(new ChiliCheeseFries(Size.Small));
            sides.Add(new ChiliCheeseFries(Size.Medium));
            sides.Add(new ChiliCheeseFries(Size.Large));

            sides.Add(new CornDodgers(Size.Small));
            sides.Add(new CornDodgers(Size.Medium));
            sides.Add(new CornDodgers(Size.Large));

            sides.Add(new PanDeCampo(Size.Small));
            sides.Add(new PanDeCampo(Size.Medium)); 
            sides.Add(new PanDeCampo(Size.Large));

            return sides;
        }

        /// <summary>
        /// Builds a list of drink with each size except for water
        /// </summary>
        /// <returns>List of drinks with each size except for water</returns>
        public static IEnumerable<IOrderItem> Drinks()
        {
            List<IOrderItem> drinks = new List<IOrderItem>();

            drinks.Add(new CowboyCoffee(Size.Small));
            drinks.Add(new CowboyCoffee(Size.Medium));
            drinks.Add(new CowboyCoffee(Size.Large));

            drinks.Add(new JerkedSoda(Size.Small));
            drinks.Add(new JerkedSoda(Size.Medium));
            drinks.Add(new JerkedSoda(Size.Large));

            drinks.Add(new TexasTea(Size.Small));
            drinks.Add(new TexasTea(Size.Medium));
            drinks.Add(new TexasTea(Size.Large));

            drinks.Add(new Water());

            return drinks;
        }

        /// <summary>
        /// Builds a list of the complete menu
        /// </summary>
        /// <returns>List of the menu</returns>
        public static IEnumerable<IOrderItem> CompleteMenu()
        {
            List<IOrderItem> menu = new List<IOrderItem>();

            menu.AddRange(Entrees());
            menu.AddRange(Sides());
            menu.AddRange(Drinks());

            return menu;
        }
    }
}
