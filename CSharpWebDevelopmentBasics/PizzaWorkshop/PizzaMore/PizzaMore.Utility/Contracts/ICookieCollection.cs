namespace PizzaMore.Utility.Contracts
{
    using System.Collections;
    public interface ICookieCollection:IEnumerable
    {
        void AddCookie(Cookie cookie);

        void RemoveCookie(string cookieName);

        bool ContainsKey(string key);

        int Count { get; }

        Cookie this[string key] { get; set; }
    }
}
