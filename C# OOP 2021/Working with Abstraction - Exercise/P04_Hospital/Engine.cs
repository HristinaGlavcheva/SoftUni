using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Engine
    {
        private const int maxCapacity = 3;

        private List<Doctor> doctors;
        private List<Department> departments;

        public Engine()
        {
            this.doctors = new List<Doctor>();
            this.departments = new List<Department>();
        }
        
        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "Output")
            {
                string[] inputArgs = command.Split();

                var departmentName = inputArgs[0];
                var firstName = inputArgs[1];
                var lastName = inputArgs[2];
                var patientName = inputArgs[3];

                var fullName = firstName + lastName;

                Doctor doctor = this.doctors.FirstOrDefault(d => d.FullName == fullName);

                if(doctor == null)
                {
                    doctor = new Doctor(firstName, lastName);
                    this.doctors.Add(doctor);
                }

                Department department = this.departments.FirstOrDefault(d => d.Name == departmentName);

                if (department == null)
                {
                    department = new Department(departmentName);
                    this.departments.Add(department);
                }

                Patient patient = new Patient(patientName);

                bool availableBed = department.Rooms.Any(r => r.Count < maxCapacity);

                if (availableBed)
                {
                    doctor.AddPatient(patient);
                    AddPatientToRoom(department, patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                if (commandArgs.Length == 1)
                {
                    string departmentName = commandArgs[0];
                    Department department = this.departments.FirstOrDefault(d => d.Name == departmentName);
                    Console.WriteLine(department);
                }
                else if (commandArgs.Length == 2)
                {
                    bool isRoomNumber = int.TryParse(commandArgs[1], out int roomNumber);

                    if (isRoomNumber)
                    {
                        string departmentName = commandArgs[0];
                        Department department = this.departments.FirstOrDefault(d => d.Name == departmentName);
                        Room room = department.Rooms.FirstOrDefault(r => r.Number == roomNumber);

                        Console.WriteLine(room);
                    }
                    else
                    {
                        string doctorFullName = commandArgs[0] + commandArgs[1];
                        Doctor doctor = this.doctors.FirstOrDefault(d => d.FullName == doctorFullName);

                        Console.WriteLine(doctor);
                    }
                }
                command = Console.ReadLine();
            }
        }

        private void AddPatientToRoom(Department departament, Patient patient)
        {
            Room availableRoom = departament.Rooms.FirstOrDefault(r => r.Count < maxCapacity);
            availableRoom.AddPatient(patient);
            departament.AddPatient(patient);
        }
    }
}

