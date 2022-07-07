using BattleRise.Models.Fighters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models
{
    public class Battle
    {
        public Army _fullArmy { get; }
        public Level _level { get; }
        public List<IFighter> _fighters { get; }
        public DeathController _deathController = new DeathController();
        public BattleField _field;

        public Battle(Level level, int wigth, int height)
        {
            _level = level;
            _fullArmy = _level._enemyArmy;
            _field = new BattleField(wigth, height);
        }

        public void Act()
        {
          foreach (var fighter in _fighters)
            {
                var attackedFighter=fighter.Active(_fullArmy);
                _fullArmy.UpdateFighter(attackedFighter);
                _fullArmy.UpdateFighters(_deathController.Control(_fullArmy).GetFighters());
            }
        }
    }
}
