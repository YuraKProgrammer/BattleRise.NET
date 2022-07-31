using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models.Fighters
{
    [Fighter("Рыцарь", FighterType.Knight)]
    public class Knight : FighterBase, IFighter, IHasPosition
    {
        public string name { get; }
        public double health { get; set; }
        public double damage { get; }
        public int speed { get; }
        public int range { get; }
        public int cost { get; }
        public int targetId;
        private int level { get; }
        public int x { get; set; }
        public int y { get; set; }
        public bool isAttack;
        public Side side { get; }
        public const string fileFolder = @"/BattleRise.DesktopClient;component/images/6.jpg";
        public const string fileFolderEnemy = @"/BattleRise.DesktopClient;component/images/6.2.jpg";
        public const Element element = Element.Metal;
        private ElementDamageController damageController = new ElementDamageController();


        public Knight(int level, int x, int y, Side side)
        {
            this.x = x;
            this.y = y;
            name = "Рыцарь";
            health = 15;
            damage = 3;
            speed = 2;
            range = 20;
            cost = 15;
            this.level = level;
            health = health * Math.Pow(1.1, level - 1);
            damage = damage * Math.Pow(1.1, level - 1);
            this.side = side;
        }
        public IFighter Active(Army army)
        {
            if (army != null)
            {
                if (targetId == 0 || army.GetById(targetId) == null)
                {
                    SelectTarget(army);
                }
                if (targetId > 0 && army.GetById(targetId) != null)
                {
                    if (GetRangeToTarget(army.GetById(targetId)) > range)
                        StepToTarget(army.GetById(targetId));
                    if (GetRangeToTarget(army.GetById(targetId)) <= range)
                    {
                        var attackedEnemy = Attack(army);
                        return attackedEnemy;
                    }
                }
            }
            return army.GetById(targetId);
        }

        public IFighter Attack(Army army)
        {
            var enemy = army.GetById(targetId);
            enemy.SetHealth(enemy.GetHealth() - damageController.Control(this, enemy));
            return enemy;
        }

        public void SelectTarget(Army army)
        {
            IFighter[] fighters = null;
            if (side == Side.Friend)
            {
                fighters = army.GetFighters().Where(f => f.GetSide() == Side.Enemy).ToArray();
            }
            else
            {
                fighters = army.GetFighters().Where(f => f.GetSide() == Side.Friend).ToArray();
            }
            Random random = new Random();
            var n = random.Next(fighters.Length);
            var fighter = fighters[n];
            if (fighter != null)
                targetId = fighter.Id;
            else
                targetId = 0;
        }

        public void StepToTarget(IFighter fighter)
        {
            var angle = Math.Atan2(fighter.GetY() - y, fighter.GetX() - x);
            var dx = speed * Math.Cos(angle);
            var dy = speed * Math.Sin(angle);
            x += (int)dx;
            y += (int)dy;
        }

        public int GetRangeToTarget(IFighter fighter)
        {
            return fighter.GetDistance(this);
        }

        public int GetLevelUpCost()
        {
            return cost * 10;
        }
        public int GetCost()
        {
            return cost;
        }
        public double GetHealth()
        {
            return health;
        }
        public void SetHealth(double health)
        {
            this.health = health;
        }
        public int GetX()
        {
            return x;
        }
        public int GetY()
        {
            return y;
        }
        public Side GetSide()
        {
            return side;
        }

        public string GetName()
        {
            return name;
        }

        public int GetLevel()
        {
            return level;
        }

        public double GetDamage()
        {
            return damage;
        }

        public int GetSpeed()
        {
            return speed;
        }

        public int GetRange()
        {
            return range;
        }

        public Uri GetFileFolder()
        {
            return new Uri(fileFolder, UriKind.RelativeOrAbsolute);
        }

        public Uri GetFileFolderEnemy()
        {
            return new Uri(fileFolderEnemy, UriKind.RelativeOrAbsolute);
        }
        public Element GetElement()
        {
            return element;
        }

        public void SetX(int x)
        {
            this.x = x;
        }

        public void SetY(int y)
        {
            this.y = y;
        }
    }
}
