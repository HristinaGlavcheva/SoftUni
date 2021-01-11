using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    public class Department
    {
        public Department(string name)
        {
            this.Name = name;
            this.Patients = new List<Patient>();
            this.Rooms = new List<Room>();
            this.Capacity = 20;
        }

        public string Name { get; }

        public int Capacity { get; }

        public List<Room> Rooms { get; }

        public List<Patient> Patients { get; }


        public void SetRooms()
        {
            for (int roomNumber = 1; roomNumber <= 20; roomNumber++)
            {
                Room room = new Room(roomNumber);

                this.Rooms.Add(room);
            }
        }
    }
}
