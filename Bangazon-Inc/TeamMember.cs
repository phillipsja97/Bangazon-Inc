using System;
using System.Collections.Generic;
using System.Text;

namespace Bangazon
{
    class TeamMember
    {
        public int skillLevel { get; set; }
        public decimal courageFactor { get; set; }
        public string Name { get; set; }
        public TeamMember(string name, int SkillLevel, decimal CourageFactor)
        {
            Name = name;
            skillLevel = SkillLevel;
            courageFactor = CourageFactor;
        }
    }
}