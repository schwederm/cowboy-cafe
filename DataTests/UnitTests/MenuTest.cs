using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CowboyCafe.Data;
using CCMenu = CowboyCafe.Data.Menu;
namespace CowboyCafe.DataTests.UnitTests
{
    public class MenuTest
    {
        [Fact]
        public void VerifyingEntreesAreInEntrees()
        {
            var entrees = CCMenu.Entrees();
            var Entrees = new List<string>();
            foreach(IOrderItem item in entrees)
            {
                Entrees.Add(entrees.ToString());
            }

            var items = new List<IOrderItem>
            {
                new AngryChicken(),
                new CowpokeChili(),
                new DakotaDoubleBurger(),
                new PecosPulledPork(),
                new RustlersRibs(),
                new TexasTripleBurger(),
                new TrailBurger()
            };
            var Items = new List<string>();
            foreach(IOrderItem item in items)
            {
                Items.Add(items.ToString());
            }

            foreach(string item in Items)
            {
                Assert.Contains(item, Entrees);
            }
        }

        [Fact]
        public void VerifyingSidesAreInSides()
        {
            var sides = CCMenu.Sides();
            var Sides = new List<string>();
            foreach (IOrderItem item in sides)
            {
                Sides.Add(sides.ToString());
            }

            var items = new List<IOrderItem>
            {
                new BakedBeans(),
                new ChiliCheeseFries(),
                new CornDodgers(),
                new PanDeCampo()
            };
            var Items = new List<string>();
            foreach (IOrderItem item in items)
            {
                Items.Add(items.ToString());
            }

            foreach (string item in Items)
            {
                Assert.Contains(item, Sides);
            }
        }

        [Fact]
        public void VerifyingDrinksAreInDrinks()
        {
            var drinks = CCMenu.Sides();
            var Drinks = new List<string>();
            foreach (IOrderItem item in drinks)
            {
                Drinks.Add(drinks.ToString());
            }

            var items = new List<IOrderItem>
            {
                new CowboyCoffee(),
                new JerkedSoda(),
                new TexasTea(),
                new Water()
            };
            var Items = new List<string>();
            foreach (IOrderItem item in items)
            {
                Items.Add(items.ToString());
            }

            foreach (string item in Items)
            {
                Assert.Contains(item, Drinks);
            }
        }

        [Fact]
        public void VerifyingItemsAreInMenu()
        {
            var menu = CCMenu.All();
            var Menu = new List<string>();
            foreach (IOrderItem item in menu)
            {
                Menu.Add(menu.ToString());
            }

            var items = new List<IOrderItem>
            {
                new AngryChicken(),
                new BakedBeans(),
                new ChiliCheeseFries(),
                new CornDodgers(),
                new CowboyCoffee(),
                new CowpokeChili(),
                new DakotaDoubleBurger(),
                new JerkedSoda(),
                new PanDeCampo(),
                new PecosPulledPork(),
                new RustlersRibs(),
                new TexasTea(),
                new TexasTripleBurger(),
                new TrailBurger(),
                new Water()
            };
            var Items = new List<string>();
            foreach (IOrderItem item in items)
            {
                Items.Add(items.ToString());
            }

            foreach (string item in Items)
            {
                Assert.Contains(item, Menu);
            }
        }

        [Fact]
        public void VerifyingBurgerSearch()
        {
            var searchTerm = "Burger";
            var results = CCMenu.Search(searchTerm);
            var Results = new List<string>();
            foreach (IOrderItem item in results)
            {
                Results.Add(item.ToString());
            }

            var burgers = new List<IOrderItem>
            {
                new DakotaDoubleBurger(),
                new TexasTripleBurger(),
                new TrailBurger()
            };
            var Burgers = new List<string>();
            foreach (IOrderItem item in burgers)
            {
                Burgers.Add(item.ToString());
            }

            foreach (string item in Burgers)
            {
                Assert.Contains(item, Results);
            }
        }

        [Fact]
        public void VerifyingNullSearch()
        {
            string searchTerm = null;
            var results = CCMenu.Search(searchTerm);
            var Results = new List<string>();
            foreach (IOrderItem item in results)
            {
                Results.Add(item.ToString());
            }

            var items = CCMenu.All();
            var Items = new List<string>();
            foreach (IOrderItem item in items)
            {
                Items.Add(item.ToString());
            }

            foreach (string item in Items)
            {
                Assert.Contains(item, Results);
            }
        }

        [Fact]
        public void VerifyingNullCategoryFilter()
        {
            var filter = new List<string>();
            var menu = CCMenu.All();
            var results = CCMenu.FilterByCategory(menu, filter);
            var Results = new List<string>();
            foreach (IOrderItem item in results)
            {
                Results.Add(item.ToString());
            }

            var items = CCMenu.All();
            var Items = new List<string>();
            foreach (IOrderItem item in items)
            {
                Items.Add(item.ToString());
            }

            foreach (string item in Items)
            {
                Assert.Contains(item, Results);
            }
        }

        [Fact]
        public void VerifyingEntreeCategoryFilter()
        {
            var filters = new List<string> 
            {
                "Entree"
            };
            var menu = CCMenu.All();
            var results = CCMenu.FilterByCategory(menu, filters);
            var Results = new List<string>();
            foreach (IOrderItem item in results)
            {
                Results.Add(item.ToString());
            }

            var items = CCMenu.Entrees();
            var Items = new List<string>();
            foreach (IOrderItem item in items)
            {
                Items.Add(item.ToString());
            }

            foreach (string item in Items)
            {
                Assert.Contains(item, Results);
            }
        }

        [Fact]
        public void VerifyingEntreeSideCategoryFilter()
        {
            var filters = new List<string>
            {
                "Entree",
                "Side"
            };
            var menu = CCMenu.All();
            var results = CCMenu.FilterByCategory(menu, filters);
            var Results = new List<string>();
            foreach (IOrderItem item in results)
            {
                Results.Add(item.ToString());
            }

            var entrees = CCMenu.Entrees();
            var sides = CCMenu.Sides();
            var items = new List<IOrderItem>();
            items.AddRange(entrees);
            items.AddRange(sides);
            var Items = new List<string>();
            foreach (IOrderItem item in items)
            {
                Items.Add(item.ToString());
            }

            foreach (string item in Items)
            {
                Assert.Contains(item, Results);
            }
        }

        [Fact]
        public void VerifyingNullCaloriesFilter()
        {
            var menu = CCMenu.All();
            var results = CCMenu.FilterByCalories(menu, null, null);
            var Results = new List<string>();
            foreach (IOrderItem item in results)
            {
                Results.Add(item.ToString());
            }

            var items = CCMenu.All();
            var Items = new List<string>();
            foreach (IOrderItem item in items)
            {
                Items.Add(item.ToString());
            }

            foreach (string item in Items)
            {
                Assert.Contains(item, Results);
            }
        }

        [Fact]
        public void VerifyingCaloriesMinFilter()
        {
            var menu = CCMenu.All();
            uint CaloriesMin = 600;
            var results = CCMenu.FilterByCalories(menu, CaloriesMin, null);
            var Results = new List<string>();
            foreach (IOrderItem item in results)
            {
                Results.Add(item.ToString());
            }

            var items = new List<IOrderItem>
            {
                new RustlersRibs(),
                new TexasTripleBurger(),
                new ChiliCheeseFries(Size.Large),
                new CornDodgers(Size.Medium),
                new CornDodgers(Size.Large)
            };
            var Items = new List<string>();
            foreach (IOrderItem item in items)
            {
                Items.Add(item.ToString());
            }

            foreach (string item in Items)
            {
                Assert.Contains(item, Results);
            }
        }

        [Fact]
        public void VerifyingCaloriesMaxFilter()
        {
            var menu = CCMenu.All();
            uint CaloriesMax = 100;
            var results = CCMenu.FilterByCalories(menu, null, CaloriesMax);
            var Results = new List<string>();
            foreach (IOrderItem item in results)
            {
                Results.Add(item.ToString());
            }

            var items = new List<IOrderItem>
            {
                new CowboyCoffee(Size.Small),
                new CowboyCoffee(Size.Medium),
                new CowboyCoffee(Size.Large),
                new TexasTea(Size.Small),
                new TexasTea(Size.Medium),
                new TexasTea(Size.Large),
                new Water()
            };
            var Items = new List<string>();
            foreach (IOrderItem item in items)
            {
                Items.Add(item.ToString());
            }

            foreach (string item in Items)
            {
                Assert.Contains(item, Results);
            }
        }

        [Fact]
        public void VerifyingCaloriesMinAndMaxFilter()
        {
            var menu = CCMenu.All();
            uint CaloriesMin = 300;
            uint CaloriesMax = 500;
            var results = CCMenu.FilterByCalories(menu, CaloriesMin, CaloriesMax);
            var Results = new List<string>();
            foreach (IOrderItem item in results)
            {
                Results.Add(item.ToString());
            }

            var items = new List<IOrderItem>
            {
                new DakotaDoubleBurger(),
                new BakedBeans(Size.Small),
                new BakedBeans(Size.Medium),
                new BakedBeans(Size.Large),
                new PanDeCampo(Size.Large)
            };
            var Items = new List<string>();
            foreach (IOrderItem item in items)
            {
                Items.Add(item.ToString());
            }

            foreach (string item in Items)
            {
                Assert.Contains(item, Results);
            }
        }

        [Fact]
        public void VerifyingNullPriceFilter()
        {
            var menu = CCMenu.All();
            var results = CCMenu.FilterByPrice(menu, null, null);
            var Results = new List<string>();
            foreach (IOrderItem item in results)
            {
                Results.Add(item.ToString());
            }

            var items = CCMenu.All();
            var Items = new List<string>();
            foreach (IOrderItem item in items)
            {
                Items.Add(item.ToString());
            }

            foreach (string item in Items)
            {
                Assert.Contains(item, Results);
            }
        }

        [Fact]
        public void VerifyingPriceMinFilter()
        {
            var menu = CCMenu.All();
            double PriceMin = 6.00;
            var results = CCMenu.FilterByPrice(menu, PriceMin, null);
            var Results = new List<string>();
            foreach (IOrderItem item in results)
            {
                Results.Add(item.ToString());
            }

            var items = new List<IOrderItem>
            {
                new CowpokeChili(),
                new RustlersRibs(),
                new TexasTripleBurger()
            };
            var Items = new List<string>();
            foreach (IOrderItem item in items)
            {
                Items.Add(item.ToString());
            }

            foreach (string item in Items)
            {
                Assert.Contains(item, Results);
            }
        }

        [Fact]
        public void VerifyingPriceMaxFilter()
        {
            var menu = CCMenu.All();
            double PriceMax = 1.50;
            var results = CCMenu.FilterByPrice(menu, null, PriceMax);
            var Results = new List<string>();
            foreach (IOrderItem item in results)
            {
                Results.Add(item.ToString());
            }

            var items = new List<IOrderItem>
            {
                new CowboyCoffee(Size.Small),
                new CowboyCoffee(Size.Medium),
                new TexasTea(Size.Small),
                new TexasTea(Size.Medium),
                new Water()
            };
            var Items = new List<string>();
            foreach (IOrderItem item in items)
            {
                Items.Add(item.ToString());
            }

            foreach (string item in Items)
            {
                Assert.Contains(item, Results);
            }
        }

        [Fact]
        public void VerifyingPriceMinAndMaxFilter()
        {
            var menu = CCMenu.All();
            double PriceMin = 2.00;
            double PriceMax = 4.00;
            var results = CCMenu.FilterByPrice(menu, PriceMin, PriceMax);
            var Results = new List<string>();
            foreach (IOrderItem item in results)
            {
                Results.Add(item.ToString());
            }

            var items = new List<IOrderItem>
            {
                new ChiliCheeseFries(Size.Medium),
                new ChiliCheeseFries(Size.Large),
                new JerkedSoda(Size.Medium),
                new JerkedSoda(Size.Large),
                new TexasTea(Size.Large)
            };
            var Items = new List<string>();
            foreach (IOrderItem item in items)
            {
                Items.Add(item.ToString());
            }

            foreach (string item in Items)
            {
                Assert.Contains(item, Results);
            }
        }
    }
}