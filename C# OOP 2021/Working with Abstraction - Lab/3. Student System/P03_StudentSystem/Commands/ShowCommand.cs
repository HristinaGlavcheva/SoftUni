using P03_StudentSystem.IO;
using System;

namespace P03_StudentSystem.Commands
{
    public class ShowCommand : ICommand
    {
        private readonly IIoEngine ioEngine;

        public ShowCommand(IIoEngine ioEngine)
        {
            this.ioEngine = ioEngine;
        }
        
        public void Execute(string[] args, StudentsDatabase database)
        {
            var name = args[1];
            var student = database.Find(name);
            if (student != null)
            {
                this.ioEngine.Write(student.ToString());
            }
        }
    }
}
