using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;
        private List<IDye> dies;

        public Bunny(string name, int energy)
        {
            Name = name;
            Energy = energy;
            dies = new List<IDye>();
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }

                name = value;
            }
        }

        public int Energy 
        { 
            get => energy; 
            
            protected set
            {
                if (energy < 0)
                {
                    energy = 0;
                }

                energy = value;
            } 
        }

        public ICollection<IDye> Dyes => dies;

        public void AddDye(IDye dye) 
            => dies.Add(dye);

        public virtual void Work() 
            => Energy -= 10;
    }
}
