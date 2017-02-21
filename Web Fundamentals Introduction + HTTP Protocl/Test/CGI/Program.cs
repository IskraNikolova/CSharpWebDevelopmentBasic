using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Content-Type: text/html\r\n");
            string[] array = new[] {"Titanik", "DeadPool", "Books"};
            Console.WriteLine("<!DOCTYPE>\n<html>\n<head>\n    <title></title>\n</head>\n<body>\n    <form action=\"CGI.exe\" method=\"GET\">\n        <input type=\"text\" name=\"search\" value=\"Search movie\">\n        <input type=\"submit\">\n        </form>\n</body>\n</html>");
            string getContent = Environment.GetEnvironmentVariable("QUERY_STRING");
            string valueForContent = getContent.Split('=')[1];
            var filtered = array.Where(s => s.Contains(valueForContent));

            foreach (var s in filtered)
            {
                Console.WriteLine($"<p>{s}</p>");
            }
        }
    }
}
