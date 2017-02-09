namespace BasicHttpServer.Models.Contracts
{
    using System.Collections.Generic;

    public interface ICookieCollection : IEnumerable<Cookie>
    {
        void AddCookie(Cookie cookie);

        void RemoveCookie(string cookieName);

        bool ContainsKey(string key);

        int Count { get; }

        Cookie this[string key] { get; set; }
    }
}
