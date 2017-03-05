using SoftUniStore.Data.Contracts;

namespace SoftUniStore.Data.Services
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Models.BIndingModels;
    using SimpleHttpServer.Models;

    public class HomeService : Service
    {
        public HomeService(ISoftStoreData data) 
            : base(data)
        {
        }


        public IEnumerable<Game> GetAllGames(HttpSession session,string query)
        {
            if (query != null)
            {
                var user = this.GetUserBySession(session);
                return
                    this.data.Games.Find(
                        g => g.Owners.Select(o => new {FullName = o.FullName}).Any(a => a.FullName == user.FullName));
            }
            else
            {
                return this.data.Games.GetAll();
            }
        }

        public Game GetGameById(int gameId)
        {
            return this.data.Games.GetById(gameId);
        }

        public void BuyGameForUser(User user, BuyGameBindingModel bgbm)
        {
            var game = this.GetGameById(bgbm.Id);
            user.Games.Add(game);
            this.data.SaveChanges();
        }
    }
}
