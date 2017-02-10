using System;
using System.IO;

namespace ByTheCake
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Content-Type: text/html\r\n");
            string htmlContent = File.ReadAllText("index.html");
            Console.WriteLine(htmlContent);
        }
    }
}
