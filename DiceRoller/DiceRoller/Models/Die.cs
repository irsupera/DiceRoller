using System;
namespace DiceRoller.Models
{
    public class Die
    {
        public string Name { get; set; }
        public int NumberSides { get; set; }
        public int CurrentSide { get; set; }

        public Die() // default constructor 0 argument
        {
            Name = "d6";
            NumberSides = 6;
            Roll();
        }

        public Die(int numberSides) // constructor 1 argument
        {
            Name = "d" + numberSides;
            NumberSides = numberSides;
            Roll();
        }

        public Die(string namePrefix, int numberSides) // constructor with 2 arguments
        {
            Name = namePrefix + numberSides;
            NumberSides = numberSides;
            Roll();
        }

        public void Roll() // set current side - random number from 1 to no. of sides
        {
            Random r = new Random();
            CurrentSide = r.Next(NumberSides)+1;
        }

        public void SetSideUp(int newSideUp) // set current side up from argument
        {
            if(newSideUp >= 1 && newSideUp <= NumberSides)
            {
                CurrentSide = newSideUp;
            }
        }

        public string GetName() { return Name; }

        public int GetNumberSides() { return NumberSides; }

        public int GetCurrentSide() { return CurrentSide; }

    }
}

