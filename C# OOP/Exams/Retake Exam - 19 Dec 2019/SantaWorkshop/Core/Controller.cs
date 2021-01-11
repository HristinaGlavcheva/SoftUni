using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Repositories;
using SantaWorkshop.Repositories.Contracts;
using SantaWorkshop.Utilities.Messages;

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SantaWorkshop.Models.Workshops;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IDwarf> dwarves;
        private readonly IRepository<IPresent> presents;

        public Controller()
        {
            this.dwarves = new DwarfRepository();
            this.presents = new PresentRepository();
        }

        public string AddDwarf(string dwarfType, string dwarfName)
        {
            IDwarf dwarf = null;

            if(dwarfType == nameof(HappyDwarf))
            {
                dwarf = new HappyDwarf(dwarfName);
            }
            else if (dwarfType == nameof(SleepyDwarf))
            {
                dwarf = new SleepyDwarf(dwarfName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDwarfType);
            }

            this.dwarves.Add(dwarf);

            string result = string.Format(OutputMessages.DwarfAdded, dwarfType, dwarfName);

            return result;
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            IInstrument instrument = new Instrument(power);

            IDwarf dwarf = this.dwarves.FindByName(dwarfName);

            if(dwarf == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentDwarf);
            }

            dwarf.AddInstrument(instrument);

            string result = string.Format(OutputMessages.InstrumentAdded, power, dwarfName);

            return result;
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            IPresent present = new Present(presentName, energyRequired);

            this.presents.Add(present);

            string result = string.Format(OutputMessages.PresentAdded, presentName);

            return result;
        }

        public string CraftPresent(string presentName)
        {
            IPresent present = this.presents.FindByName(presentName);
            IDwarf dwarf = dwarves.Models
                .Where(d => d.Energy >= 50)
                .OrderByDescending(d => d.Energy)
                .FirstOrDefault(d => d.Instruments.Count > 0);

            Workshop workshop = new Workshop();

            while (dwarves.Models.Any(d => d.Energy >= 50))
            {
                if (dwarf == null)
                {
                    throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
                }

                workshop.Craft(present, dwarf);

                if (dwarf.Energy == 0)
                {
                    this.dwarves.Remove(dwarf);
                }

                if (present.IsDone())
                {
                    break;
                }

                if(!dwarf.Instruments.Any(i => i.Power > 0))
                {
                    break;
                }
            }

            string result;

            if (present.IsDone())
            {
                result = string.Format(OutputMessages.PresentIsDone, presentName);
            }
            else
            {
                result = string.Format(OutputMessages.PresentIsNotDone, presentName);
            }

            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            int countCraftedPresents = this.presents.Models.Where(p => p.IsDone()).Count();

            //int countCraftedPresents = this.presents.Models.Count(p => p.IsDone());

            sb.AppendLine($"{countCraftedPresents} presents are done!");
            sb.AppendLine("Dwarfs info:");

            foreach (var dwarf in this.dwarves.Models)
            {
                sb.AppendLine($"Name: {dwarf.Name}");
                sb.AppendLine($"Energy: {dwarf.Energy}");
                sb.AppendLine($"Instruments {dwarf.Instruments.Where(i => i.Power > 0).Count()} not broken left");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
