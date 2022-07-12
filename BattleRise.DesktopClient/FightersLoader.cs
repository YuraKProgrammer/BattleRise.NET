using BattleRise.Models;
using BattleRise.Models.Fighters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.DesktopClient
{
    public class FightersLoader
    {
        private const int x = 1;
        private const int y = 1;
        private const Side side = Side.Friend;
        public Dictionary<int, IFighter> Load(int _castleLevel, Dictionary<int, IFighter> _fighters, int[] _fightersLevels)
        {
            if (_castleLevel >= 1)
            {
                if (!_fighters.ContainsKey(0))
                {
                    _fighters.Add(0, new Warrior(_fightersLevels[0], x, y, side));
                }
                else
                {
                    _fighters.Remove(0);
                    _fighters.Add(0, new Warrior(_fightersLevels[0], x, y, side));
                }
                if (!_fighters.ContainsKey(1))
                {
                    _fighters.Add(1, new Archer(_fightersLevels[1], x, y, side));
                }
                else
                {
                    _fighters.Remove(1);
                    _fighters.Add(1, new Archer(_fightersLevels[1], x, y, side));
                }
                if (!_fighters.ContainsKey(2))
                {
                    _fighters.Add(2, new Zombie(_fightersLevels[2], x, y, side));
                }
                else
                {
                    _fighters.Remove(2);
                    _fighters.Add(2, new Zombie(_fightersLevels[2], x, y, side));
                }
                if (!_fighters.ContainsKey(3))
                {
                    _fighters.Add(3, new Skeleton(_fightersLevels[3], x, y, side));
                }
                else
                {
                    _fighters.Remove(3);
                    _fighters.Add(3, new Skeleton(_fightersLevels[3], x, y, side));
                }
                if (!_fighters.ContainsKey(4))
                {
                    _fighters.Add(4, new LittleGiant(_fightersLevels[4], x, y, side));
                }
                else
                {
                    _fighters.Remove(4);
                    _fighters.Add(4, new LittleGiant(_fightersLevels[4], x, y, side));
                }
                if (!_fighters.ContainsKey(5))
                {
                    _fighters.Add(5, new Knight(_fightersLevels[5], x, y, side));
                }
                else
                {
                    _fighters.Remove(5);
                    _fighters.Add(5, new Knight(_fightersLevels[5], x, y, side));
                }
                if (!_fighters.ContainsKey(6))
                {
                    _fighters.Add(6, new Goblin(_fightersLevels[6], x, y, side));
                }
                else
                {
                    _fighters.Remove(6);
                    _fighters.Add(6, new Goblin(_fightersLevels[6], x, y, side));
                }
                if (!_fighters.ContainsKey(7))
                {
                    _fighters.Add(7, new Orc(_fightersLevels[7], x, y, side));
                }
                else
                {
                    _fighters.Remove(7);
                    _fighters.Add(7, new Orc(_fightersLevels[7], x, y, side));
                }
                if (!_fighters.ContainsKey(8))
                {
                    _fighters.Add(8, new Troll(_fightersLevels[8], x, y, side));
                }
                else
                {
                    _fighters.Remove(8);
                    _fighters.Add(8, new Troll(_fightersLevels[8], x, y, side));
                }
                if (!_fighters.ContainsKey(9))
                {
                    _fighters.Add(9, new Magician(_fightersLevels[9], x, y, side));
                }
                else
                {
                    _fighters.Remove(9);
                    _fighters.Add(9, new Magician(_fightersLevels[9], x, y, side));
                }
            }
            return _fighters;
        }
    }
}
