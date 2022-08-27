using BattleRise.Models;
using BattleRise.Models.Fighters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.DesktopClient
{
    /// <summary>
    /// Этот класс загружает бойцов в передаваемый Dictionary
    /// </summary>
    public class FightersLoader : IFightersLoader
    {
        private const int x = 1;
        private const int y = 1;
        private const Side side = Side.Friend;
        public Dictionary<int, IFighter> Load(int _castleLevel, Dictionary<int, IFighter> _fighters, int[] _fightersLevels)
        {
            var types = typeof(IFighter).Assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Where(t => typeof(IFighter).IsAssignableFrom(t));
            for (var i = 0; i < types.Count(); i++)
            {
                if (!_fighters.ContainsKey(i))
                {
                    Type t = types.ToArray()[i];
                    var f = (IFighter)Activator.CreateInstance(t, _fightersLevels[i], x, y, side);
                    _fighters.Add(i, f);
                }
                else
                {
                    _fighters.Remove(i);
                    Type t = types.ToArray()[i];
                    var f = (IFighter)Activator.CreateInstance(t, _fightersLevels[i], x, y, side);
                    _fighters.Add(i, f);
                }
            }
            return _fighters;
        }
    }
}
