using BattleRise.Models.Fighters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models.SaveToFile
{
    public static class ArmyConverter
    {
        public static SArmy ToSArmy(Army army)
        {
            var fs = army.GetFighters();
            var sfs = new List<SFighter>();
            foreach(var f in fs)
            {
                var sf = FighterConverter.ToSFighter(f);
                sfs.Add(sf);
            }
            return new SArmy(sfs);
        }
        public static Army ToArmy(SArmy sArmy)
        {
            var sfs = sArmy.GetFighters();
            var fs = new List<IFighter>();
            foreach (var sf in sfs)
            {
                var f = FighterConverter.ToIFighter(sf);
                fs.Add(f);
            }
            return new Army(fs);
        }
    }
}
