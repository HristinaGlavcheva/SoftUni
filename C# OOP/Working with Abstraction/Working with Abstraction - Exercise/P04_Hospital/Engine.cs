using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Engine
    {
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

                string departmentName = inputArgs[0];
                string doctorFirstName = inputArgs[1];
                string doctorSurname = inputArgs[2];
                string pactient = inputArgs[3];

                string doctorFullName = doctorFirstName + doctorSurname;

                if (!doctors.Any(d => d.FullName == doctorFullName))
                {
                    Doctor doctor = new Doctor(doctorFullName);
                    doctors.Add(doctor);
                }

                if (!departments.Any(d => d.Name == departmentName))
                {
                    Department department = new Department(departmentName);
                    departments.Add(department);

                    department.SetRooms();
                }

                Department currentDepartment = departments.First(d => d.Name == departmentName);
                Doctor currentDoctor = doctors.First(d => d.FullName == doctorFullName);

                bool thereIsAvailableBed = currentDepartment.Patients.Count < 60;
                    
                if (thereIsAvailableBed)
                {
                    AddPatient(pactient, currentDepartment, currentDoctor);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (args.Length == 1)
                {
                    string departmentName = args[0];

                    Department departmentToPrint = departments.First(d => d.Name == departmentName);

                    Console.WriteLine(string.Join(Environment.NewLine, departmentToPrint.Patients.Select(p => p.Name)));
                }
                else if (args.Length == 2)
                {
                    bool isRoom = int.TryParse(args[1], out int roomNumber);

                    if (isRoom)
                    {
                        string departmentToPrint = args[0];

                        Room roomToPrint = departments.First(d => d.Name == departmentToPrint).Rooms.First(r => r.Number == roomNumber); 

                        Console.WriteLine(string.Join(Environment.NewLine, roomToPrint.Patients.Select(p => p.Name).OrderBy(n => n)));
                    }
                    else
                    {
                        string doctorName = args[0] + args[1];

                        Doctor doctorToPrint = doctors.First(d => d.FullName == doctorName);

                        Console.WriteLine(string.Join(Environment.NewLine, doctorToPrint.Patients.Select(p => p.Name).OrderBy(n => n)));
                    }
                }
                command = Console.ReadLine();
            }
        }

        private static void AddPatient(string pactient, Department currentDepartment, Doctor currentDoctor)
        {
            Patient currentPatient = new Patient(pactient);
            currentDoctor.Patients.Add(currentPatient);

            for (int room = 1; room <= currentDepartment.Capacity; room++)
            {
                Room currentRoom = currentDepartment.Rooms.First(r => r.Number == room);

                if (currentRoom.Count < 3)
                {
                    currentRoom.Count++;
                    currentDepartment.Patients.Add(currentPatient);
                    currentRoom.Patients.Add(currentPatient);
                    break;
                }
            }
        }
    }
}
