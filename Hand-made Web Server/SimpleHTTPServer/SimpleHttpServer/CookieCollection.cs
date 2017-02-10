namespace SimpleHttpServer
{
    using System;
    using System.CodeDom;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    public class CookieCollection : IEnumerable<Cookie>
    {
        public CookieCollection()
        {
            this.Cookies = new Dictionary<string, Cookie>();
        }

        public Dictionary<string, Cookie> Cookies { get; private set; }

        public int Count { get { return this.Cookies.Count; } }

        public bool Contains(string cookieName)
        {
            return this.Cookies.ContainsKey(cookieName);
        }

        public void Add(Cookie cookie)
        {
            this.Cookies.Add(cookie.Name, cookie);
        }

        public IEnumerator<Cookie> GetEnumerator()
        {
            return this.Cookies.Values.GetEnumerator();
        }

        public Cookie this[string cookieName]
        {
            get { return this.Cookies[cookieName]; }
            set {
                if (this.Cookies.ContainsKey(cookieName))
                {
                    this.Cookies[cookieName] = value;
                }
                else
                {
                    this.Cookies.Add(cookieName, value);
                    this.Cookies.Add(cookieName, value);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            return String.Join("; ", this.Cookies.Values);
        }
    }
}
