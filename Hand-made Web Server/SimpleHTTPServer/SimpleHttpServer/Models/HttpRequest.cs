﻿namespace SimpleHttpServer.Models
{
    using System.Text;
    using Enums;

    public class HttpRequest
    {
        public HttpRequest()
        {
            this.Header = new Header(HeaderType.HttpRequest);
        }

        public RequestMethod Method { get; set; }

        public string Url { get; set; }

        public Header Header { get; set; }

        public string Content { get; set; }

        public override string ToString()
        {
            StringBuilder httpRequest = new StringBuilder();
            httpRequest.AppendLine($"{this.Method} {this.Url} HTTP/1.0");
            httpRequest.AppendLine(this.Header.ToString());
            if (this.Content != null)
            {
                httpRequest.Append(this.Content);
            }

            return httpRequest.ToString();
        }
    }
}
