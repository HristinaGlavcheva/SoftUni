using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Department
    {
        private const int maxCapacity = 60;

        private readonly List<Patient> patients;
        private readonly List<Room> rooms;

        public Department(string name)
        {
            this.Name = name;
            
            this.rooms = new List<Room>();
            this.patients = new List<Patient>();

            this.InitializeRooms();
        }

        public string Name { get; }

        public IReadOnlyCollection<Room> Rooms => 
            this.rooms;

        public IReadOnlyCollection<Patient> Patients =>
            this.patients;

        private void InitializeRooms()
        {
            for (byte roomNumber = 1; roomNumber <= 20; roomNumber++)
            {
                Room room = new Room(roomNumber);
                this.rooms.Add(room);
            }
        }

        public void AddPatient(Patient patient)
        {
            if (this.Patients.Count < maxCapacity)
            {
                this.patients.Add(patient);
            }
        }

        public override string ToString()
        {
            var allPatientsInDepartment = this.Patients.Select(p => p.Name);

            return string.Join(Environment.NewLine, allPatientsInDepartment);
        }
    }
}

