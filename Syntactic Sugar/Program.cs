﻿using System;
using System.Collections.Generic;

namespace Syntactic_Sugar
{
    class Program
    {
        static void Main(string[] args)
        {
            Bug One = new Bug("Lang", "Bee", new List<string>() { "Hornet, Wasp" }, new List<string>() { "Ants, Pollen" });
            One.PrintInfo();
            Console.WriteLine(One.FormalName);
            Console.WriteLine(One.PredatorList());
            Console.WriteLine(One.PreyList());
        }
    }

    public class Bug
    {
        /*
            You can declare a typed public property, make it read-only,
            and initialize it with a default value all on the same
            line of code in C#. Readonly properties can be set in the
            class' constructors, but not by external code.
        */
        public string Name { get; } = "";
        public string Species { get; } = "";
        public List<string> Predators { get; } = new List<string>();
        public List<string> Prey { get; } = new List<string>();

        // Convert this readonly property to an expression member
        //public string FormalName
        //{
        //    get
        //    {
        //        return $"{this.Name} the {this.Species}";
        //    }
        //}
        public string FormalName => $"{Name} the {Species}";

        public void PrintInfo()
        {
            Console.WriteLine($"{FormalName}");
        }

        // Class constructor
        public Bug(string name, string species, List<string> predators, List<string> prey)
        {
            this.Name = name;
            this.Species = species;
            this.Predators = predators;
            this.Prey = prey;
        }

        // Convert this method to an expression member
        //public string PreyList()
        //{
        //    var commaDelimitedPrey = string.Join(",", this.Prey);
        //    return commaDelimitedPrey;
        //}
        public string PreyList() => string.Join(",", this.Prey);

        // Convert this method to an expression member
        //public string PredatorList()
        //{
        //    var commaDelimitedPredators = string.Join(",", this.Predators);
        //    return commaDelimitedPredators;
        //}
        public string PredatorList() => string.Join(",", this.Prey);

        // Convert this to expression method
        //public string Eat(string food)
        //{
        //    if (this.Prey.Contains(food))
        //    {
        //        return $"{this.Name} ate the {food}.";
        //    }
        //    else
        //    {
        //        return $"{this.Name} is still hungry.";
        //    }
        //}

        public string Eat(string food) => this.Prey.Contains(food) ? $"{this.Name} ate the {food}." : $"{this.Name} is still hungry.";

    }

}
