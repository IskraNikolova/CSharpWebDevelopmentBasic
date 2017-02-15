namespace SimpleHttpServer.Models
{
    using System;
    using System.Text;
    using Enums;

    public class HttpResponse
    {
        public HttpResponse()
        {
            this.Header = new Header(HeaderType.HttpResponse);
            this.Content = new byte[] { };
        }

        public ResponseStatusCode StatusCode { get; set; }

        public string StatusMessage
        {
            get
            {
                return Enum.GetName(typeof(ResponseStatusCode), this.StatusCode);
            }
        }

        public Header Header { get; set; }

        public byte[] Content { get; set; }

        public string ContentAsUTF8
        {
            set
            {
                this.Content = Encoding.UTF8.GetBytes(value);
            }
        }

        public override string ToString()
        {
            StringBuilder httpResponse = new StringBuilder();
            httpResponse.AppendLine($"HTTP/1.0 {(int)this.StatusCode} {this.StatusMessage}");
            httpResponse.AppendLine(this.Header.ToString());

            return httpResponse.ToString();
        }
    }
}
