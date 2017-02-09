using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicHttpServer.Models
{
    using System.Collections;
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

        public int Count
        {
            get { return this.cookieCollection.Count; }
        }

        public Cookie this[string key]
        {
            get
            {
                if (!this.ContainsKey(key))
                {
                    throw new KeyNotFoundException($"No such key for cookie: {key}");
                }
                return this.cookieCollection[key];
            }
            set { this.cookieCollection[key] = value; }
        }

        public IEnumerator<Cookie> GetEnumerator()
        {
            return this.cookieCollection.Values.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join("; ", this.cookieCollection.Values);
        }
    }
}
