using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models.Fighters
{
    public interface IFighter : IHasPosition
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
        void SetX(int x);
        void SetY(int y);
        int GetY();
        Side GetSide();
        string GetName();
        int GetLevel();
        double GetDamage();
        int GetSpeed();
        int GetRange();
        Uri GetFileFolder();
        Uri GetFileFolderEnemy();
        Element GetElement();

        int Id { get; set;  }
    }
}
