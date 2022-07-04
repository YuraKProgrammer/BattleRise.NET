using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models
{
    public class Save
    {
        public DateTime saveTime { get; }

        public int userId{ get; }

        public Resources res { get; }

        public Army army { get; }

        public List<int> fightersLevels { get; }

        public Save (DateTime saveTime, int userId, Resources res, Army army, List<int> fightersLevels)
        {
            this.saveTime = saveTime;
            this.userId = userId;
            this.res = res;
            this.army = army;
            this.fightersLevels = fightersLevels;
        }
    }
}
