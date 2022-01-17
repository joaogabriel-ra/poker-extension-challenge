using Poker.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new HandParser();
            string input = Console.ReadLine();

            Console.WriteLine(parser.GetHandName(input));
        }
    }
}
