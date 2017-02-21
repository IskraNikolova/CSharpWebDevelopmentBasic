using System;

namespace EncodingAndDecoding
{
    using System.Net;

    class Program
    {
        static void Main()
        {
            //Decoding
            //Console.WriteLine("Content-Type: text/html\r\n");
            //Console.WriteLine("<!DOCTYPE>\n<html>\n<head>\n    <title></title>\n</head>\n<body>\n    <form action=\"EncodingAndDecoding.exe\" method=\"GET\">\n        <input type=\"text\" name=\"nickname\">\n        <br>\n        <input type=\"submit\">\n        </form>\n</body>\n</html>");
            //var getContent = Environment.GetEnvironmentVariable("QUERY_STRING");
            //string decoded = WebUtility.UrlDecode(getContent);
            //Console.WriteLine(decoded);

            //Encoding
            string name = "Яна";
            string encoded = WebUtility.UrlEncode(name);
            Console.WriteLine(encoded);
        }
    }
}
