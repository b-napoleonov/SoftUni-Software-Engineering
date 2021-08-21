using System;

namespace onTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int hourExam = int.Parse(Console.ReadLine());
            int minutesExam = int.Parse(Console.ReadLine());
            int hourArrival = int.Parse(Console.ReadLine());
            int minutesArrival = int.Parse(Console.ReadLine());
            int examTime = hourExam * 60 + minutesExam;
            int studentsTime = hourArrival * 60 + minutesArrival;
            int minutesDifference = studentsTime - examTime;
            Console.WriteLine(minutesDifference);

            if (minutesDifference < -30)
                Console.WriteLine("Early");
            else if (minutesDifference <= 0)
                Console.WriteLine("On time");
            else
                Console.WriteLine("Late");
            if (minutesDifference != 0)
            {
                int hours = Math.Abs(minutesDifference / 60);
                int minutes = Math.Abs(minutesDifference % 60);
                if (hours > 0)
                {
                    if (minutes < 10)
                        Console.Write(hours + ":0" + minutes + "hours");
                    else
                        Console.Write(hours + ":" + minutes + "hours");
                }
                else
                    Console.Write(minutes + " minutes");
                if (minutesDifference < 0)
                    Console.WriteLine(" before the start");
                else
                    Console.WriteLine(" after the start");
            }
        }   
    }
}
