using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models
{
    public class Resources
    {
        public int coins { get; set; }
        public int diamonds { get; set; }
        public Resources(int coins, int diamonds)
        {
            this.coins = coins;
            this.diamonds = diamonds;
        }
    }
}
