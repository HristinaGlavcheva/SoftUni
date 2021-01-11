using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;

using System.Linq;

namespace SantaWorkshop.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {
        }

        public void Craft(IPresent present, IDwarf dwarf)
        {
            while(dwarf.Instruments.Any(i => i.Power > 0) && dwarf.Energy > 0)
            {
                IInstrument instrument = dwarf.Instruments.FirstOrDefault(i => i.Power > 0);

                while (!present.IsDone()) // && dwarf.Energy > 0 && !instrument.IsBroken())
                {
                    dwarf.Work();
                    present.GetCrafted();
                    instrument.Use();

                    if (instrument.IsBroken())
                    {
                        dwarf.Instruments.Remove(instrument);
                        instrument = dwarf.Instruments.FirstOrDefault(i => i.Power > 0);

                        if(instrument == null)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
