using System;
namespace AddCake
{
    using System.IO;
    using System.Net;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Content-Type: text/html\r\n");
            string htmlContent = File.ReadAllText("addCake.html");
            Console.WriteLine(htmlContent);
            var getContent = Console.ReadLine();
            var variables = getContent.Split('&');
            var cakeName = variables[0].Split('=')[1];            
            var cakePrice = variables[1].Split('=')[1];    
            
            File.AppendAllText("database.csv", $"{cakeName},{cakePrice}{Environment.NewLine}");        
        }
    }
}
