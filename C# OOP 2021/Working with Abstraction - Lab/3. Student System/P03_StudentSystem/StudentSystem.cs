using P03_StudentSystem.Commands;
using P03_StudentSystem.IO;
using System;
using System.Collections.Generic;

namespace P03_StudentSystem
{
    public class StudentSystem
    {
        private readonly IIoEngine ioEngine;
        private StudentsDatabase students;

        private Dictionary<string, ICommand> commands;

        public StudentSystem(IIoEngine ioEngine)
        {
            this.students = new StudentsDatabase();
            this.commands = new Dictionary<string, ICommand>();
            this.commands.Add("Create", new CreateCommand());
            this.commands.Add("Show", new ShowCommand(ioEngine));
            this.ioEngine = ioEngine;
        }

        public void ParseCommands()
        {
            while (true)
            {
                string[] studentInfo = this.ioEngine.Read().Split();
                var commandName = studentInfo[0];
                if (this.commands.ContainsKey(commandName))
                {
                    var command = commands[commandName];
                    command.Execute(studentInfo, students);
                }
                else if (commandName == "Exit")
                {
                    return;
                }
            }
        }
    }
}
