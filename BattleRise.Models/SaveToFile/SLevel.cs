using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models.SaveToFile
{
    public class SLevel
    {
        public int _reward { get; set; }
        public SArmy _enemyArmy { get; set; }
        public string _name { get; set; }

        public SLevel(int reward, SArmy enemyArmy, string name)
        {
            _reward = reward;
            _enemyArmy = enemyArmy;
            _name = name;
        }
    }
}
