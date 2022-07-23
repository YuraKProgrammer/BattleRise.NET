using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models.SaveToFile
{
    public class SSave
    {
        public DateTime saveTime { get; }

        public int userId { get; }

        public Resources res { get; }

        public SArmy sarmy { get; }

        public int[] fightersLevels { get; }

        public int castleLevel { get; }

        public SSave(DateTime saveTime, int userId, Resources res, SArmy sarmy, int[] fightersLevels, int castleLevel)
        {
            this.saveTime = saveTime;
            this.userId = userId;
            this.res = res;
            this.sarmy = sarmy;
            this.fightersLevels = fightersLevels;
            this.castleLevel = castleLevel;
        }

        public void SetCoins(int coins)
        {
            res.coins = coins;
        }

        public void SetDiamonds(int diamonds)
        {
            res.diamonds = diamonds;
        }

        public int GetUserId()
        {
            return userId;
        }

        public DateTime GetSaveTime()
        {
            return saveTime;
        }
    }
}
