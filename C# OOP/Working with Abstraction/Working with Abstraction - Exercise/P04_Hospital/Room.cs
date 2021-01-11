using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    public class Room
    {
        public Room(int number)
        {
            this.Number = number;
            this.Capacity = 3;
            this.Patients = new List<Patient>();
            this.Count = 0;
        }
        
        public int Number { get; }

        public int Capacity { get; }

        public int Count { get; set; }

        public List<Patient> Patients { get; }
    }
}
