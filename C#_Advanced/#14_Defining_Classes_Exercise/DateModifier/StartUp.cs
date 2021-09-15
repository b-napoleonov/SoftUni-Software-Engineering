using System;

namespace DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstDate = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            DateTime first = new DateTime(int.Parse(firstDate[0]), int.Parse(firstDate[1].TrimStart('0')), int.Parse(firstDate[2].TrimStart('0')));

            string[] secondDate = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            DateTime second = new DateTime(int.Parse(secondDate[0]), int.Parse(secondDate[1].TrimStart('0')), int.Parse(secondDate[2].TrimStart('0')));

            Console.WriteLine(DateModifier.GetDifference(first, second));
        }
    }
}
