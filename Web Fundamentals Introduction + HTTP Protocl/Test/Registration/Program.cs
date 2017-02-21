using System;

namespace Registration
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Content-Type: text/html\r\n");
            Console.WriteLine("<!DOCTYPE>\n<html>\n<head>\n    <title></title>\n</head>\n<body>\n    <form action=\"Registration.exe\" method=\"POST\">\n        <input type=\"text\" name=\"nickname\">\n        <br>\n        <input type=\"password\" name=\"pass\">\n        <br>\n        <input type=\"submit\">\n        </form>\n</body>\n</html>");
            var postContent = Console.ReadLine();
            Console.WriteLine(postContent);
        }
    }
}
