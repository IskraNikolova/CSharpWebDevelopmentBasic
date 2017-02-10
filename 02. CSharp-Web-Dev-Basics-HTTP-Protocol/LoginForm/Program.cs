using System;

namespace LoginForm
{
    using System.IO;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Content-Type: text/html\r\n");
            string htmlContent = File.ReadAllText("loginForm.html");
            Console.WriteLine(htmlContent);
            string[] dataContent = Console.ReadLine().Split('&');
            string username = dataContent[0].Split('=')[1];
            string pass = dataContent[1].Split('=')[1];
            Console.WriteLine($"Hi {username}, your password is {pass}");
        }
    }
}
