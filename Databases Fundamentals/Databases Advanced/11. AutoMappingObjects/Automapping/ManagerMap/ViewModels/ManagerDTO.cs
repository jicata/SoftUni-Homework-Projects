namespace ManagerMap.ViewModels
{
    using System.Collections.Generic;
    using System.Text;

    public class ManagerDTO
    {
        public ManagerDTO()
        {
            this.Subordinates = new HashSet<EmployeeDTO>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<EmployeeDTO> Subordinates { get; set; }

        public int CountOfEmployees { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"{FirstName} | Employees {CountOfEmployees}");
            foreach (var employeeDto in this.Subordinates)
            {
                builder.AppendLine($"{new string(' ', 6)} {employeeDto}");
            }
            return builder.ToString();
        }
    }
}
