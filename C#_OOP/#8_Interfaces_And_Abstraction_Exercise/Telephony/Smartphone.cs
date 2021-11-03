namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public void Browse(string site)
        {
            System.Console.WriteLine($"Browsing: {site}!");
        }

        public void Call(string number)
        {
            System.Console.WriteLine($"Calling... {number}");
        }
    }
}
