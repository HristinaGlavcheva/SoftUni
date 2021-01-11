using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Utilities.Messages;

using System;
using System.Collections.Generic;

namespace SantaWorkshop.Models.Dwarfs
{
    public abstract class Dwarf : IDwarf
    {
        private const int EnergyDecreasement = 10;
        
        private string name;
        private int energy;
        private readonly List<IInstrument> instruments;

        public Dwarf(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;

            this.instruments = new List<IInstrument>();
        }

        public string Name
        {
            get { return this.name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDwarfName);
                }

                this.name = value;
            }
        }

        public int Energy
        {
            get { return this.energy; }

            protected set
            {
                if(value < 0)
                {
                    value = 0;
                }
                
                this.energy = value;
            }
        }

        public ICollection<IInstrument> Instruments
            => this.instruments.AsReadOnly();


        public void AddInstrument(IInstrument instrument)
        {
            this.instruments.Add(instrument);
        }

        public virtual void Work()
        {
            this.Energy -= EnergyDecreasement;

            if(this.Energy < 0)
            {
                this.Energy = 0;
            }
        }
    }
}
