using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models
{
    public class DeathController
    {
        public Army Control(Army army)
        {
            var fighters = army.GetFighters();
            foreach (var fighter in fighters)
            {
                if (fighter.GetHealth() <= 0)
                {
                    var id = fighter.GetId();
                    army.RemoveFighter(id);
                }
            }
            return army;
        }
    }
}
