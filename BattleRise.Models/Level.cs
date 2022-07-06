using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models
{
    public class Level
    {
        public int _reward { get; set; }
        public Army _enemyArmy { get; set; }
        public string _name { get; set; }

        public Level(int reward, Army enemyArmy, string name)
        {
            _reward = reward;
            _enemyArmy = enemyArmy;
            _name = name;
        }
    }
}
