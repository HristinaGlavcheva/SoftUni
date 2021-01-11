using EF_Introduction___Lab.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EF_Introduction___Lab
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SoftUniContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=SoftUni;Integrated Security=true");
  
            
            var db = new SoftUniContext(optionsBuilder.Options);

            Console.WriteLine(db.Employees.Count());

           
        }
    }
}
