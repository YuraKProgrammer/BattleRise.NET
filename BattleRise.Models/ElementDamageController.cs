using BattleRise.Models.Fighters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models
{
    public class ElementDamageController
    {
        public double Control(IFighter attacking, IFighter attacked)
        {
            var e1 = attacking.GetElement();
            var e2 = attacked.GetElement();
            var d = attacking.GetDamage();
            //Здесь система повышения и понижения урона при сочетании стихий
            return d;
        }
    }
}
