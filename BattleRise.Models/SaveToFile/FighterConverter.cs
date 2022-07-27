using BattleRise.Models.Fighters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models.SaveToFile
{
    public static class FighterConverter
    {
        public static SFighter ToSFighter(IFighter fighter)
        {
            FighterType ft = FighterType.Warrior;
            if (fighter.GetName() == "Солдат")
            {
                ft = FighterType.Warrior;
            }
            if (fighter.GetName() == "Лучник")
            {
                ft = FighterType.Archer;
            }
            if (fighter.GetName() == "Зомби")
            {
                ft = FighterType.Zombie;
            }
            if (fighter.GetName() == "Скелет")
            {
                ft = FighterType.Skeleton;
            }
            if (fighter.GetName() == "Великан")
            {
                ft = FighterType.LittleGiant;
            }
            if (fighter.GetName() == "Рыцарь")
            {
                ft = FighterType.Knight;
            }
            if (fighter.GetName() == "Гоблин")
            {
                ft = FighterType.Goblin;
            }
            if (fighter.GetName() == "Орк")
            {
                ft = FighterType.Orc;
            }
            if (fighter.GetName() == "Тролль")
            {
                ft = FighterType.Troll;
            }
            if (fighter.GetName() == "Маг")
            {
                ft = FighterType.Magician;
            }
            SFighter sf = new SFighter(ft, fighter.Id, fighter.GetX(), fighter.GetY(), fighter.GetSide(), fighter.GetLevel());
            return sf;
            
        }

        public static IFighter ToIFighter(SFighter sFighter)
        {
            IFighter f = new Warrior(sFighter.level, sFighter.x, sFighter.y, sFighter.side);
            f.Id = sFighter.id;
            if (sFighter.fighterType == FighterType.Warrior)
            {
                f = new Warrior(sFighter.level, sFighter.x, sFighter.y, sFighter.side);
            }
            if (sFighter.fighterType == FighterType.Archer)
            {
                f = new Archer(sFighter.level, sFighter.x, sFighter.y, sFighter.side);
            }
            if (sFighter.fighterType == FighterType.Zombie)
            {
                f = new Zombie(sFighter.level, sFighter.x, sFighter.y, sFighter.side);
            }
            if (sFighter.fighterType == FighterType.Skeleton)
            {
                f = new Skeleton(sFighter.level, sFighter.x, sFighter.y, sFighter.side);
            }
            if (sFighter.fighterType == FighterType.LittleGiant)
            {
                f = new LittleGiant(sFighter.level, sFighter.x, sFighter.y, sFighter.side);
            }
            if (sFighter.fighterType == FighterType.Knight)
            {
                f = new Knight(sFighter.level, sFighter.x, sFighter.y, sFighter.side);
            }
            if (sFighter.fighterType == FighterType.Goblin)
            {
                f = new Goblin(sFighter.level, sFighter.x, sFighter.y, sFighter.side);
            }
            if (sFighter.fighterType == FighterType.Orc)
            {
                f = new Orc(sFighter.level, sFighter.x, sFighter.y, sFighter.side);
            }
            if (sFighter.fighterType == FighterType.Troll)
            {
                f = new Troll(sFighter.level, sFighter.x, sFighter.y, sFighter.side);
            }
            if (sFighter.fighterType == FighterType.Magician)
            {
                f = new Magician(sFighter.level, sFighter.x, sFighter.y, sFighter.side);
            }
            f.Id = sFighter.id;
            return f;
        }
    }
}
