using SimpleHttpServer.Models;
using SimpleMVC.App.Data;
using SimpleMVC.App.Models;
using System;
using System.Linq;

namespace SimpleMVC.App.Security
{
    public class SessionManager
    {
        internal static HttpResponse CreateSession(HttpResponse response, string username, string password)
        {
            var sessionCookie = new Cookie("sid", new Random().Next().ToString());
            using (var context = new NotesAppContext())
            {
                var user = context.Users
                    .SingleOrDefault(u => u.Username == username && u.Password == password);
                if (user != null)
                {
                    context.Sessions.Add(new Session()
                    {
                        Id = sessionCookie.Value,
                        UserId = user.Id
                    });
                }
                context.SaveChanges();
            }
            response.Header.Cookies.Add(sessionCookie);
            return response;
        }


        public static Session GetSession(HttpRequest request)
        {
            var cookies = request.Header.Cookies;
            if (!cookies.Contains("sid"))
            {
                return null;
            }

            var sessionCookie = cookies["sid"];
            var ctx = new NotesAppContext();

            var session = ctx.Sessions
                .FirstOrDefault(s => s.Id == sessionCookie.Value);
            return session;
        }

        public static void RemoveSession(HttpRequest request)
        {
            using (var ctx = new NotesAppContext())
            {
                var session = ctx.Sessions.Find(request.Header.Cookies["sid"].Value);
                ctx.Sessions.Remove(session);
                ctx.SaveChanges();
            }
        }
    }
}
