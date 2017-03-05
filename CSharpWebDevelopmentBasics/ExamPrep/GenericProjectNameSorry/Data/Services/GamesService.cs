using SoftUniStore.Data.Contracts;

namespace SoftUniStore.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using AutoMapper;
    using Models;
    using Models.BIndingModels;
    using Models.ViewModels;
    using SimpleHttpServer.Models;

    public class GamesService : Service

    {
        public GamesService(ISoftStoreData data) : base(data)
        {
        }

        public IEnumerable<Game> GetAllGames()
        {
            return this.data.Games.GetAll();
        }
        public HashSet<AdminGameViewModel> ConvertToViewModels(IEnumerable<Game> allGames)
        {
            HashSet<AdminGameViewModel> agvms = new HashSet<AdminGameViewModel>();
            foreach (var game in allGames)
            {
                var agvm = Mapper.Map<Game, AdminGameViewModel>(game);
                agvms.Add(agvm);
            }

            return agvms;
        }

        public bool AuthenticateUser(HttpSession session)
        {
            return (base.IsAuthenticated(session) && this.IsUserAdmin(session));
        }

        private bool IsUserAdmin(HttpSession session)
        {
            return this.GetUserBySession(session).IsAdmin;
        }

        public bool VerifyGame(AddGameBindingModel agbm)
        {
            if (char.ToUpper(agbm.Title[0]) != agbm.Title[0] || (agbm.Title.Length < 3 || agbm.Title.Length > 100))
            {
                return false;
            }
            if (agbm.Price < 0 || agbm.Size < 0)
            {
                return false;
            }
            if (agbm.Trailer.Length != 11)
            {
                return false;
            }
            if (!agbm.ImageUrl.StartsWith("http://") && !agbm.ImageUrl.StartsWith("https://"))
            {
                return false;
            }
            if (agbm.Description.Length < 20)
            {
                return false;
            }
            return true;
        }

        public bool VerifyGame(EditGameBindingModel egbm)
        {
           
            if (char.ToUpper(egbm.Title[0]) != egbm.Title[0] || (egbm.Title.Length < 3 || egbm.Title.Length > 100))
            {
                return false;
            }
            if (egbm.Price < 0 || egbm.Size < 0)
            {
                return false;
            }
            if (egbm.Trailer.Length != 11)
            {
                return false;
            }
            if (!egbm.ImageUrl.StartsWith("http://") && !egbm.ImageUrl.StartsWith("https://"))
            {
                return false;
            }
            if (egbm.Description.Length < 20)
            {
                return false;
            }
            return true;
        }

        public void AddGame(AddGameBindingModel agbm)
        {
            var game = Mapper.Map<AddGameBindingModel, Game>(agbm);
            this.data.Games.InsertOrUpdate(game);
            this.data.SaveChanges();
        }
        public void AddGame(EditGameBindingModel egbm)
        {
            var game = this.data.Games.GetById(egbm.Id);

            game.Description = egbm.Description;
            game.ImageUrl = egbm.ImageUrl;
            game.Price = egbm.Price;
            game.Size = egbm.Size.ToString();
            game.Title = egbm.Title;
            game.Trailer = egbm.Trailer;

            this.data.SaveChanges();
        }

        public Game GetGameById(int id)
        {
            return this.data.Games.FindByPredicate(g => g.Id == id);
        }

        public EditGameViewModel TransformIntoEditGameViewModel(Game game)
        {
            var editGameVm = Mapper.Map<Game, EditGameViewModel>(game);
            return editGameVm;
        }

        public  DeleteGameViewModel TransformIntoGameDeleteVm(Game game)
        {
            var gameDeleteVm = Mapper.Map<Game, DeleteGameViewModel>(game);
            return gameDeleteVm;
        }

        public void DeleteGame(Game game)
        {
            this.data.Games.Delete(game);
            this.data.SaveChanges();    
        }
    }
}
