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

        public Battle(Level level, int width, int height)
        {
            _level = level;
            _fullArmy = _level._enemyArmy;
            _field = new BattleField(width, height);
        }
        /// <summary>
        /// Sandbox battle
        /// </summary>
        public Battle(int width, int height)
        {
            _fullArmy = new Army(new List<IFighter>());
            _field = new BattleField(width, height);
        }

        public void Act()
        {
            var fighters = _fullArmy.GetFighters();
            for (var i=0; i<fighters.Count(); i++)
            {
                var fighter = fighters[i];
                var attackedFighter = fighter.Active(_fullArmy);
                _fullArmy.UpdateFighter(attackedFighter);
            }
            _fullArmy.UpdateFighters(_deathController.Control(_fullArmy).GetFighters());
        }

        public Army AddFighterToBattle(Army army, IFighter fighter)
        {
            _fullArmy.AddFighter(fighter);
            army.RemoveFighter(fighter.GetId());
            return army;
        }

        public void EmptyAddFighterToBattle(IFighter fighter)
        {
            _fullArmy.AddFighter(fighter);
        }
    }
}
