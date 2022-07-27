using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models.SaveToFile
{
    public static class SaveConverter
    {
        public static SSave ToSSave(Save save)
        {
            var sa = ArmyConverter.ToSArmy(save.army);
            var ss = new SSave(save.GetSaveTime(),save.GetUserId(),save.res,sa,save.fightersLevels,save.castleLevel);
            return ss; 
        } 
        public static Save ToSave(SSave sSave)
        {
            var a = ArmyConverter.ToArmy(sSave.sarmy);
            var s = new Save(sSave.GetSaveTime(),sSave.userId,sSave.res,a,sSave.fightersLevels,sSave.castleLevel);
            return s;
        }
    }
}
