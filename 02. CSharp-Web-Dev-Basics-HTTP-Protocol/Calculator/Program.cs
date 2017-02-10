using System;

namespace Calculator
{
    using System.IO;
    using System.Net;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Content-Type: text/html\r\n");
            string htmlContent = File.ReadAllText("calculator.html");
            Console.WriteLine(htmlContent);
            string[] dataResult = Console.ReadLine().Split('&');
            try
            {
                double firstNumber = double.Parse(dataResult[0].Split('=')[1]);
                char operatorSymbol = char.Parse(WebUtility.UrlDecode(dataResult[1].Split('=')[1]));
                double secondNumber = double.Parse(dataResult[2].Split('=')[1]);
                Calculate(firstNumber, operatorSymbol, secondNumber);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid sign!");
            }

        }

        private static void Calculate(double firstNumber, char operatorSymbol, double secondNumber)
        {
            double result = 0;
            switch (operatorSymbol)
            {
                case '-':
                    result = firstNumber - secondNumber;
                    Console.WriteLine($"Result: {result}");
                    break;
                case '+':
                    result = firstNumber + secondNumber;
                    Console.WriteLine($"Result: {result}");
                    break;
                case '*':
                    result = firstNumber * secondNumber;
                    Console.WriteLine($"Result: {result}");
                    break;
                case '/':
                    result = firstNumber / secondNumber;
                    Console.WriteLine($"Result: {result}");
                    break;
                default:
                    Console.WriteLine("Invalid sign!");
                    break;
            }
        }
    }
}
