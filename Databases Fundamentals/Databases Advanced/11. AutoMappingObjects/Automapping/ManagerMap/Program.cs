namespace ManagerMap
{
    using System;
    using AutoMapper;
    using Models;
    using ViewModels;

    class Program
    {
        static void Main(string[] args)
        {
            LoadAutoMapperConfig();
            var empy = new Employee()
            {
                Adress = "Sofia",
                Birthday = DateTime.Now,
                FirstName = "Bojo",
                LastName = "Bojovski",
                Salary = 600
            };
            var empy2 = new Employee()
            {
                Adress = "Sofia",
                Birthday = DateTime.Now,
                FirstName = "Svetlio",
                LastName = "Legend",
                Salary = 600
            };
            var empy3 = new Employee()
            {
                Adress = "Sofia",
                Birthday = DateTime.Now,
                FirstName = "Kaput",
                LastName = "Kaputnikov",
                Salary = 600
            };
            var empy4 = new Employee()
            {
                Adress = "Sofia",
                Birthday = DateTime.Now,
                FirstName = "Harambe",
                LastName = "RIP",
                Salary = 600
            };
            empy2.Subordinates.Add(empy);
            empy2.Subordinates.Add(empy3);
            empy4.Subordinates.Add(empy2);
            var shef1 = Mapper.Map<ManagerDTO>(empy2);
            var shef2 = Mapper.Map<ManagerDTO>(empy4);
            Console.Write(shef1);
            Console.WriteLine();
            Console.Write(shef2);

        }

        public static void LoadAutoMapperConfig()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Employee, EmployeeDTO>();
                expression.CreateMap<Employee, ManagerDTO>()
                    .ForMember(dest => dest.CountOfEmployees, source => source.MapFrom(src => src.Subordinates.Count));
            });
        }
    }
}
