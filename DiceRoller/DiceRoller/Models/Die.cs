using System;
namespace DiceRoller.Models
{
    public class Die
    {
        public string Name { get; set; }
        public int NumberSides { get; set; }
        public int CurrentSide { get; set; }

        public Die()
        {
            Name = "d6";
            NumberSides = 6;
            Roll();
        }

        public Die(int numberSides)
        {
            Name = "d" + numberSides;
            NumberSides = numberSides;
            Roll();
        }

        public Die(string namePrefix, int numberSides)
        {
            Name = namePrefix + numberSides;
            NumberSides = numberSides;
            Roll();
        }

        public void Roll()
        {
            Random r = new Random();
            CurrentSide = r.Next(NumberSides)+1;
        }

        public void SetSideUp(int newSideUp)
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

