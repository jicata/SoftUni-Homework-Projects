namespace SimpleHttpServer.Utilities
{
    using System.IO;
    using Models;

    public static class SessionCreator
    {
        public static HttpSession Create()
        {
            var sessionId = Path.GetRandomFileName();
            var session = new HttpSession(sessionId);
            return session;
        }
    }
}
