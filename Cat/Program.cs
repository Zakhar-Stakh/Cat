using System;

namespace Lab5
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Cat
    {
        public string Name { get; }

        public Gender Gender { get; }

        private double _energy;

        public double Energy
        {
            get => _energy;
            set
            {
                if (value < MinEnergy)
                {
                    throw new Exception("Not enough energy to jump");
                }
                _energy = Math.Min(value, MaxEnergy);
            }
        }

        public static readonly double MaxEnergy = 20.0;
        public static readonly double MinEnergy = 0.0;
        public static readonly double SleepEnergyGain = 10.0;
        public static readonly double JumpEnergyDrain = 0.5;

        public Cat(string name, Gender gender)
        {
            Name = name;
            Gender = gender;
            Energy = MaxEnergy; 
        }

        public void Jump()
        {
            Energy -= JumpEnergyDrain; 
        }

        public void Sleep()
        {
            Energy += SleepEnergyGain;
        }
    }

    class Program
    {
        static void Main()
        {
            Cat myCat = new Cat("Tom", Gender.Male);
            Console.WriteLine($"Name: {myCat.Name}, Gender: {myCat.Gender}, Energy: {myCat.Energy}");

            myCat.Jump();
            Console.WriteLine($"Energy after jump: {myCat.Energy}");

            myCat.Sleep();
            Console.WriteLine($"Energy after sleep: {myCat.Energy}");
        }
    }
}