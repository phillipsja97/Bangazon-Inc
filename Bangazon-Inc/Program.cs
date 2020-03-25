using Bangazon;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanYourHeist
{
    class Program
    {
        static void Main(string[] args)
        {
            // this is something called a "TUPLE" whatever that is
            //List<(string name, int skilllevel, decimal couragefactor)> heistskillz = new List<(string, int, decimal)>();
            List<TeamMember> myTeam = new List<TeamMember>();
            var banksDifficultyLevel = 100;

            Console.WriteLine("Plan Your Heist!");

            Console.WriteLine("How many members are on your team?");
            var tMCapacity = Console.ReadLine();

            int i = 0;
            do
            {

                Console.WriteLine("Please enter the name of your team member.");
                var tMName = Console.ReadLine();

                Console.WriteLine($"Please enter the skill level of {tMName} (Has to be a positive number).");
                var tMSkill = Console.ReadLine();
                var tMSkillFactor = Int32.Parse(tMSkill);
                while (tMSkillFactor < 0)
                {
                    Console.WriteLine($"Invalid skill level. Please enter a positive number.");
                    tMSkill = Console.ReadLine();
                    tMSkillFactor = Int32.Parse(tMSkill);
                }

                Console.WriteLine($"Please enter the courage factor of {tMName} (any number between 0.0 and 2.0).");
                var tMCourage = Console.ReadLine();
                var tMCourageFactor = Convert.ToDecimal(tMCourage);
                while (tMCourageFactor < 0.0m || tMCourageFactor > 2.0m)
                {
                    Console.WriteLine($"Invalid courage factor. Please enter any number between 0.0 and 2.0.");
                    tMCourage = Console.ReadLine();
                    tMCourageFactor = Convert.ToDecimal(tMCourage);
                }

                myTeam.Add(new TeamMember(tMName, tMSkillFactor, tMCourageFactor));

                Console.WriteLine($"{tMName} has a skill level of {tMSkillFactor} and a courage factor of {tMCourageFactor}, and has been added to your team!");
                i++;
                Console.ReadLine();

            }
            while (i < Int32.Parse(tMCapacity));

            Console.WriteLine($"You have {tMCapacity} team members! ");

            foreach (var skill in myTeam)
            {
                Console.WriteLine($"{skill.Name}: Skill Level - {skill.skillLevel},  Courage Factor - {skill.courageFactor}");
            }

            Console.WriteLine("How many times would you like to try and rob the bank?");
            var attempts = Console.ReadLine();

            Console.Clear();

            var sumSkillLevel = myTeam.Select(level => level.skillLevel).Sum();
            Console.WriteLine($"The combined skill level of your team is: {sumSkillLevel}.");

            int j = 0;

            do
            {
                var random = new Random();
                var luckValue = random.Next(-10, 10);

                banksDifficultyLevel += luckValue;

                Console.WriteLine($"Your teams combined skill level is {sumSkillLevel}. The bank dificulty level is {banksDifficultyLevel}.");

                if (sumSkillLevel >= banksDifficultyLevel)
                {
                    Console.WriteLine("You succeeded in robbing the bank :) ");
                }
                else
                {
                    Console.WriteLine("You failed in robbing the bank :( ");
                }
                j++;
            }
            while (j < Int32.Parse(attempts));








            Console.ReadLine();
        }
    }
}