using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models
{
    public interface IFighter
    {
        IFighter Active(Army army);
        void SelectTarget(Army army);
        void StepToTarget(IFighter fighter);
        IFighter Attack(Army army);
        int GetRangeToTarget(IFighter fighter);
        int GetCost();
        int GetLevelUpCost();
        double GetHealth();
        void SetHealth(double health);
        int GetX();
        int GetY();
        Side GetSide();
        int GetId();
        string GetName();
        void SetId(int id);
        int GetLevel();
        double GetDamage();
        int GetSpeed();
        int GetRange();
    }
}
