using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;
        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => roster.Count;

        public void AddPlayer(Player player)
        {
            if (Count < Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            return roster.Remove(roster.FirstOrDefault(n => n.Name == name));
        }

        public void PromotePlayer(string name)
        {
                roster.FirstOrDefault(p => p.Name == name).Rank = "Member";
        }

        public void DemotePlayer(string name)
        {
                roster.FirstOrDefault(p => p.Name == name).Rank = "Trial";
        }

        public Player[] KickPlayersByClass(string @class)
        {
            List<Player> data = roster.FindAll(p => p.Class == @class);

            roster = roster.Where(p => p.Class != @class).ToList();

            return data.ToArray();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {Name}");

            foreach (var player in roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
