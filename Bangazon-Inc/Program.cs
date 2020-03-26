using Bangazon;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamHeist
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TeamMember> myTeam = new List<TeamMember>();

            Console.WriteLine("Plan Your Heist! What is the difficulty level of the bank you want to rob?");
            var bankDifficultyLevelInput = Console.ReadLine();
            var difficultyLevel = Int32.TryParse(bankDifficultyLevelInput, out int bankDifficultyLevel);

            while (bankDifficultyLevel <= 0)
            {
                Console.WriteLine("Sorry! Difficulty Level has to be a positive number!");
                bankDifficultyLevelInput = Console.ReadLine();
                difficultyLevel = Int32.TryParse(bankDifficultyLevelInput, out bankDifficultyLevel);
            }

            Console.WriteLine("How many members are on your team?");
            var teamCapacityInput = Console.ReadLine();
            var teamCapacity = Int32.TryParse(teamCapacityInput, out int capacity);

            while (capacity <= 0)
            {
                Console.WriteLine("Sorry! Team members has to be a positive number!");
                teamCapacityInput = Console.ReadLine();
                teamCapacity = Int32.TryParse(teamCapacityInput, out capacity);
            }

            int i = 0;
            do
            {
                i++;
                Console.WriteLine("Please enter the name of your team member.");
                var teamMemberName = Console.ReadLine();

                Console.WriteLine($"Please enter the skill level of {teamMemberName} (Has to be a positive number).");
                var teamMemberSkill = Console.ReadLine();
                int teamMemberSkillLevel;
                bool num = int.TryParse(teamMemberSkill, out teamMemberSkillLevel);
                while (!num || teamMemberSkillLevel < 0)
                {
                    Console.WriteLine($"Invalid skill level. Please enter a positive number.");
                    teamMemberSkill = Console.ReadLine();
                    num = int.TryParse(teamMemberSkill, out teamMemberSkillLevel);
                }

                Console.WriteLine($"Please enter the courage factor of {teamMemberName} (any number between 0.0 and 2.0).");
                var teamMemberCourage = Console.ReadLine();
                var courageFactor = Decimal.TryParse(teamMemberCourage, out decimal teamMemberCourageFactor);
                while (teamMemberCourageFactor <= 0.0m || teamMemberCourageFactor > 2.0m)
                {
                    Console.WriteLine($"Invalid courage factor. Please enter any number between 0.0 and 2.0.");
                    teamMemberCourage = Console.ReadLine();
                    courageFactor = Decimal.TryParse(teamMemberCourage, out teamMemberCourageFactor);
                }

                myTeam.Add(new TeamMember(teamMemberName, teamMemberSkillLevel, teamMemberCourageFactor));

                Console.WriteLine($"{teamMemberName} has a skill level of {teamMemberSkillLevel} and a courage factor of {teamMemberCourageFactor}, and has been added to your team!");
                Console.ReadLine();
            }
            while (i < capacity);

            Console.WriteLine($"You have {capacity} team members! ");

            foreach (var member in myTeam)
            {
                Console.WriteLine($"{member.Name}: Skill: {member.skillLevel},  Courage: {member.courageFactor}");
            }
            Console.WriteLine("How many times would you like to attempt to rob the bank?");
            var attempts = Console.ReadLine();
            var attemptsParse = Int32.TryParse(attempts, out int attemptsInt);

            while (attemptsInt <= 0)
            {
                Console.WriteLine("Sorry! Attempts has to be a positive number!");
                attempts = Console.ReadLine();
                attemptsParse = Int32.TryParse(attempts, out attemptsInt);
            }

            Console.Clear();

            var sumSkillLevel = myTeam.Select(level => level.skillLevel).Sum();
            Console.WriteLine($"Your combined skill level is:{sumSkillLevel}");

            int j = 0;
            var success = 0;
            var fails = 0;

            do
            {
                var random = new Random();
                var luckValue = random.Next(-10, 10);

                var newDifficultyLevel = bankDifficultyLevel + luckValue;

                Console.WriteLine($"Your teams combined skill level is {sumSkillLevel}. The bank dificulty level is {newDifficultyLevel}.");

                if (sumSkillLevel >= newDifficultyLevel)
                {
                    Console.WriteLine("You succeeded!");
                    success += 1;
                }
                else
                {
                    Console.WriteLine("You failed!");
                    fails += 1;
                }
                j++;
            }
            while (j < attemptsInt);

            Console.WriteLine($"Your team had a total of {success} successful bank robberies and a total of {fails} failed bank robberies.");
            Console.ReadKey();
        }
    }
}