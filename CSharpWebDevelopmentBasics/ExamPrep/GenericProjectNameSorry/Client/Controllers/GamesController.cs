namespace SoftUniStore.Client.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;
    using Data;
    using Data.Contracts;
    using Data.Services;
    using Models.BIndingModels;
    using Models.ViewModels;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;

    public class GamesController : Controller
    {
        private GamesService service;

        public GamesController()
            :this(new SoftStoreData())
        {
            
        }

        public GamesController(ISoftStoreData data)
        {
            this.service = new GamesService(data);
        }

        public IActionResult<HashSet<AdminGameViewModel>> All(HttpResponse response, HttpSession session)
        {
            if (!this.service.AuthenticateUser(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }
            var allGames = this.service.GetAllGames();
            HashSet<AdminGameViewModel> agvms = this.service.ConvertToViewModels(allGames);
            return this.View(agvms);
        }


        public IActionResult Add(HttpResponse response, HttpSession session)
        {
            if (!this.service.AuthenticateUser(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(HttpSession session, HttpResponse response, AddGameBindingModel agbm)
        {
            if (!this.service.AuthenticateUser(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }
            if (this.service.VerifyGame(agbm))
            {
                this.service.AddGame(agbm);
                this.Redirect(response,"/games/all");
                return null;
            }
            this.Redirect(response,"/games/add");
            return null;

        }

        public IActionResult<EditGameViewModel> Edit(HttpResponse response, HttpSession session, int id)
        {
            if (!this.service.AuthenticateUser(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            var game = this.service.GetGameById(id);
            var editGameViewModel = this.service.TransformIntoEditGameViewModel(game);         
            
            return this.View(editGameViewModel);
        }

        [HttpPost]
        public IActionResult Edit(HttpSession session, HttpResponse response, EditGameBindingModel egbm)
        {
            if (!this.service.AuthenticateUser(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }
            if (this.service.VerifyGame(egbm))
            {
                this.service.AddGame(egbm);
                this.Redirect(response, "/games/all");
                return null;
            }
            this.Redirect(response,$"games/edit?id={egbm.Id}");
            return null;
        }

        public IActionResult<DeleteGameViewModel> Delete(HttpSession session, HttpResponse response, int id)
        {
            if (!this.service.AuthenticateUser(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }
            var game = this.service.GetGameById(id);
            var dgvm = this.service.TransformIntoGameDeleteVm(game);
            return this.View(dgvm);
        }


        [HttpPost]
        public IActionResult Delete(HttpSession session, HttpResponse response, DeleteGameBindingModel dgbm)
        {
            var game = this.service.GetGameById(dgbm.Id);
            this.service.DeleteGame(game);
            this.Redirect(response,"/games/all");
            return null;
        }
    }
}
