namespace PizzaMore.Utility
{
    using System.Collections;
    using System.Collections.Generic;
    using Contracts;
    public class CookieCollection : ICookieCollection
    {
        private IDictionary<string, Cookie> cookieCollection;

        public CookieCollection()
        {
            this.cookieCollection = new Dictionary<string, Cookie>();
        }

        public void AddCookie(Cookie cookie)
        {
            if (!this.ContainsKey(cookie.Name))
            {
                this.cookieCollection.Add(cookie.Name, cookie);
            }
            else
            {
                this.cookieCollection[cookie.Name] = cookie;
            }          
        }

        public void RemoveCookie(string cookieName)
        {
            if (!this.ContainsKey(cookieName))
            {
                Logger.Log("Cookie doesn't exist!");
                throw new KeyNotFoundException("Cookie doesn't exist!");
            }
            this.cookieCollection.Remove(cookieName);
        }

        public bool ContainsKey(string key)
        {
            if (this.cookieCollection.ContainsKey(key))
            {
                return true;
            }
            return false;
        }

        public int Count {get { return this.cookieCollection.Count; } }

        public Cookie this[string key]
        {
            get
            {
                if (!this.ContainsKey(key))
                {
                    Logger.Log("No such key for cookie");
                    throw new KeyNotFoundException($"No such key for cookie: {key}");
                }
                return this.cookieCollection[key];
            }
            set { this.cookieCollection[key] = value; }
        }

        public IEnumerator GetEnumerator()
        {
            return this.cookieCollection.GetEnumerator();
        }
    }
}
