using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf
{
    class GameOfGolf
    {
        double startingDistance = 0;
        double distance = 0;
        int par = 0;
        int numberOfSwings = 0;
        bool stopPlaying = false;

        string plural = " ";
        List<string> log = new List<string>();


        public GameOfGolf()
        {
            Random rnd = new Random();

            switch (rnd.Next(0,10))
            {
                case 0:
                    distance = rnd.Next(412, 632);
                    par = 5;
                    break;
                case 1:
                case 2:
                case 3:
                    distance = rnd.Next(230, 412);
                    par = 4;
                    break;
                default:
                    distance = rnd.Next(150, 230);
                    par = 3;
                    break;
            }
            startingDistance = distance;

            Console.WriteLine(distance + "m");
        }

        public void RunGameOfGolf()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(String.Format("\t{0:0.00}m to the hole" +
                    "\n\tPar: {3}" +
                    "\n\tYou have swung {1} time{2}" +
                    "\n\t1: Hit the ball" +
                    "\n\t2: End", distance, numberOfSwings, plural, par));

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        numberOfSwings++;
                        HitTheBall();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.WriteLine("\tWe hope to see you again!");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("\tErrr.... Not correct!");
                        break;
                }
                stopPlaying = CheckVictory();

                if (stopPlaying)
                {
                    Console.ReadKey();
                    return;
                }
                Console.ReadKey();
            }
        }

        private bool CheckVictory()
        {
            bool quit = false;

            if (distance >= 0 && distance <= 0.1)
            {
                Console.Clear();
                if (numberOfSwings == par - 3)
                {
                    Console.WriteLine("\tDOUBLE EAGLE! Very well done!");
                }
                else if (numberOfSwings == par - 2)
                {
                    Console.WriteLine("\tEAGLE! Well done!");
                }
                else if (numberOfSwings == par - 1)
                {
                    Console.WriteLine("\tBirdie. Not bad!");
                }
                else if (numberOfSwings == par)
                {
                    Console.WriteLine("\tPar. Good.");
                }
                else if (numberOfSwings == par + 1)
                {
                    Console.WriteLine("\tBogey. You can do better!");
                }
                else
                {
                    Console.WriteLine("\tDouble bogey... Really...");
                }

                Console.WriteLine(String.Format("\t You finished with {0} swing{1}" +
                                                "\n\t At a par {2}hole that was {3}m long", numberOfSwings, plural, par, startingDistance));

                foreach (var l in log)
                {
                    Console.WriteLine(l);
                }

                quit = true;
            }

            if (numberOfSwings >= par + 3)
            {
                Console.Clear();
                Console.WriteLine("\tHow did you get onto the pro circuit?");

                foreach (var l in log)
                {
                    Console.WriteLine(l);
                }
                quit = true;
            }
            else if(distance > startingDistance * 1.5)
            {
                Console.WriteLine("\tWhat just happened! You are outside the course!");
                quit = true;
            }

            return quit;
        }

        private void HitTheBall()
        {
            double angleInRadians = 0;
            double angle = 0;
            double gravity = 9.8;
            double velocity = 0;
            double distanceTravelled = 0;

            string userInput = null;
            string output = null;



            Console.WriteLine("\tInput at witch angle you would like to fire the ball:");
            userInput = Console.ReadLine();
            double.TryParse(userInput, out angle);

            angleInRadians = (Math.PI / 180) * angle;

            Console.WriteLine("\tInput the power in m/s: ");
            userInput = Console.ReadLine();
            double.TryParse(userInput, out velocity);

            distanceTravelled = Math.Pow(velocity, 2) / gravity * Math.Sin(2 * angleInRadians);

            if (numberOfSwings == 1)
            {
                plural = " ";
            }
            else
            {
                plural = "s";
            }

            output = String.Format("The ball flies: {0:0.00}m \nYou have swung {1} time{2}", distanceTravelled, numberOfSwings, plural);
            log.Add(output);
            Console.WriteLine(output);
            distance -= distanceTravelled;

            if (distance < 0)
            {
                distance = -distance;
            }

            output = String.Format("There is: {0:0.00}m left to the hole\n", distance);
            log.Add(output);
            Console.WriteLine(output);
            
        }
    }
}