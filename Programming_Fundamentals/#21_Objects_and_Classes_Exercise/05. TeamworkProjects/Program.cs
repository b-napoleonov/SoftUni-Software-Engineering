using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Team> allTeams = new List<Team>();

            for (int i = 0; i < n; i++)
            {
                string[] teamsToRegister = Console.ReadLine().Split('-');

                string user = teamsToRegister[0];
                string team = teamsToRegister[1];

                bool isTeamNameExist = allTeams
                .Select(x => x.TeamName).Contains(team);

                bool isCreatorExist = allTeams
                    .Any(x => x.Creator == user);

                if (isTeamNameExist == false && isCreatorExist == false)
                {
                    Team currentTeam = new Team(team, user);

                    allTeams.Add(currentTeam);

                    Console.WriteLine($"Team {team} has been created by {user}!");
                }
                else if (isTeamNameExist)
                {
                    Console.WriteLine($"Team {team} was already created!");
                }
                else if (isCreatorExist)
                {
                    Console.WriteLine($"{user} cannot create another team!");
                }
            }

            string input = Console.ReadLine();

            while (input != "end of assignment")
            {
                string[] inputAssignment = input
                .Split(new[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);

                string fen = inputAssignment[0];

                string ofFensTeam = inputAssignment[1];

                bool isTeamExist = allTeams.Any(x => x.TeamName == ofFensTeam);

                bool isCreatorCheating = allTeams.Any(x => x.Creator == fen);
                bool isAlreadyFen = allTeams.Any(x => x.Members.Contains(fen));

                if (isTeamExist && isCreatorCheating == false && isAlreadyFen == false)
                {
                    int indexOfTeam = allTeams
                        .FindIndex(x => x.TeamName == ofFensTeam);

                    allTeams[indexOfTeam].Members.Add(fen);
                }
                else if (isTeamExist == false)
                {
                    Console.WriteLine($"Team {ofFensTeam} does not exist!");
                }
                else if (isAlreadyFen || isCreatorCheating)
                {
                    Console.WriteLine($"Member {fen} cannot join team {ofFensTeam}!");
                }

                input = Console.ReadLine();
            }

            List<Team> teamWithMember = allTeams
            .Where(x => x.Members.Count > 0)
            .OrderByDescending(x => x.Members.Count)
            .ThenBy(x => x.TeamName)
            .ToList();

            List<Team> notValidTeam = allTeams
                .Where(x => x.Members.Count == 0)
                .OrderBy(x => x.TeamName)
                .ToList();

            foreach (var team in teamWithMember)
            {
                Console.WriteLine(team.TeamName);
                Console.WriteLine("- " + team.Creator);
                team.Members.Sort();
                Console.WriteLine(string.Join(Environment.NewLine, team.Members.Select(x => "-- " + x)));
            }

            Console.WriteLine("Teams to disband:");

            foreach (var team in notValidTeam)
            {
                Console.WriteLine(team.TeamName);
            }
        }
    }

    public class Team
    {
        public Team(string name, string creator)
        {
            TeamName = name;
            Creator = creator;
            Members = new List<string>();
        }
        public string TeamName { get; set; }

        public string Creator { get; set; }

        public List<string> Members{ get; set; }
    }
}
