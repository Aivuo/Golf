using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf
{
    class Program
    {
        static void Main(string[] args)
        {

            StartMenu();
        }

        private static void StartMenu()
        {

            bool golf = true;
            GameOfGolf g1 = new GameOfGolf();

            while (golf)
            {
                Console.Clear();
                Console.WriteLine("\t1: Start the game" +
                    "\n\t2: Nothing really" +
                    "\n\t3: end");
                var pressed = Console.ReadKey();

                switch (pressed.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        g1.RunGameOfGolf();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.WriteLine("Pressed 2");
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.WriteLine("Golf is now false");
                        golf = false;
                        break;

                    default:
                        Console.WriteLine("Errr.... Not correct!");
                        break;
                }
            }
        }
    }
}
