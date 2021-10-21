using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BowlingExampleTemplate.Bowling
{
    public class BowlingLogic
    {
        private static int firstThrow = 0;
        private static int secondThrow = 0;
        private static int sum = 0;
        private static int frames = 10;
        private static Random rng = new Random();
        public static void bowlingGame()
        {
            for (int i = 0; i < frames; i++)
            {
                try
                {
                    Console.WriteLine("Frame: " + (i + 1) + " ---> First throw: ");
                    firstThrow = int.Parse(Console.ReadLine());
                    if (firstThrow > 10)
                    {
                        Console.WriteLine("You can't hit more than 10 bowles");
                        i--;
                        continue;
                    }
                    else if (firstThrow == 10)
                    {
                        strike();
                    }
                    else
                    {
                        Console.WriteLine("Frame: " + (i + 1) + " ---> Second throw: ");
                        secondThrow = int.Parse(Console.ReadLine());
                        if (secondThrow > 10 || firstThrow + secondThrow > 10)
                        {
                            Console.WriteLine("You can't hit more than 10 bowles");
                            i--;
                            continue;
                        }
                        else if (firstThrow == 0 && secondThrow == 10)
                        {
                            strike();
                        }
                        else if (firstThrow + secondThrow == 10)
                        {
                            sum += secondThrow;
                            spare();
                        }
                        else
                        {
                            sum += secondThrow;
                        }
                        sum += firstThrow;
                    }
                }
                catch
                {
                    Console.WriteLine("You must enter a numbered values");
                }
            }
            Console.WriteLine("Your final score is: " + sum);
        }

        public static void bowlingGameWithRNG()
        {
            for (int i = 0; i < frames; i++)
            {
                try
                {
                    firstThrow = rng.Next(1, 10);
                    Console.WriteLine("Frame: " + (i + 1) + " ---> First throw = " + firstThrow);
                    if (firstThrow == 10)
                    {
                        strike();
                    }
                    else
                    {
                        secondThrow = rng.Next(1, 10 - firstThrow);
                        Console.WriteLine("Frame: " + (i + 1) + " ---> Second throw = " + secondThrow);
                        if (firstThrow == 0 && secondThrow == 10)
                        {
                            strike();
                        }
                        else if (firstThrow + secondThrow == 10)
                        {
                            sum += secondThrow;
                            spare();
                        }
                        else
                        {
                            sum += secondThrow;
                        }
                        sum += firstThrow;
                    }
                }
                catch
                {
                    Console.WriteLine("You must enter a numbered values");
                }
            }
            Console.WriteLine("Your final score is: " + sum);
        }

        private static void strike()
        {
            sum += 20;
        }

        private static void spare()
        {
            sum += 5;
        }
    }
}
