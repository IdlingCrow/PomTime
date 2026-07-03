using System;
using System.Timers;

namespace prototype
{
    public class pomPrototype
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.Write("What is your name?: ");

            string userName = Console.ReadLine();

            Console.WriteLine("Hello " + userName + "!");
        }
    }
}


