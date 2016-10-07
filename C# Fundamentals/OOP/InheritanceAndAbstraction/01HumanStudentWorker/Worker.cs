using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01HumanStudentWorker
{
    class Worker : Human
    {
        decimal weekSalary;
        decimal workHoursPerDay;
        public Worker(string firstName, string lastName,decimal weekSalary, decimal workHoursPerDay)
            :base (firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }
        public decimal WeekSalary
        {
            get { return weekSalary; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Salary cannot be negative");
                }
                weekSalary = value; 
            }
        }
        public decimal WorkHoursPerDay
        {
            get { return workHoursPerDay; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Work hours cannot be negative");
                }
                 
                workHoursPerDay = value; 
            }
        }

        public decimal MoneyPerHour()
        {
            decimal workHoursPerWeek = workHoursPerDay * 5;
            return workHoursPerWeek / weekSalary;
        }
    }
}
