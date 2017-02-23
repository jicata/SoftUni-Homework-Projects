namespace Shouter.Data.Repositories
{
    using System.Linq;
    using Contracts;
    using Models;
    public class LoginRepository : Repository<Login>
    {
        public LoginRepository(IShouterContext context) 
            : base(context)
        {
        }

        public void CreateLogin(string sessionId, User user)
        {
            if (!this.EntityTable.Any(l => l.SessionId == sessionId && l.User.Username == user.Username))
            {
                var login = new Login()
                {
                    IsActive = true,
                    SessionId = sessionId,
                    User = user
                };
                this.Insert(login);                
            }           
        }

        public User FindUserByLogin(string sessionId)
        {
            return this.EntityTable.FirstOrDefault(l => l.SessionId == sessionId).User;
        }
    }
}
