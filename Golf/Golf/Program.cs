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
            

            while (golf)
            {
                Console.Clear();
                Console.WriteLine("\t1: Start the game" +
                    "\n\t2: end");
                var pressed = Console.ReadKey();

                switch (pressed.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        GameOfGolf g1 = new GameOfGolf();
                        g1.RunGameOfGolf();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
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
