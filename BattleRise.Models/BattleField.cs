using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models
{
    public class BattleField
    {
        public int width { get; }
        public int height { get; }

        public BattleField(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
    }
}
