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
        [TestCategory("Defaults")]
        public void DieNotNull()
        {
            d.Should().NotBeNull();
        }

        [TestMethod]
        [TestCategory("Defaults")]
        public void DieHasAllDefaultValue()
        {
            d.GetName().Should().Be("d6");
            d.GetNumberSides().Should().Be(6);
            d.GetCurrentSide().Should().BeInRange(1, 6);
        }

        [TestMethod]
        [TestCategory("Defaults")]
        public void DefaultRollSetsSideCorrectly()
        {
            for (int i = 0; i < 100; i++)
            {
                d.Roll();
                d.GetCurrentSide().Should().BeInRange(1, 6);
            }
        }

        //[TestMethod]
        //[TestCategory("Defaults")]
        //public void DefaultRollSetsEachSide()
        //{
        //    bool one = false,
        //         two = false,
        //         three = false,
        //         four = false,
        //         five = false,
        //         six = false;
        //    for (int i = 0; i < 1000; i++)
        //    {
        //        d.Roll();
        //        if (d.CurrentSide == 1) one = true;
        //        else if(d.CurrentSide == 2) two = true;
        //        else if(d.CurrentSide == 3) three = true;
        //        else if(d.CurrentSide == 4) four = true;
        //        else if(d.CurrentSide == 5) five = true;
        //        else if(d.CurrentSide == 6) six = true;
        //    }
        //    one.Should().BeTrue();
        //    two.Should().BeTrue();
        //    three.Should().BeTrue();
        //    four.Should().BeTrue();
        //    five.Should().BeTrue();
        //    six.Should().BeTrue();
        //}

        [TestMethod]
        [TestCategory("CustomSides")]
        [DataRow(3, "d3")]
        [DataRow(4, "d4")]
        [DataRow(8, "d8")]
        public void DieHasCustomSides(int sides, string name)
        {
            Die d1 = new Die(sides); 
            d1.GetName().Should().Be(name);
            d1.GetNumberSides().Should().Be(sides);
            d1.GetCurrentSide().Should().BeInRange(1, sides);
        }

        [TestMethod]
        [TestCategory("CustomNames")]
        [DataRow(3, "x", "x3")]
        [DataRow(4, "x", "x4")]
        [DataRow(8, "x", "x8")]
        public void DieHasCustomNames(int sides, string prefix, string name)
        {
            Die d1 = new Die(prefix, sides);
            d1.GetName().Should().Be(name);
            d1.GetNumberSides().Should().Be(sides);
            d1.GetCurrentSide().Should().BeInRange(1, sides);
        }

        [TestMethod]
        [TestCategory("CustomSides")]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(8)]
        public void RollSetsSideCorrectlyCustomSides(int sides)
        {
            Die d1 = new Die(sides);
            for (int i = 0; i < 100; i++)
            {
                d1.Roll();
                d1.GetCurrentSide().Should().BeInRange(1, sides);
            }
        }

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
        public void GetCurrentSideReturnsValue()
        {
            d.GetCurrentSide().Should().BeInRange(1,6);
        }

        [TestMethod]
        [TestCategory("GetMethods")]
        public void GetDefaultNumberSidesReturnsValue()
        {
            d.GetNumberSides().Should().Be(6);
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

