namespace SimpleHttpServer.Models
{
    using Enums;
    public class HttpRequest
    {
        public RequestMethod Method { get; set; }

        public string Url { get; set; }

        public string Content { get; set; }

        public Header Header { get; set; }

        public HttpSession Session { get; set; }

        public HttpRequest()
        {
            this.Header = new Header(HeaderType.HttpRequest);
        }

        public override string ToString()
        {
            var method = this.Method;
            var url = this.Url;
            var header = this.Header;
            var content = this.Content;

            return $"{method} {url} HTTP/1.1\r\n{header}{content}";
        }
    }
}