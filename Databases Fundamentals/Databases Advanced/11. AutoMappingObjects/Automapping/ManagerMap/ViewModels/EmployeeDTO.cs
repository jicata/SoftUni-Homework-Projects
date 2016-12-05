namespace ManagerMap.ViewModels
{
    public class EmployeeDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"- {FirstName} {Salary}";
        }
    }
}
