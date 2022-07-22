using BattleRise.Models.Fighters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models
{
    public class FightersGroup
    {
        public IFighter fighter { get; set; }
        public int count { get; set; }
        public FightersGroup(IFighter fighter, int count)
        {
            this.fighter = fighter;
            this.count = count;
        }
    }
}
