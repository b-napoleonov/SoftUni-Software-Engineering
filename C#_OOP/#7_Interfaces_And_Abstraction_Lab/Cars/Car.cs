namespace Cars
{
    //Optional abstract class for achieving higher abstraction and better data encapsulation
    public abstract class Car : ICar
    {
        public Car(string model, string color)
        {
            Model = model;
            Color = color;
        }
        public string Model { get; private set; }
        public string Color { get; private set; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }
    }
}
