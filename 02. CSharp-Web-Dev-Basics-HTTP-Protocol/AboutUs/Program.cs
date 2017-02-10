using System;

namespace AboutUs
{
    using System.IO;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Content-Type: text/html\r\n");
            string htmlContent = File.ReadAllText("aboutUs.html");
            Console.WriteLine(htmlContent);
        }
    }
}
