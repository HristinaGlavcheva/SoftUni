namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;
    using TeisterMask.XMLHelper;

    using Data;
    using System.Xml;
    using TeisterMask.DataProcessor.ImportDto;
    using TeisterMask.Data.Models;
    using System.Text;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using Newtonsoft.Json;
    using Microsoft.EntityFrameworkCore.Internal;
    using System.Linq;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            string rootElement = "Projects";
            StringBuilder sb = new StringBuilder();

            var projectDTOs = XMLConverter.Deserializer<ImportProjectDTO>(xmlString, rootElement);

            List<Project> validProjects = new List<Project>();

            foreach (var projectDTO in projectDTOs)
            {
                if (!IsValid(projectDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime projectOpenDate;
                bool isProjectOpenDateValid = DateTime.TryParseExact(projectDTO.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out projectOpenDate);

                if (!isProjectOpenDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? projectDueDate;

                if (string.IsNullOrEmpty(projectDTO.DueDate)) 
                {
                    projectDueDate = null;
                }
                else
                {
                    DateTime projectDueDateValue;
                    bool isProjectDueDateValid = DateTime.TryParseExact(projectDTO.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out projectDueDateValue);

                    if (!isProjectDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    projectDueDate = projectDueDateValue;

                    //try
                    //{
                    //    projectDueDate = DateTime.ParseExact(projectDTO.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    //}
                    //catch (Exception ex)
                    //{
                    //    sb.AppendLine(ErrorMessage);
                    //    continue;
                    //}
                }

                var newProject = new Project
                {
                    Name = projectDTO.Name,
                    OpenDate = projectOpenDate,
                    DueDate = projectDueDate,
                };

                foreach (var taskDTO in projectDTO.Tasks)
                {
                    if (!IsValid(taskDTO))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskOpenDate;
                    bool isTaskOpenDateValid = DateTime.TryParseExact(taskDTO.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out taskOpenDate);

                    DateTime taskDueDate;
                    bool isTaskDueDateValid = DateTime.TryParseExact(taskDTO.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDueDate);

                    if (!isTaskOpenDateValid || !isTaskDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOpenDate < projectOpenDate ||
                        (projectDueDate != null && taskDueDate > projectDueDate))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task newTask = new Task
                    {
                        Name = taskDTO.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)taskDTO.ExecutionType,
                        LabelType = (LabelType)taskDTO.LabelType
                    };

                    newProject.Tasks.Add(newTask);

                    //newProject.Tasks.Add(new Task
                    //{
                    //    Name = taskDTO.Name,
                    //    OpenDate = taskOpenDate,
                    //    DueDate = taskDueDate,
                    //    ExecutionType = (ExecutionType)taskDTO.ExecutionType,
                    //    LabelType = (LabelType)taskDTO.LabelType
                    //});
                }

                validProjects.Add(newProject);

                sb.AppendLine(string.Format(SuccessfullyImportedProject, newProject.Name, newProject.Tasks.Count));
            }

            context.Projects.AddRange(validProjects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var employeesDTOs = JsonConvert.DeserializeObject<List<ImportEmployeeDTO>>(jsonString);

            var validEmployees = new List<Employee>();

            foreach (var employeeDTO in employeesDTOs)
            {
                if (!IsValid(employeeDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //Вариант без регекс:
                //if (!IsUsernameValid(employeeDTO.Username))
                //{
                //    sb.AppendLine(ErrorMessage);
                //    continue;
                //}

                var newEmployee = new Employee
                {
                    Username = employeeDTO.Username,
                    Email = employeeDTO.Email,
                    Phone = employeeDTO.Phone
                };

                foreach (var taskId in employeeDTO.TasksIds.Distinct().ToList())
                {
                    //Task task = context.Tasks.FirstOrDefault(t => t.Id == taskId);

                    //if(task == null)
                    //{
                    //    sb.AppendLine(ErrorMessage);
                    //    continue;
                    //}

                    if (!context.Tasks.Any(t => t.Id == taskId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    newEmployee.EmployeesTasks.Add(new EmployeeTask
                    {
                        Employee = newEmployee,
                        Task = context.Tasks.First(t => t.Id == taskId)
                    });
                }

                validEmployees.Add(newEmployee);
                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, newEmployee.Username, newEmployee.EmployeesTasks.Count));
            }

            context.Employees.AddRange(validEmployees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsUsernameValid(string username)
        {
            foreach (var ch in username)
            {
                if (!char.IsLetterOrDigit(ch))
                {
                    return false;
                }
            }
            
            return true;
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}