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
            for (var i=0; i<fighters.Count(); i++)
            {
                if (fighters[0].GetHealth() <= 0)
                {
                    fighters.Remove(fighters[i]);
                }
            }
            return new Army(fighters);
        }
    }
}
