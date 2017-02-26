namespace SimpleHttpServer.Models
{
    using System.Collections.Generic;
    using System.Text;
    using Enums;

    public class Header
    {
        public Header(HeaderType type)
        {
            this.Type = type;
            this.ContentType = "text/html";
            this.Cookies = new CookieCollection();
            this.OtherParameters = new Dictionary<string, string>();
        }

        public HeaderType Type { get; set; }

        public string ContentType { get; set; }

        public string Location { get; set; }

        public string ContentLength { get; set; }

        public Dictionary<string, string> OtherParameters { get; set; }

        public CookieCollection Cookies { get; private set; }

        public void AddCookie(Cookie cookie)
        {
            this.Cookies.Add(cookie: cookie);
        }

        public override string ToString()
        {
            StringBuilder header = new StringBuilder();
            header.AppendLine(value: "Content-type: " + this.ContentType);
            if (this.Location != null)
            {
                header.AppendLine(value: "Location: " + this.Location);
            }
            
            if (this.Cookies.Count > 0)
            {
                if (this.Type == HeaderType.HttpRequest)
                {
                    header.AppendLine(value: "Cookie: " + this.Cookies.ToString());
                }
                else if (this.Type == HeaderType.HttpResponse)
                {
                    foreach (var cookie in this.Cookies)
                    {
                        header.AppendLine(value: "Set-Cookie: " + cookie);
                    }
                }
            }

            if (this.ContentLength != null)
            {
                header.AppendLine(value: "Content-Length: " + this.ContentLength);
            }

            foreach (var other in this.OtherParameters)
            {
                header.AppendLine(value: $"{other.Key}: {other.Value}");
            }
            header.AppendLine();

            return header.ToString();
        }
    }
}