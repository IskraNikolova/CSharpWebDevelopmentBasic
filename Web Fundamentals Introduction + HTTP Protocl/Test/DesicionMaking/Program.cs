using System;

namespace DesicionMaking
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Content-Type: text/html\r\n");
            Console.WriteLine("<!DOCTYPE>\n<html>\n<head>\n    <title></title>\n</head>\n<body>\n    <form action=\"DesicionMaking.exe\" method=\"POST\">\n        <input type=\"text\" name=\"nickname\">\n        <br>\n        <input type=\"submit\">\n        </form>\n</body>\n</html>");
            string method = Environment.GetEnvironmentVariable("REQUEST_METHOD");
            Console.WriteLine(method);
        }
    }
}
