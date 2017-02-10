using System;

namespace BrowseCake
{
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Content-Type: text/html\r\n");
            string htmlContent = File.ReadAllText("browseCake.html");
            Console.WriteLine(htmlContent);

            string getContent = Environment.GetEnvironmentVariable("QUERY_STRING");
            string cakeName = getContent.Split('=')[1];
            string[] databaseContent = File.ReadAllLines("database.csv");
            var filtered = databaseContent.Where(s => s.Contains(cakeName));

            foreach (var cake in filtered)
            {
                Console.WriteLine(cake);
            }
        }
    }
}
