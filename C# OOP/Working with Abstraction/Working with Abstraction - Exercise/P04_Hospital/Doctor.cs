using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    public class Doctor
    {
        public Doctor(string fullName)
        {
            this.FullName = fullName;
            this.Patients = new List<Patient>();
        }
        
        public string FullName { get; set; }

        public List<Patient> Patients { get; }
    }
}
