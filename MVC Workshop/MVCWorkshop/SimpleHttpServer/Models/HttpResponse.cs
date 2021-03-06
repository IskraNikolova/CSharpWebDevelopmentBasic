﻿// NOTE: two consequences of this simplified response model are:
//
//      (a) it's not possible to send 8-bit clean responses (like file content)
//      (b) it's 
//       must be loaded into memory in the the Content property. If you want to send large files,
//       this has to be reworked so a handler can write to the output stream instead. 

namespace SimpleHttpServer.Models
{
    using System;
    using System.Text;
    using Enums;

    public class HttpResponse
    {
        public ResponseStatusCode StatusCode { get; set; }

        public string StatusMessage
        {
            get
            {
                return Enum.GetName(enumType: typeof(ResponseStatusCode), value: this.StatusCode);
            }
        }

        public byte[] Content { get; set; }

        public Header Header { get; set; }

        public string ContentAsUTF8
        {
            set
            {
                this.Content = Encoding.UTF8.GetBytes(s: value);
            }
        }

        public HttpResponse()
        {
            this.Header = new Header(type: HeaderType.HttpResponse);
            this.Content = new byte[] { };
        }

        public override string ToString()
        {
            var statusCode = (int) this.StatusCode;
            var statusMessage = this.StatusCode;
            var header = this.Header;

            var response = $"HTTP/1.1 {statusCode} {statusMessage}\r\n{header}";

            return response;
        }
    }
}