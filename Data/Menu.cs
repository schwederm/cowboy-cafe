using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
        public static IEnumerable<IOrderItem> All()
        {
            List<IOrderItem> menu = new List<IOrderItem>();

            menu.AddRange(Entrees());
            menu.AddRange(Sides());
            menu.AddRange(Drinks());

            return menu;
        }

        /// <summary>
        /// Returns a list of IOrderItems that reflects the searched terms
        /// </summary>
        /// <param name="terms">The searched terms</param>
        /// <returns>List of IOrderItems according to the searched terms</returns>
        public static IEnumerable<IOrderItem> Search(string terms)
        {
            List<IOrderItem> results = new List<IOrderItem>();

            if (terms == null) return All();

            foreach (IOrderItem item in All())
            {
                if (item.ToString() != null && item.ToString().Contains(terms, StringComparison.InvariantCultureIgnoreCase))
                    results.Add(item);
            }

            return results;
        }

        /// <summary>
        /// Types of Items on the menu
        /// </summary>
        public static string[] TypesOfItem
        {
            get => new string[]
            {
                "Entree",
                "Side",
                "Drink"
            };
        }

        /// <summary>
        /// Returns a list of IOrderItems that reflects the types of items passed in
        /// </summary>
        /// <param name="menu">The menu passed in</param>
        /// <param name="types">The types of items the user is looking for</param>
        /// <returns>List of IOrderItems that reflects the types of items</returns>
        public static IEnumerable<IOrderItem> FilterByCategory(IEnumerable<IOrderItem> menu, IEnumerable<string> types)
        {
            if (types == null || types.Count() == 0) return menu;

            List<IOrderItem> results = new List<IOrderItem>();
            
            foreach (IOrderItem item in menu)
            {
                if (item.Type != null && types.Contains(item.Type))
                    results.Add(item);
            }

            return results;
        }

        /// <summary>
        /// Returns a list of IOrderItems that reflects the range of calories passed in
        /// </summary>
        /// <param name="menu">The menu passed in</param>
        /// <param name="min">The calories minimum</param>
        /// <param name="max">The calories maximum</param>
        /// <returns>List of IOrderItems that reflects the range of calories</returns>
        public static IEnumerable<IOrderItem> FilterByCalories(IEnumerable<IOrderItem> menu, uint? min, uint? max)
        {
            if (min == null && max == null) return menu;

            List<IOrderItem> results = new List<IOrderItem>();

            if (min == null)
            {
                foreach(IOrderItem item in menu)
                {
                    if (item.Calories <= max)
                        results.Add(item);
                }
            }
            
            if (max == null)
            {
                foreach(IOrderItem item in menu)
                {
                    if (item.Calories >= min)
                        results.Add(item);
                }
            }

            else
            {
                foreach(IOrderItem item in menu)
                {
                    if (item.Calories >= min && item.Calories <= max)
                        results.Add(item);
                }
            }

            return results;
        }

        /// <summary>
        /// Returns a list of IOrderItems that reflects the range of prices passed in
        /// </summary>
        /// <param name="menu">The menu passed in</param>
        /// <param name="min">The price minimum</param>
        /// <param name="max">The price maximum</param>
        /// <returns>List of IOrderItems that reflects the range of prices</returns>
        public static IEnumerable<IOrderItem> FilterByPrice(IEnumerable<IOrderItem> menu, double? min, double? max)
        {
            if (min == null && max == null) return menu;

            List<IOrderItem> results = new List<IOrderItem>();

            if (min == null)
            {
                foreach (IOrderItem item in menu)
                {
                    if (item.Price <= max)
                        results.Add(item);
                }
            }

            if (max == null)
            {
                foreach (IOrderItem item in menu)
                {
                    if (item.Price >= min)
                        results.Add(item);
                }
            }

            else
            {
                foreach (IOrderItem item in menu)
                {
                    if (item.Price >= min && item.Price <= max)
                        results.Add(item);
                }
            }

            return results;
        }
    }
}
