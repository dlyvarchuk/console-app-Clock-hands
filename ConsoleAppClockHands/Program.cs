using System;

namespace ConsoleAppClockHands
{
    class Program
    {
        static void Main()
        {
            ConsoleKeyInfo cki;
            do
            {
                Console.Clear();
                checkThisClock();
                cki = Console.ReadKey();
            }
            while (cki.Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Checks the input hours and minutes values and shows the degree between the clock hands
        /// </summary>
        private static void checkThisClock()
        {
            int hoursInt = 0;
            int minutesInt = 0;
            bool correctHours = false;
            bool correctMinutes = false;

            while (!correctHours)
            {
                Console.Write("Enter hours(am/pm): ");
                var hoursStr = Console.ReadLine();
                if (hoursStr == null
                    || hoursStr.Length > 2  // in case of 00012 values
                    || !int.TryParse(hoursStr, out hoursInt)
                    || (hoursInt < 1 || hoursInt > 12))
                        Console.WriteLine("Wrong input");
                    else
                        correctHours = true;
            }

            while (!correctMinutes)
            { 

            Console.Write("Enter minutes: ");
            var minuteStr = Console.ReadLine();
            if (minuteStr == null
                || minuteStr.Length > 2
                || !int.TryParse(minuteStr, out minutesInt)
                || (minutesInt < 0 || minutesInt > 59))
                    Console.WriteLine("Wrong input");
                else
                    correctMinutes = true;
            }

            Console.WriteLine(calculateCurrentDegree(hoursInt, minutesInt));
            Console.WriteLine("Press <Esc> key to quit or Any other key to continue...");
        }

        /// <summary>
        /// Calculates the acute angle between the clock hands 
        /// </summary>
        /// <param name="hours">integer hours value</param>
        /// <param name="minutes">integer minutes value</param>
        /// <returns>A string of the acute degree value</returns>
        private static string calculateCurrentDegree(int hours, int minutes)
        {
            double hDegrees = (hours * 30) + (minutes * 0.5);
            double mDegrees = minutes * 6;
            double diff = Math.Abs(hDegrees - mDegrees);

            if (diff > 180)
                diff = 360 - diff;

            return (String.Format("The angle between sticks is: {0} degrees", diff));
        }
    }
}
