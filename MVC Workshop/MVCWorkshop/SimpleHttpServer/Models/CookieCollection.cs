namespace SimpleHttpServer.Models
{
    using System.Collections;
    using System.Collections.Generic;

    public class CookieCollection : IEnumerable<Cookie>
    {
        public CookieCollection()
        {
            this.Cookies = new Dictionary<string, Cookie>();
        }

        public IDictionary<string, Cookie> Cookies { get; private set; }

        public Cookie this[string cookieName]
        {
            get
            {
                return this.Cookies[key: cookieName];
            }
            set
            {
                this.Add(cookie: value);
            }
        }

        public int Count => this.Cookies.Count;

        public bool Contains(string cookieName)
        {
            return this.Cookies.ContainsKey(key: cookieName);
        }

        public void Add(Cookie cookie)
        {
            if (!this.Cookies.ContainsKey(key: cookie.Name))
            {
                this.Cookies.Add(key: cookie.Name, value: new Cookie());
            }

            this.Cookies[key: cookie.Name] = cookie;
        }

        public IEnumerator<Cookie> GetEnumerator()
        {
            return this.Cookies.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join(separator: "; ", values: this.Cookies.Values);
        }
    }
}