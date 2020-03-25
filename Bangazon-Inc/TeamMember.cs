using System;
using System.Collections.Generic;
using System.Text;

namespace Bangazon
{
    class TeamMember
    {
        private int _skillLevel;
        private decimal _courageFactor;
        public string Name { get; set; }
        public int SkillLevel
        {
            get
            {
                return _skillLevel;
            }
            set
            {
                if (value >= 0)
                    _skillLevel = value;
            }
        }
        public decimal CourageFactor
        {
            get
            {
                return _courageFactor;
            }
            set
            {
                if (value >= 0.0m || value <= 2.0m)
                    _courageFactor = value;
            }
        }

        public TeamMember(string name, int skillLevel, decimal courageFactor)
        {
            Name = name;
            SkillLevel = skillLevel;
            CourageFactor = courageFactor;
        }
    }
}