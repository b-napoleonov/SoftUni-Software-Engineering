using System;

namespace _10_Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int gamesLost = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double total = 0;

            int headsetCounter = gamesLost / 2;
            int mouseCounter = gamesLost / 3;
            int keyboardCounter = gamesLost / 6;
            int displayCounter = gamesLost / 12;

            total = headsetCounter * headsetPrice + mouseCounter * mousePrice + keyboardCounter * keyboardPrice + displayCounter * displayPrice;
            
            Console.WriteLine($"Rage expenses: {total:f2} lv.");
        }
    }
}
