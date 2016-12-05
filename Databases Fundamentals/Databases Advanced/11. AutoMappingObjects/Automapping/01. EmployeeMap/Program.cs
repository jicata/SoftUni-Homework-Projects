using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.EmployeeMap
{
    using AutoMapper;
    using Models;
    using ViewModels;

    class Program
    {
        static void Main(string[] args)
        {
            LoadMaps();
            var empy = new Employee()
            {
                Adress = "Sofia",
                Birthday = DateTime.Now,
                FirstName = "Bojo",
                LastName = "Bojovski",
                Salary = 600
            };
            var dto = Mapper.Map<EmployeeDTO>(empy);
            Console.WriteLine(dto.LastName);
            Console.WriteLine(dto.FirstName);
            Console.WriteLine(dto.Salary);
        }

        public static void LoadMaps()
        {
           Mapper.Initialize(exp =>
           {
               exp.CreateMap<Employee, EmployeeDTO>();
           });
        }
    }
}
