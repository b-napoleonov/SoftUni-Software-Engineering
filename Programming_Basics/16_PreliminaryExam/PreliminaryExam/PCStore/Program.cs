using System;

namespace PCStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double dolarsForCPU = double.Parse(Console.ReadLine());
            double dolarsForGraphicCard = double.Parse(Console.ReadLine());
            double dolarsForRAM = double.Parse(Console.ReadLine());
            int numberOfRams = int.Parse(Console.ReadLine());
            double percentDiscount = double.Parse(Console.ReadLine());

            double levaForCPU = dolarsForCPU * 1.57;
            double levaForGrapjicCard = dolarsForGraphicCard * 1.57;
            double levaForRAM = dolarsForRAM * 1.57;
            double totalForRAM = levaForRAM * numberOfRams;

            levaForCPU = levaForCPU - (levaForCPU * percentDiscount);
            levaForGrapjicCard = levaForGrapjicCard - (levaForGrapjicCard * percentDiscount);
            
            Console.WriteLine($"Money needed - {levaForCPU + levaForGrapjicCard + totalForRAM:F2} leva.");
        }
    }
}
