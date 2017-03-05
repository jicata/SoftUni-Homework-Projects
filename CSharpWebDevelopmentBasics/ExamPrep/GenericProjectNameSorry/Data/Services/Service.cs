namespace SoftUniStore.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using AutoMapper;
    using Contracts;
    using Models;
    using Models.ViewModels;
    using Security;
    using SimpleHttpServer.Models;

    public class Service
    {
        protected ISoftStoreData data;
        protected SignInManager signInManager;
        public Service()
            :this(new SoftStoreData())
        {
            
        }

        public Service(ISoftStoreData data)
        {
            this.data = data;
            this.signInManager = new SignInManager(data);
        }

        public bool IsAuthenticated(HttpSession session)
        {
            return this.signInManager.IsAuthenticated(session);
        }

        public User GetUserBySession(HttpSession session)
        {
            return this.data.Logins.FindByPredicate(l => l.SessionId == session.Id && l.IsActive)?.User;
        }
       
    }
}
