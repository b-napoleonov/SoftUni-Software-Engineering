namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public void Call(string number)
        {
            System.Console.WriteLine($"Dialing... {number}");
        }
    }
}
