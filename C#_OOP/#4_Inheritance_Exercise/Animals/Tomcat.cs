namespace Animals
{
    public class Tomcat : Cat
    {
        public const string DefaultGender = "Male";
        public Tomcat(string name, int age)
            : base(name, age, DefaultGender)
        {
            Sound = "MEOW";
        }
    }
}
