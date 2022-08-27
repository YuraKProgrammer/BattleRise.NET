using BattleRise.Models;
using BattleRise.Models.Fighters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.DesktopClient
{
    public class LevelsLoader : ILevelsLoader
    {
        public List<Level> Load(List<Level> _levels)
        {
            _levels.Add(new Level(150, new Army(new List<IFighter>() { new Warrior(1, 500, 400, Side.Enemy) }), "1. Alone in the field"));
            _levels.Add(new Level(200, new Army(new List<IFighter>() { new Warrior(1, 500, 400, Side.Enemy), new Warrior(1, 500, 500, Side.Enemy) }), "2. Two"));
            _levels.Add(new Level(300, new Army(new List<IFighter>() { new Warrior(2, 500, 400, Side.Enemy), new Warrior(2, 500, 500, Side.Enemy) }), "3. Two two"));
            return _levels;
        }
    }
}
