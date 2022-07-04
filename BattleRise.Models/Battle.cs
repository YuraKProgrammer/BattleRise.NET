using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models
{
    public class Battle
    {
        private Army _fullArmy;
        private Level _level;
        private List<IFighter> _fighters;
        private DeathController _deathController;

        public Battle(Level level, Army playerArmy)
        {
            _level = level;
            _fullArmy=Army.UnitArmies(playerArmy, level._enemyArmy);
            _fighters = _fullArmy.GetFighters();
            _deathController = new DeathController();
        }

        public void Act()
        {
          foreach (var fighter in _fighters)
            {
                var attackedFighter=fighter.Active(_fullArmy);
                _fullArmy.UpdateFighter(attackedFighter);
                _fullArmy = _deathController.Control(_fullArmy);
            }
        }
    }
}
