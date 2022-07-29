using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models.SaveToFile
{
    public static class LevelConverter
    {
        public static SLevel ToSLevel(Level level)
        {
            var sa = ArmyConverter.ToSArmy(level._enemyArmy);
            var sl = new SLevel(level._reward, sa, level._name);
            return sl;
        } 
        public static Level ToLevel(SLevel sLevel)
        {
            var a = ArmyConverter.ToArmy(sLevel._enemyArmy);
            var l = new Level(sLevel._reward, a, sLevel._name);
            return l;
        }
    }
}
