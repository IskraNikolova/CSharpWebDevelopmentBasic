using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            double pow = 1.30;
            Console.WriteLine(pow);
            Console.WriteLine(Math.Round(pow, MidpointRounding.AwayFromZero));
        }
    }
}
