namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var projects = new List<Project>();

            var deserialized = XmlConverter.Deserializer<ProjectImportModel>(xmlString, "Projects");

            foreach (var currentProject in deserialized)
            {
                if (!IsValid(currentProject))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isValidProjectOpenDate = DateTime.TryParseExact(currentProject.OpenDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime projectOpenDate);

                var isValidProjectDueDate = DateTime.TryParseExact(currentProject.DueDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime projectDueDate);

                var project = new Project
                {
                    Name = currentProject.Name,
                    OpenDate = projectOpenDate,
                    DueDate = projectDueDate
                };

                foreach (var currentTask in currentProject.Tasks)
                {
                    if (!IsValid(currentTask))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var isValidTaskOpenDate = DateTime.TryParseExact(currentTask.OpenDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime taskOpenDate);

                    var isValidTaskDueDate = DateTime.TryParseExact(currentTask.DueDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime taskDueDate);

                    if (!isValidTaskOpenDate || !isValidTaskDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOpenDate < projectOpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (projectDueDate.Year > 0001 && taskDueDate > projectDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var task = new Task
                    {
                        Name = currentTask.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = Enum.Parse<ExecutionType>(currentTask.ExecutionType),
                        LabelType = Enum.Parse<LabelType>(currentTask.LabelType)
                    };

                    project.Tasks.Add(task);
                }

                projects.Add(project);
                sb.AppendLine(String.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count()));
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var employees = new List<Employee>();

            var deserialized = JsonConvert.DeserializeObject<IEnumerable<EmployeeImportModel>>(jsonString);

            foreach (var currentEmployee in deserialized)
            {
                if (!IsValid(currentEmployee))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee
                {
                    Username = currentEmployee.Username,
                    Email = currentEmployee.Email,
                    Phone = currentEmployee.Phone
                };

                foreach (var currentTaskId in currentEmployee.Tasks.Distinct())
                {
                    var targetTask = context.Tasks.FirstOrDefault(x => x.Id == currentTaskId);
                    var taskIds = employee.EmployeesTasks.Select(x => x.TaskId);

                    if (targetTask is null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!taskIds.Contains(currentTaskId))
                    {
                        employee.EmployeesTasks.Add(new EmployeeTask
                        {
                            TaskId = currentTaskId,
                            EmployeeId = employee.Id
                        });
                    }
                }

                employees.Add(employee);

                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count()));
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}