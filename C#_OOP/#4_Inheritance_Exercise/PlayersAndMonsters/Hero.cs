namespace PlayersAndMonsters
{
    public class Hero
    {
        public Hero(string userName, int level)
        {
            Username = userName;
            Level = level;
        }
        public string Username { get; set; }
        public int Level { get; set; }

        public override string ToString()
        {
            return $"Type: {GetType().Name} Username: {Username} Level: {Level}";
        }
    }
}
