//using Microsoft.EntityFrameworkCore;
//using SoftUni.Data;
//using SoftUni.Models;
//using System.Text;

//namespace SoftUni
//{
//    public class StartUp
//    {
//        public static void Main()
//        {
//            var context = new SoftUniContext();
//            Console.WriteLine(RemoveTown(context));
//        }

//        //15
//        public static string RemoveTown(SoftUniContext context)
//        {
//            var townToDelete = context
//                .Towns
//                .First(t => t.Name == "Seattle");

//            IQueryable<Address> addressesToDelete =
//                context
//                    .Addresses
//                    .Where(a => a.TownId == townToDelete.TownId);

//            int addressesCount = addressesToDelete.Count();

//            IQueryable<Employee> employeesOnDeletedAddresses =
//                context
//                    .Employees
//                    .Where(e => addressesToDelete.Any(a => a.AddressId == e.AddressId));

//            foreach (var employee in employeesOnDeletedAddresses)
//            {
//                employee.AddressId = null;
//            }

//            foreach (var address in addressesToDelete)
//            {
//                context.Addresses.Remove(address);
//            }

//            context.Remove(townToDelete);

//            context.SaveChanges();

//            return $"{addressesCount} addresses in Seattle were deleted";

//        }

//        //Task 15
//        //public static string RemoveTown(SoftUniContext context)
//        //{
//        //    var townToDelete = context.Towns
//        //        .FirstOrDefault(x => x.Name == "Seattle");

//        //    var emploeesFromSeattle = context.Employees
//        //        .Where(e => e.Address.TownId == townToDelete.TownId);

//        //    var emploeesFromSeattleCount = emploeesFromSeattle.Count();

//        //    foreach (var e in emploeesFromSeattle)
//        //    {
//        //        e.AddressId = null;
//        //        context.Update(e);
//        //    }

//        //    string result = $"{emploeesFromSeattleCount} addresses in Seattle were deleted";

//        //    var addressesFromSeattle = context.Addresses
//        //        .Where(afs => afs.TownId == townToDelete.TownId);

//        //    foreach (var e in addressesFromSeattle)
//        //    {
//        //        context.Addresses.Remove(e);
//        //    }

//        //    context.Towns.Remove(townToDelete);

//        //    context.SaveChanges();

//        //    return result;
//        //}

//        //Task 14
//        public static string DeleteProjectById(SoftUniContext context)
//        {
//            var emploeesProjects = context.EmployeesProjects;

//            var emploeesProjectsToRemove = context.EmployeesProjects
//                .Where(ep => ep.ProjectId == 2);

//            foreach (var ep in emploeesProjectsToRemove)
//            {
//                emploeesProjects.Remove(ep);
//            }

//            var projectToRemove = context.Projects.Find(2);

//            context.Projects.Remove(projectToRemove);

//            context.SaveChanges();

//            var newEmploeesProjects = context.EmployeesProjects
//                .Take(10)
//                .Select(ep => new
//                {
//                    ep.Project.Name
//                })
//                .ToArray();

//            StringBuilder sb = new StringBuilder();

//            foreach (var ep in newEmploeesProjects)
//            {
//                sb.AppendLine(ep.Name);
//            }

//            return sb.ToString().TrimEnd();
//        }

//        //Task 13
//        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
//        {
//            var employees = context.Employees
//                .Where(e => e.FirstName.StartsWith("Sa"))
//                .Select(e => new
//                {
//                    e.FirstName,
//                    e.LastName,
//                    e.JobTitle,
//                    e.Salary
//                })
//                .OrderBy(e => e.FirstName)
//                .ThenBy(e => e.LastName)
//                .ToArray();

//            StringBuilder sb = new StringBuilder();

//            foreach (var e in employees)
//            {
//                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
//            }

//            return sb.ToString().TrimEnd();
//        }

//        //Task 12
//        public static string IncreaseSalaries(SoftUniContext context)
//        {
//            var validDepartments = new[] { "Engineering", "Tool Design", "Marketing", "Information Services" };

//            var emploees = context.Employees
//                .Where(e => validDepartments.Contains(e.Department.Name))
//                .OrderBy(e => e.FirstName)
//                .ThenBy(e => e.LastName)
//                .ToArray();

//            foreach (var e in emploees)
//            {
//                //e.Salary = e.Salary * 1.12m;
//            }

//            context.SaveChanges();

//            StringBuilder sb = new StringBuilder();

//            foreach (var employee in emploees)
//            {
//                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
//            }

//            return sb.ToString().TrimEnd();
//        }

//        //Task 11
//        public static string GetLatestProjects(SoftUniContext context)
//        {
//            var lastProjects = context.Projects
//                .OrderByDescending(p => p.StartDate)
//                .Take(10)
//                .ToArray();

//            StringBuilder sb = new StringBuilder();

//            foreach (var proj in lastProjects.OrderBy(p => p.Name))
//            {
//                sb.AppendLine(proj.Name);
//                sb.AppendLine(proj.Description);
//                sb.AppendLine(proj.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
//            }

//            return sb.ToString().TrimEnd();
//        }

//        //Task 10
//        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
//        {
//            var departments = context.Departments
//                .Where(d => d.Employees.Count() > 5)
//                .OrderBy(d => d.Employees.Count())
//                .ThenBy(d => d.Name)
//                .Select(d => new
//                {
//                    d.Name,
//                    d.Manager.FirstName,
//                    d.Manager.LastName,
//                    DepEmploees = d.Employees
//                })
//                .ToArray();

//            StringBuilder sb = new StringBuilder();

//            foreach (var d in departments)
//            {
//                sb.AppendLine($"{d.Name} – {d.FirstName} {d.LastName}");

//                foreach (var e in d.DepEmploees.OrderBy(dp => dp.FirstName)
//                                                .ThenBy(dp => dp.LastName))
//                {
//                    sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
//                }
//            }

//            return sb.ToString().TrimEnd();
//        }

//        //Task 9
//        public static string GetEmployee147(SoftUniContext context)
//        {
//            var emploee147 = context.Employees
//                .Find(147);

//            StringBuilder sb = new StringBuilder();

//            sb.AppendLine($"{emploee147.FirstName} {emploee147.LastName} - {emploee147.JobTitle}");


//            var emploee147Projects = emploee147.EmployeesProjects;

//            foreach (var p in emploee147Projects.OrderBy(p => p.Project.Name))
//            {
//                sb.AppendLine(p.Project.Name);
//            }

//            return sb.ToString().TrimEnd();
//        }

//        //Task 8
//        public static string GetAddressesByTown(SoftUniContext context)
//        {
//            var addressesByTown = context.Addresses
//                .OrderByDescending(a => a.Employees.Count)
//                .ThenBy(a => a.Town.Name)
//                .Take(10)
//                .Select(a => new
//                {
//                    Text = a.AddressText,
//                    Town = a.Town.Name,
//                    EmployeesCount = a.Employees.Count
//                })
//                .ToArray();

//            StringBuilder sb = new StringBuilder();

//            foreach (var address in addressesByTown)
//            {
//                sb.AppendLine($"{address.Text}, {address.Town} - {address.EmployeesCount} employees");
//            }

//            return sb.ToString().TrimEnd();
//        }

//        //Task 7
//        public static string GetEmployeesInPeriod(SoftUniContext context)
//        {
//            var emploees = context.Employees
//                //.Where(e => e.EmployeesProjects
//                //    .Any(ep => ep.Project.StartDate.Year >= 2001 &&
//                //               ep.Project.StartDate.Year <= 2003))
//                .Take(10)
//                .Select(e => new
//                {
//                    e.FirstName,
//                    e.LastName,
//                    ManagerFirstName = e.Manager.FirstName,
//                    ManagerLastName = e.Manager.LastName,
//                    Projects = e.EmployeesProjects
//                    .Where(ep => ep.Project.StartDate.Year >= 2001 &&
//                                 ep.Project.StartDate.Year <= 2003)
//                        .Select(ep => new
//                        {
//                            ProjectName = ep.Project.Name,
//                            StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
//                            EndDate = ep.Project.EndDate.HasValue
//                                ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt")
//                                : "not finished"
//                        })
//                        .ToArray()
//                })
//                .ToArray();

//            StringBuilder sb = new StringBuilder();

//            foreach (var e in emploees)
//            {
//                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

//                foreach (var p in e.Projects)
//                {
//                    sb.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
//                }
//            }

//            return sb.ToString();
//        }

//        //Task 6
//        public static string AddNewAddressToEmployee(SoftUniContext context)
//        {
//            Address newAdress = new Address()
//            {
//                AddressText = "Vitoshka 15",
//                TownId = 4
//            };

//            Employee? employee = context.Employees
//                .FirstOrDefault(e => e.LastName == "Nakov");

//            employee.Address = newAdress;

//            context.SaveChanges();

//            string[] emploeesAdresses = context.Employees
//                .OrderByDescending(e => e.AddressId)
//                .Select(ea => ea.Address.AddressText)
//                .Take(10)
//                .ToArray();

//            return String.Join(Environment.NewLine, emploeesAdresses);
//        }

//        //Task 5
//        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
//        {
//            StringBuilder sb = new StringBuilder();

//            var employees = context.Employees
//                .Where(e => e.Department.Name == "Research and Development")
//                .OrderBy(e => e.Salary)
//                .ThenByDescending(e => e.FirstName)
//                .Select(e => new
//                {
//                    e.FirstName,
//                    e.LastName,
//                    DepartmentName = e.Department.Name,
//                    e.Salary
//                })
//                .ToList();

//            foreach (var e in employees)
//            {
//                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:f2}");
//            }

//            return sb.ToString().TrimEnd();

//        }

//        // Task 4
//        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
//        {
//            StringBuilder sb = new StringBuilder();

//            var employees = context.Employees
//                .Select(e => new
//                {
//                    e.FirstName,
//                    e.Salary
//                })
//                .Where(e => e.Salary > 50000)
//                .OrderBy(e => e.FirstName)
//                .ToList();

//            foreach (var employee in employees)
//            {
//                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
//            }

//            return sb.ToString().TrimEnd();
//        }

//        // Task 3
//        public static string GetEmployeesFullInformation(SoftUniContext context)
//        {
//            StringBuilder sb = new StringBuilder();

//            var employees = context.Employees
//                .OrderBy(e => e.EmployeeId)
//                .ToList();

//            foreach (var employee in employees)
//            {
//                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
//            }

//            return sb.ToString().TrimEnd();
//        }


//    }
//}
