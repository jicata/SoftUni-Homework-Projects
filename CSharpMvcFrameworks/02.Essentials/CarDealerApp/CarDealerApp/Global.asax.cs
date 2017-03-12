using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CarDealerApp
{
    using AutoMapper;
    using CarDealer.Models;
    using CarDealer.Models.BindingModels;
    using CarDealer.Models.ViewModels;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            LoadMappings();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public static void LoadMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Car, CarViewModel>();
                cfg.CreateMap<Part, PartViewModel>();
                cfg.CreateMap<Customer, CustomerViewModel>()
                    .ForMember(dest => dest.BoughtCarsAmount,
                        opts => opts.MapFrom(src => src.Sales.Count))
                    .ForMember(dest => dest.TotalMoneySpent,
                        opts => opts.MapFrom(src => src.Sales.Sum(s => s.Car.Parts.Sum(p => p.Price))));

                cfg.CreateMap<Sale, SaleViewModel>()
                    .ForMember(dest => dest.CarMake,
                        opts => opts.MapFrom(src => src.Car.Make))
                    .ForMember(dest => dest.CarModel,
                        opts => opts.MapFrom(src => src.Car.Model))
                    .ForMember(dest => dest.CustomerName,
                        opts => opts.MapFrom(src => src.Customer.Name))
                    .ForMember(dest => dest.TravelledDistance,
                        opts => opts.MapFrom(src => src.Car.TravelledDistance))
                    .ForMember(dest => dest.TotalSum,
                        opts => opts.MapFrom(src => src.Car.Parts.Sum(p => p.Price)))
                    .ForMember(dest => dest.TotalSumWithDiscount,
                        opts => opts.MapFrom(src => src.Car.Parts.Sum(p=>p.Price) - (src.Discount * src.Car.Parts.Sum(p => p.Price))))
                    .ForMember(dest => dest.Discount,
                        opts => opts.MapFrom(src => src.Discount * 100));

                cfg.CreateMap<CreatePartBindingModel, Part>().ForMember(x => x.Supplier, opt => opt.Ignore());
                cfg.CreateMap<Part, PartEditViewModel>();
                cfg.CreateMap<CreateCarBindingModel, Car>().ForMember(x => x.Parts, opt => opt.Ignore());

            });

        }
    }
}
