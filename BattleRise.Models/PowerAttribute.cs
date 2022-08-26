using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models
{
    [AttributeUsage(AttributeTargets.Field)]
    public class PowerAttribute : Attribute
    {
        public string Name { get; }
        public PowerAttribute(string name)
        {
            Name = name;
        }
    }
}
