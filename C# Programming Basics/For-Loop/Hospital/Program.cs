using System;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int doctros = 7;
            int treatedPatients = 0;
            int unTreatedPatients = 0;

            for (int i = 1; i <= days; i++)
            {
                if (i % 3 == 0)
                {
                    if (unTreatedPatients > treatedPatients)
                    {
                        doctros++;
                    }
                }

                int countPatients = int.Parse(Console.ReadLine());

                if (countPatients >= doctros)
                {
                    treatedPatients += doctros;
                    unTreatedPatients += countPatients - doctros;
                }
                else
                {
                    treatedPatients += countPatients;
                }
                
            }

            Console.WriteLine($"Treated patients: {treatedPatients}.");
            Console.WriteLine($"Untreated patients: {unTreatedPatients}.");
        }
    }
}
