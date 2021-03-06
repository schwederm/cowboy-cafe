﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;
using CowboyCafe.Data;
using System.ComponentModel;

namespace CowboyCafe.DataTests
{
    class MockOrderItem : IOrderItem
    {
        public double? Price { get; set; }

        public uint? Calories { get; set; }

        public string Type { get; set; }

        public IEnumerable<string> SpecialInstructions { get; set; }
    }

    public class OrderTests
    {
        // Adding something to the order should 
        // have it appear in the order
        [Fact]
        public void AddedIOrderItemAppearInItemsProperty()
        {
            var order = new Order();
            var item = new MockOrderItem();
            order.Add(item);
            Assert.Contains(item, order.Items);
        }

        [Fact]
        public void RemovedOrderItemDoesNotAppearInItemsProperty()
        {
            var order = new Order();
            var item = new MockOrderItem();
            order.Add(item);
            order.Remove(item);
            Assert.DoesNotContain(item, order.Items);
        }

        [Theory]
        [InlineData(new double[] {})]
        [InlineData(new double[] {0})]
        [InlineData(new double[] {10, 15, 18})]
        [InlineData(new double[] {20, -4, 3.6, 8})]
        [InlineData(new double[] {-100, -5})]
        public void SubtotalShouldBeTheSumOfOrderItemPrices(double[] prices)
        {
            var order = new Order();
            double total = 0;
            foreach (var price in prices)
            {
                total += price;
                order.Add(new MockOrderItem() {
                    Price = price
                });
            }
            Assert.Equal(total, order.Subtotal);
        }

        [Fact]
        public void ItemsShouldContainOnlyAddedItems()
        {
            var items = new IOrderItem[]
            {
                new MockOrderItem() { Price = 3 },
                new MockOrderItem() { Price = 5 },
                new MockOrderItem() { Price = 7 }
            };
            var order = new Order();
            foreach(var item in items)
            {
                order.Add(item);
            }
            Assert.Equal(items.Length, order.Items.Count());
            foreach(var item in items)
            {
                Assert.Contains(item, order.Items);
            }
        }

        [Fact]
        public void OrderImplementsINotifyPropertyChanged()
        {
            var order = new Order();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(order);
        }

        [Fact]
        public void AddingItemShouldInvokePropertyChangedForItemsProperty()
        {
            var order = new Order();
            IOrderItem item = new AngryChicken();
            Assert.PropertyChanged(order, "Items", () =>
            {
                order.Add(item);
            });
        }

        [Fact]
        public void AddingItemShouldInvokePropertyChangedForSubtotalProperty()
        {
            var order = new Order();
            IOrderItem item = new AngryChicken();
            Assert.PropertyChanged(order, "Subtotal", () =>
            {
                order.Add(item);
            });
        }

        [Fact]
        public void RemovingItemShouldInvokePropertyChangedForItemsProperty()
        {
            var order = new Order();
            IOrderItem item = new AngryChicken();
            Assert.PropertyChanged(order, "Items", () =>
            {
                order.Remove(item);
            });
        }

        [Fact]
        public void RemovingItemShouldInvokePropertyChangedForSubtotalProperty()
        {
            var order = new Order();
            IOrderItem item = new AngryChicken();
            Assert.PropertyChanged(order, "Subtotal", () =>
            {
                order.Remove(item);
            });
        }
    }
}
