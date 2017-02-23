using SimpleHttpServer.Models;
using System;

namespace SimpleHttpServer.Utilities
{
    public static class SessionCreator
    {
        public static HttpSession Create()
        {
            var sessionId = new Random().Next().ToString();
            var session = new HttpSession(sessionId);
            return session;
        }
    }
}
