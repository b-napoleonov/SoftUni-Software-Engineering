using System;

namespace volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            const int freeVolleyballWeekends = 48;
            string yearType = Console.ReadLine();
            double holidays = double.Parse(Console.ReadLine());
            double weekends = double.Parse(Console.ReadLine());

            double noTravel = freeVolleyballWeekends - weekends;
            double sofiaGamesHoliday = (holidays * 2) / 3; 
            double sofiaSaturdayGames = (noTravel * 3) / 4;
            double totalTimePlayed = sofiaGamesHoliday + sofiaSaturdayGames + weekends;

            if (yearType == "leap")
            {
                totalTimePlayed *= 1.15;
            }
            Console.WriteLine(Math.Floor(totalTimePlayed));
        }
    }
}
