﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CowboyCafe.Data;
using System.Linq;
using System.ComponentModel;

namespace CowboyCafe.DataTests
{
    public class TexasTeaTest
    {
        [Fact]
        public void ShouldBeIcedByDefault()
        {
            var tea = new TexasTea();
            Assert.True(tea.Ice);
        }

        [Fact]
        public void ShouldBeAbleToSetIce()
        {
            var tea = new TexasTea();
            tea.Ice = false;
            Assert.False(tea.Ice);
            tea.Ice = true;
            Assert.True(tea.Ice);
        }

        [Fact]
        public void ShouldBeSweetByDefault()
        {
            var tea = new TexasTea();
            Assert.True(tea.Sweet);
        }

        [Fact]
        public void ShouldBeAbleToSetSweetness()
        {
            var tea = new TexasTea();
            tea.Sweet = false;
            Assert.False(tea.Sweet);
            tea.Sweet = true;
            Assert.True(tea.Sweet);
        }

        [Fact]
        public void ShouldNotHaveLemonByDefault()
        {
            var tea = new TexasTea();
            Assert.False(tea.Lemon);
        }

        [Fact]
        public void ShouldBeAbleToSetLemon()
        {
            var tea = new TexasTea();
            tea.Lemon = true;
            Assert.True(tea.Lemon);
            tea.Lemon = false;
            Assert.False(tea.Lemon);
        }

        [Fact]
        public void ShouldBeSmallByDefault()
        {
            var tea = new TexasTea();
            Assert.Equal(Size.Small, tea.Size);
        }

        [Fact]
        public void ShouldBeAbleToSetSize()
        {
            var tea = new TexasTea();
            tea.Size = Size.Large;
            Assert.Equal(Size.Large, tea.Size);
            tea.Size = Size.Medium;
            Assert.Equal(Size.Medium, tea.Size);
            tea.Size = Size.Small;
            Assert.Equal(Size.Small, tea.Size);
        }

        [Theory]
        [InlineData(Size.Small, 1.00)]
        [InlineData(Size.Medium, 1.50)]
        [InlineData(Size.Large, 2.00)]
        public void ShouldHaveCorrectPriceForSize(Size size, double price)
        {
            var tea = new TexasTea()
            {
                Size = size
            };
            Assert.Equal(price, tea.Price);
        }

        [Theory]
        [InlineData(Size.Small, true, 10)]
        [InlineData(Size.Medium, true, 22)]
        [InlineData(Size.Large, true, 36)]
        [InlineData(Size.Small, false, 5)]
        [InlineData(Size.Medium, false, 11)]
        [InlineData(Size.Large, false, 18)]
        public void ShouldHaveCorrectCaloriesForSizeAndSweetness(Size size, bool sweet, uint calories)
        {
            var tea = new TexasTea()
            {
                Size = size,
                Sweet = sweet
            };
            Assert.Equal(calories, tea.Calories);
        }

        [Theory]
        [InlineData(false, false)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(true, true)]
        public void ShouldHaveCorrectSpecialInstructionsForIceAndLemon(bool ice, bool lemon)
        {
            var tea = new TexasTea()
            {
                Ice = ice,
                Lemon = lemon,
            };
            if (!ice) Assert.Contains("Hold Ice", tea.SpecialInstructions);
            if (lemon) Assert.Contains("Add Lemon", tea.SpecialInstructions);
            if (ice && !lemon) Assert.Empty(tea.SpecialInstructions);
            if (ice && lemon || !ice && !lemon) Assert.Single(tea.SpecialInstructions);
            if (!ice && lemon) Assert.Equal(2, tea.SpecialInstructions.ToList().Count);
        }

        [Fact]
        public void TexasTeaImplementsINotifyPropertyChanged()
        {
            var tea = new TexasTea();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(tea);
        }

        [Fact]
        public void ChangingSizePropertyShouldInvokePropertyChangedForSize()
        {
            var tea = new TexasTea();
            Assert.PropertyChanged(tea, "Size", () =>
            {
                tea.Size = Size.Medium;
            });
        }

        [Fact]
        public void ChangingSizePropertyShouldInvokePropertyChangedForCalories()
        {
            var tea = new TexasTea();
            Assert.PropertyChanged(tea, "Calories", () =>
            {
                tea.Size = Size.Medium;
            });
        }

        [Fact]
        public void ChangingSizePropertyShouldInvokePropertyChangedForPrice()
        {
            var tea = new TexasTea();
            Assert.PropertyChanged(tea, "Price", () =>
            {
                tea.Size = Size.Medium;
            });
        }

        [Fact]
        public void ChangingSweetPropertyShouldInvokePropertyChangedForSweet()
        {
            var tea = new TexasTea();
            Assert.PropertyChanged(tea, "Sweet", () =>
            {
                tea.Sweet = false;
            });
        }

        [Fact]
        public void ChangingSweetPropertyShouldInvokePropertyChangedForCalories()
        {
            var tea = new TexasTea();
            Assert.PropertyChanged(tea, "Calories", () =>
            {
                tea.Sweet = false;
            });
        }

        [Fact]
        public void ChangingIcePropertyShouldInvokePropertyChangedForIce()
        {
            var tea = new TexasTea();
            Assert.PropertyChanged(tea, "Ice", () =>
            {
                tea.Ice = false;
            });
        }

        [Fact]
        public void ChangingIcePropertyShouldInvokePropertyChangedForSpecialInstructions()
        {
            var tea = new TexasTea();
            Assert.PropertyChanged(tea, "SpecialInstructions", () =>
            {
                tea.Ice = false;
            });
        }

        [Fact]
        public void ChangingLemonPropertyShouldInvokePropertyChangedForLemon()
        {
            var tea = new TexasTea();
            Assert.PropertyChanged(tea, "Lemon", () =>
            {
                tea.Lemon = true;
            });
        }

        [Fact]
        public void ChangingLemonPropertyShouldInvokePropertyChangedForSpecialInstructions()
        {
            var tea = new TexasTea();
            Assert.PropertyChanged(tea, "SpecialInstructions", () =>
            {
                tea.Lemon = true;
            });
        }
    }
}