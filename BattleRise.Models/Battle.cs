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
            var fighters = _fullArmy.GetFighters();
          foreach (var fighter in fighters)
            {
                var attackedFighter=fighter.Active(_fullArmy);
                _fullArmy.UpdateFighter(attackedFighter);
                _fullArmy.UpdateFighters(_deathController.Control(_fullArmy).GetFighters());
            }
        }

        public Army AddFighterToBattle(Army army, IFighter fighter)
        {
            var fighters = _fullArmy.GetFighters();
            fighters.Add(fighter);
            //army.RemoveFighter(fighter);
            _fullArmy.UpdateFighters(fighters);
            return army;
        }
    }
}
