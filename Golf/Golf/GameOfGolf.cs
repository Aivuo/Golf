using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf
{
    class GameOfGolf
    {
        double distance = 0;


        public GameOfGolf()
        {
            Random rnd = new Random();

            distance = rnd.Next(150, 230);

            Console.WriteLine(distance + "m");
        }

        public void RunGameOfGolf()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(String.Format("{0:0.00}m to the hole" +
                    "\n\t1: Hit the ball" +
                    "\n\t2: End", distance));

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        HitTheBall();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.WriteLine("Leave now and never come back!");
                        return;

                    default:
                        Console.WriteLine("Errr.... Not correct!");
                        break;

                }
                Console.ReadKey();
            }
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

            output = String.Format("The ball flies: {0:0.00}m", distanceTravelled);
            Console.WriteLine(output);
            distance -= distanceTravelled;

            if (distance < 0)
            {
                distance = -distance;
            }

            output = String.Format("There is: {0:0.00}m left to the hole", distance);
            Console.WriteLine(output);
            
        }
    }
}


//        ○ Angle In Radians: (Math.PI / 180) * angle
//        ○ Distance: Math.Pow(velocity, 2) / GRAVITY* Math.Sin(2 * angleInRadians)
//• Gravity is equal to 9.8