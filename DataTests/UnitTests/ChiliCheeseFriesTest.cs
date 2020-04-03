using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CowboyCafe.Data;
using System.ComponentModel;

namespace CowboyCafe.DataTests
{
    public class ChiliCheeseFriesTest
    {
        [Fact]
        public void ShouldHaveCorrectDefaultPrice()
        {
            ChiliCheeseFries fries = new ChiliCheeseFries();
            Assert.Equal(1.99, fries.Price);
        }

        [Fact]
        public void ShouldHaveCorrectDefaultCalories()
        {
            ChiliCheeseFries fries = new ChiliCheeseFries();
            Assert.Equal<uint>(433, fries.Calories);
        }

        [Fact]
        public void ShouldHaveCorrectDefaultSize()
        {
            ChiliCheeseFries fries = new ChiliCheeseFries();
            Assert.Equal<Size>(Size.Small, fries.Size);
        }

        [Theory]
        [InlineData(Size.Small, 1.99)]
        [InlineData(Size.Medium, 2.99)]
        [InlineData(Size.Large, 3.99)]
        public void ShouldUseCorrectPriceForSize(Size size, double price)
        {
            ChiliCheeseFries fries = new ChiliCheeseFries();
            fries.Size = Size.Medium;
            fries.Size = size;
            Assert.Equal(price, fries.Price);
        }

        [Theory]
        [InlineData(Size.Small, 433)]
        [InlineData(Size.Medium, 524)]
        [InlineData(Size.Large, 610)]
        public void ShouldUseCorrectCaloriesForSize(Size size, uint calories)
        {
            ChiliCheeseFries fries = new ChiliCheeseFries();
            fries.Size = Size.Medium;
            fries.Size = size;
            Assert.Equal<uint>(calories, fries.Calories);
        }

        [Fact]
        public void ChiliCheeseFriesImplementsINotifyPropertyChanged()
        {
            var fries = new ChiliCheeseFries();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(fries);
        }

        [Fact]
        public void ChangingSizePropertyShouldInvokePropertyChangedForSize()
        {
            var fries = new ChiliCheeseFries();
            Assert.PropertyChanged(fries, "Size", () =>
            {
                fries.Size = Size.Medium;
            });
        }

        [Fact]
        public void ChangingSizePropertyShouldInvokePropertyChangedForCalories()
        {
            var fries = new ChiliCheeseFries();
            Assert.PropertyChanged(fries, "Calories", () =>
            {
                fries.Size = Size.Medium;
            });
        }

        [Fact]
        public void ChangingSizePropertyShouldInvokePropertyChangedForPrice()
        {
            var fries = new ChiliCheeseFries();
            Assert.PropertyChanged(fries, "Price", () =>
            {
                fries.Size = Size.Medium;
            });
        }
    }
}