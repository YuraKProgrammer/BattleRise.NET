using BattleRise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.DesktopClient
{
    public interface ILevelsLoader
    {
        public List<Level> Load(List<Level> _levels);
    }
}
