using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Elf elf = new Elf("Elfie", 12);
            Console.WriteLine(elf);

            MuseElf museElf = new MuseElf("Zaio", 5);
            Console.WriteLine(museElf);

            SoulMaster soulMaster = new SoulMaster("Wizzie", 25);
            Console.WriteLine(soulMaster);
        }
    }
}