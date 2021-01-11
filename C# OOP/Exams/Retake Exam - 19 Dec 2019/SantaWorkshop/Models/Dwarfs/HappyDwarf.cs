using System;
namespace SantaWorkshop.Models.Dwarfs
{
    public class HappyDwarf : Dwarf
    {
        private const int HappyDwarfIntialEnergy = 100;

        public HappyDwarf(string name) 
            : base(name, HappyDwarfIntialEnergy)
        {
        }
    }
}
