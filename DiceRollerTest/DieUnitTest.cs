using DiceRoller.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiceRollerTest
{
    [TestClass]
    public class DieUnitTest
    {
        Die d = new Die();

        [TestMethod]
        public void DieNotNull()
        {
            d.Should().NotBeNull();
        }

        [TestMethod]
        public void DieHasAllDefaultValue()
        {
            d.Name.Should().Be("d6");
            d.NumberSides.Should().Be(6);
            d.CurrentSide.Should().BeInRange(1, 6);
        }

        [TestMethod]
        public void DefaultRollSetsSideCorrectly()
        {
            for (int i = 0; i < 100; i++)
            {
                d.Roll();
                d.CurrentSide.Should().BeInRange(1, 6);
            }
        }

        [TestMethod]
        [DataRow(3, "d3")]
        [DataRow(4, "d4")]
        [DataRow(8, "d8")]
        public void DieHasCustomSides(int sides, string name)
        {
            Die d1 = new Die(sides); 
            d1.Name.Should().Be(name);
            d1.NumberSides.Should().Be(sides);
            d1.CurrentSide.Should().BeInRange(1, sides);
        }

        [TestMethod]
        [DataRow(3, "x", "x3")]
        [DataRow(4, "x", "x4")]
        [DataRow(8, "x", "x8")]
        public void DieHasCustomNames(int sides, string prefix, string name)
        {
            Die d1 = new Die(prefix, sides);
            d1.Name.Should().Be(name);
            d1.NumberSides.Should().Be(sides);
            d1.CurrentSide.Should().BeInRange(1, sides);
        }

        [TestMethod]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(8)]
        public void DefaultRollSetsSideCorrectlyCustomSides(int sides)
        {
            Die d1 = new Die(sides);
            for (int i = 0; i < 100; i++)
            {
                d1.Roll();
                d1.CurrentSide.Should().BeInRange(1, sides);
            }
        }

        //[TestMethod]
        //[DataRow(3, 2)]
        //[DataRow(4, 2)]
        //public void SetSideUpChangesSide(int sides, int newSides)
        //{
        //    Die d1 = new Die(sides);
        //    //d1.SetSide(newSides); 
        //    //d1.CurrentSide.Should().Be(sides);
        //}

        [TestMethod]
        [TestCategory("SetMethods")]
        [DataRow(3, 2)]
        [DataRow(5, 10)]
        [DataRow(10, -12)]
        public void SetSideUpSetsValidSide(int sides, int newSide)
        {
            Die d1 = new Die(sides);
            d1.SetSideUp(newSide);
            d1.GetCurrentSide().Should().BeInRange(1, sides);
            if (newSide >= 1 && newSide <= sides)
                d1.GetCurrentSide().Should().Be(newSide);
        }

        [TestMethod]
        [TestCategory("GetMethods")]
        public void GetDefaultNameReturnsValue()
        {
            d.GetName().Should().BeOfType<string>();
            d.GetName().Should().Be("d6");
        }

        [TestMethod]
        [TestCategory("GetMethods")]
        [DataRow(3, "x", "x3")]
        [DataRow(4, "x", "x4")]
        [DataRow(8, "x", "x8")]
        public void GetCustomNameReturnsValue(int sides, string prefix, string name)
        {
            Die d1 = new Die(prefix, sides);
            d1.GetName().Should().BeOfType<string>();
            d1.GetName().Should().Be(name);
        }

    }
}

