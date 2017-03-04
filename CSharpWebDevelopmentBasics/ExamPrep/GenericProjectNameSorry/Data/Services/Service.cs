namespace Data.Services
{
    using Contracts;
    using Security;

    public class Service
    {
        protected IData data;
        protected SignInManager signInManager;

        public Service()
            :this(new Data())
        {
            
        }

        public Service(IData data)
        {
            this.data = data;
            this.signInManager = new SignInManager(data);
        }

        public bool IsAuthenticated(HttpSession session)
        {
            return this.signInManager.IsAuthenticated(session);
        }

    }
}
