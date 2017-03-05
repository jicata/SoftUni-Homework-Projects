namespace SoftUniStore.Client.Controllers
{
    using System.Collections.Generic;
    using Data;
    using Data.Contracts;
    using Data.Services;
    using Models;
    using Models.BIndingModels;
    using Models.ViewModels;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;

    public class HomeController : Controller
    {
        private HomeService service;

        public HomeController()
            :this(new SoftStoreData())
        {
            
        }

        public HomeController(ISoftStoreData data)
        {
            this.service = new HomeService(data);
        }

        public IActionResult<GameViewModelsCollection> Index(HttpSession session, string query)
        {

            var gamesCollectionVm = new GameViewModelsCollection();
            IEnumerable<Game> allGames;
            if (!this.service.IsAuthenticated(session) && !string.IsNullOrEmpty(query))
            {
                allGames = new List<Game>();
            }
            else
            {
                gamesCollectionVm.IsLogged = this.service.IsAuthenticated(session);
                allGames = this.service.GetAllGames(session, query);
            }
          
            foreach (var game in allGames)
            {
                var gameVm = new GameViewModel()
                {
                    Title = game.Title,
                    Description = game.Description,
                    Price = game.Price.ToString(),
                    Size = game.Size,
                    Id = game.Id.ToString(),
                    ImageUrl = game.ImageUrl
                };
                gamesCollectionVm.Games.Add(gameVm);
            }

            return this.View(gamesCollectionVm);
        }

        public IActionResult<GameDetailsViewModel> Details(HttpSession session, int id)
        {
            var user = this.service.GetUserBySession(session);
            var game = this.service.GetGameById(id);

            var gameDetailsVm = new GameDetailsViewModel()
            {
                Description = game.Description,
                Id = game.Id.ToString(),
                IsUserLogged = user != null,
                Price = game.Price.ToString(),
                ReleaseDate = game.ReleaseDate.ToString(),
                Size = game.Size,
                Title = game.Title,
                TrailerUrl = game.Trailer
            };
            return this.View(gameDetailsVm);
        }

        [HttpPost]
        public IActionResult Buy(HttpSession session,HttpResponse response, BuyGameBindingModel bgbm)
        {
            if (this.service.IsAuthenticated(session))
            {
                var user = this.service.GetUserBySession(session);
                this.service.BuyGameForUser(user, bgbm);
                this.Redirect(response, "/home/index?query=owned");
                return null;
            }
          this.Redirect(response,"/users/login");
            return null;
        }
    }
}
