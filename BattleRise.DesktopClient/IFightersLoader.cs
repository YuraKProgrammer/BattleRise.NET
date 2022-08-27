using BattleRise.Models.Fighters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.DesktopClient
{
    public interface IFightersLoader
    {
        public Dictionary<int, IFighter> Load(int _castleLevel, Dictionary<int, IFighter> _fighters, int[] _fightersLevels);
    }
}
