

namespace SoftUniStore.Client
{
    using AutoMapper;
    using Models;
    using Models.BIndingModels;
    using Models.ViewModels;
    using SimpleHttpServer;
    using SimpleMVC;

    class AppStart
    {
        static void Main(string[] args)
        {
            LoadMapping();
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "SoftUniStore.Client");
        }

        public static void LoadMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UserRegisterBindingModel, User>();
                cfg.CreateMap<Game,AdminGameViewModel>();
                cfg.CreateMap<AddGameBindingModel,Game>();
                cfg.CreateMap<Game,EditGameViewModel>();
                cfg.CreateMap<Game, DeleteGameViewModel>();
            });

    }
    }
}
