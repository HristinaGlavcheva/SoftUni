using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Room
    {
        private const int maxCapacity = 3;

        private readonly List<Patient> patients;

        public Room(byte number)
        {
            this.Number = number;

            this.patients = new List<Patient>();
        }

        public byte Number { get; }

        public int Count =>
            this.Patients.Count;

        public IReadOnlyCollection<Patient> Patients => 
            this.patients;

        public void AddPatient(Patient patient)
        {
            if(this.Count < maxCapacity)
            {
                this.patients.Add(patient);
            }
        }

        public override string ToString()
        {
            var allPatientsInRoom = this.Patients.Select(p => p.Name).OrderBy(n => n);

            return string.Join(Environment.NewLine, allPatientsInRoom);
        }
    }
}

