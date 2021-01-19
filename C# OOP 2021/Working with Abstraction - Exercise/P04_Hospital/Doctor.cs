using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Doctor
    {
        private readonly List<Patient> patients;

        public Doctor(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;

            this.patients = new List<Patient>();
        }

        public string FirstName { get; }

        public string LastName { get; }

        public string FullName =>
            FirstName + LastName;

        public IReadOnlyCollection<Patient> Patients =>
            this.patients;

        public void AddPatient(Patient patient)
        {
            if (!this.Patients.Any(p => p.Name == patient.Name))
            {
                this.patients.Add(patient);
            }
        }

        public override string ToString()
        {
            var allDoctorsPatients = this.Patients.Select(p => p.Name).OrderBy(n => n);

            return string.Join(Environment.NewLine, allDoctorsPatients);
        }
    }
}


