using BattleRise.Models.Fighters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models.SaveToFile
{
    public class SFighter
    { 
        public FighterType fighterType { get; set; }
        public int id { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public Side side { get; set; }
        public int level { get; set; }
        public SFighter(FighterType fighterType, int id, int x, int y, Side side, int level)
        {
            this.fighterType = fighterType;
            this.id = id;
            this.x = x;
            this.y = y;
            this.side = side;
            this.level = level;
        }
    }
}
