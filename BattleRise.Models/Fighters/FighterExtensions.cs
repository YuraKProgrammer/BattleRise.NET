using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models.Fighters
{
    public static class FighterExtensions
    {
        public static int GetDistance(this IHasPosition f1, IHasPosition f2)
        {
            var range = (int)Math.Sqrt(Math.Abs(f1.GetX() * f1.GetX() - f2.GetX() * f2.GetX()) + Math.Abs(f1.GetY() * f1.GetY() - f2.GetY() * f2.GetY()));
            return range;
        }
    }
}
