using System;
using System.Collections.Generic;
using System.Linq;
using Capitalism.Contracts;
using Capitalism.Models;
using Capitalism.Models.Employees;


namespace Capitalism.Engine
{
    public class CommandExecutioner : ICommandExecutioner
    {
        public IEngine Engine { get; }

        public CommandExecutioner(IEngine engine)
        {
            this.Engine = engine;
        }
        public void ExecuteCommand(string[] command)
        {
            string commandIdentifier = command[0];
            switch (commandIdentifier)
            {
                case "create-company":
                    ExecuteCreateCompanyCommand(command.Skip(1).ToArray());
                    break;
                case "create-employee":
                    ExecuteCreateEmployeeCommand(command.Skip(1).ToArray());
                    break;
                case "create-department":
                    ExecuteCreateDepartmentCommand(command.Skip(1).ToArray());
                    break;
                case "pay-salaries":
                    ExecutePayCommand(command.Skip(1).ToArray());
                    break;
                case "show-employees":
                    ExecuteShowCommand(command.Skip(1).ToArray());
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;

            }
        }
        //TODO fucking srs validation required
        private void ExecuteCreateCompanyCommand(string[] commandArgs)
        {
            
            string companyName = commandArgs[0];
            string ceoFirstName = commandArgs[1];
            string ceoLastName = commandArgs[2];
            decimal ceoSalary = decimal.Parse(commandArgs[3]);
            this.Engine.Companies.Add(new Company(companyName, new CEO(ceoFirstName, ceoLastName, ceoSalary)));
            string message = String.Format("Company {0} has been created with {1} {2} (Salary: {3}) as its CEO ",
                companyName, ceoFirstName, ceoLastName, ceoSalary);
            this.Engine.CommandHandler.Writer.Write(message);
        }

        private void ExecuteCreateDepartmentCommand(string[] commandArgs)
        {
            //create-department C Root2
            //create - department C Sub1-1 Root1
            string companyName = commandArgs[0];
            string departmentName = commandArgs[1];
            string managerFirstName = commandArgs[2];
            string managerLastName = commandArgs[3];

            var company = Engine.Companies.FirstOrDefault(c => c.Name == companyName);

            var manager =
                company.CompanyEmployees.FirstOrDefault(
                    m => m.FirstName == managerFirstName && m.LastName == managerLastName && (m is Manager));

            if (commandArgs.Length == 4)
            {
                company.Departments.Add(new Department(departmentName, (manager as Manager)));
            }
            else if (commandArgs.Length > 5)
            {
                string mainDepartmentName = commandArgs[2];
                var mainDepartment = company.Departments.FirstOrDefault(d => d.Name == mainDepartmentName);
                mainDepartment.SubDepartments.Add(new Department(departmentName, (manager as Manager)));
            }
            string message = String.Format("Department {0} has been created in company {1} with manager {2} {3}",
                departmentName, companyName, manager.FirstName, manager.LastName);
            this.Engine.CommandHandler.Writer.Write(message);

        }

        private void ExecuteCreateEmployeeCommand(string[] commandArgs)
        {
            //Nikolay Stoichov Manager C (no dep)
            //Pesho Stoichov Regular C Root1 (yes dep)
            string employeeFirstName = commandArgs[0];
            string employeeLastName = commandArgs[1];
            string employeePosition = commandArgs[2];
            string companyName = commandArgs[3];
            var company = Engine.Companies.FirstOrDefault(c => c.Name == companyName);
            if (commandArgs.Length == 4)
            {
               
                switch (employeePosition)
                {
                    case "Manager": company.CompanyEmployees.Add(new Manager(employeeFirstName, employeeLastName,1m));
                        break;
                    case "Regular": company.CompanyEmployees.Add(new RegularEmployee(employeeFirstName, employeeLastName,0m));
                        break;
                    case "CleaningLady": company.CompanyEmployees.Add(new CleaningLady(employeeFirstName, employeeLastName, 0m));
                        break;
                    case "ChiefTelephoneOfficer": company.CompanyEmployees.Add(new ChiefTelephoneOfficer(employeeFirstName, employeeLastName, 0m));
                        break;
                    case "Accountant": company.CompanyEmployees.Add(new Accountant(employeeFirstName, employeeLastName,0m));
                        break;
                    case "Salesman": company.CompanyEmployees.Add(new Salesman(employeeFirstName, employeeLastName, 0m));
                        break;
                }
            }
            else if (commandArgs.Length == 5)
            {
                string departmentName = commandArgs[4];
                var department = company.Departments.FirstOrDefault(d => d.Name == departmentName);
                switch (employeePosition)
                {
                    case "Manager":
                        company.CompanyEmployees.Add(new Manager(employeeFirstName, employeeLastName, 1m, department));
                        break;
                    case "Regular":
                        company.CompanyEmployees.Add(new RegularEmployee(employeeFirstName, employeeLastName, 0m, department));
                        break;
                    case "CleaningLady":
                        company.CompanyEmployees.Add(new CleaningLady(employeeFirstName, employeeLastName, 0m, department));
                        break;
                    case "ChiefTelephoneOfficer":
                        company.CompanyEmployees.Add(new ChiefTelephoneOfficer(employeeFirstName, employeeLastName, 0m, department));
                        break;
                    case "Accountant":
                        company.CompanyEmployees.Add(new Accountant(employeeFirstName, employeeLastName, 0m, department));
                        break;
                    case "Salesman":
                        company.CompanyEmployees.Add(new Salesman(employeeFirstName, employeeLastName, 0m, department));
                        break;
                }
            }
            string message = string.Format("Employee {0} {1} has been created in {2}", employeeFirstName,
                employeeLastName, company.Name);
            this.Engine.CommandHandler.Writer.Write(message);
        }

        private void ExecuteShowCommand(string[] commandArgs)
        {
            var company = Engine.Companies.FirstOrDefault(c => c.Name == commandArgs[0]);
            string companyName = string.Format("({0})",commandArgs[0]);

            string info = companyName;
            info += RecursivelyGetEmAll(company);
        }

        

        private void ExecutePayCommand(string[] commandArgs)
        {
            throw new NotImplementedException();
        }

        
    }
}
