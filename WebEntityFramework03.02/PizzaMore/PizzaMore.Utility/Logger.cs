namespace PizzaMore.Utility
{
    using System;
    using System.IO;

    public class Logger
    {
        public static void Log(string message)
        {
            File.WriteAllText(message + Environment.NewLine, "../../log.txt");
        }
    }
}