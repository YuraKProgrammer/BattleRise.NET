using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models.Fighters
{
    public class FighterAttribute : Attribute
    {
        public string Name { get; }
        public FighterType FighterType { get; }
        public FighterAttribute(string name, FighterType fighterType)
        {
            Name = name;
            FighterType = fighterType;
        }
    }
}
