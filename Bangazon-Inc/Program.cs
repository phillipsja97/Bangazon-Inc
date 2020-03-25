using System;

namespace Bangazon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plan Your Heist!");
            Console.WriteLine("Please enter the name of your team member");
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

            var tM = new TeamMember(tMName, tMSkillFactor, tMCourageFactor);

            Console.WriteLine($"{tMName} has a skill level of {tMSkillFactor} and a courage factor of {tMCourageFactor}, and has been added to your team!");
            Console.ReadLine();

        }
    }
}