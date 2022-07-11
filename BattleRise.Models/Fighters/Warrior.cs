using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models.Fighters
{
    public class Warrior : IFighter
    {
        public string name { get; }
        public int id { get; set; }
        public double health { get; set; }
        public double damage { get; }
        public int speed { get; }
        public int range { get; }
        public int cost { get; }
        public int targetId = 0;
        private int level { get; }
        public int x { get; set; }
        public int y { get; set; }
        public bool isAttack;
        public Side side { get; }
        public const string fileFolder = @"D:\images\1.jpg";
        public const string fileFolderEnemy = @"D:\images\1.2.jpg";

        public Warrior(int level, int x, int y, Side side)
        {
            this.x = x;
            this.y = y;
            name = "Солдат";
            health = 10;
            damage = 3;
            speed = 4;
            range = 20;
            cost = 10;
            this.level = level;
            health = health * Math.Pow(1.1, level - 1);
            damage = damage * Math.Pow(1.1, level - 1);
            this.side = side;
        }
        public IFighter Active(Army army)
        {
            if (army != null)
            {
                if (targetId == 0 || army.GetById(targetId)==null)
                {
                    SelectTarget(army);
                }
                if (targetId > 0 && army.GetById(targetId) != null)
                {
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
            enemy.SetHealth(enemy.GetHealth() - damage);
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
                targetId = fighter.GetId();
            else
                targetId = 0;
        }

        public void StepToTarget(IFighter fighter)
        {
            var angle = Math.Atan2(y - fighter.GetY(), x - fighter.GetX()) * (180 / Math.PI);
            var dx = speed * Math.Cos(angle);
            var dy = speed * Math.Sin(angle);
            x += (int)dx;
            y += (int)dy;
        }

        public int GetRangeToTarget(IFighter fighter)
        {
            var enemy = fighter;
            var range = (int)Math.Sqrt(Math.Abs(x * x - enemy.GetX() * enemy.GetX()) + Math.Abs(y * y - enemy.GetY() * enemy.GetY()));
            return range;
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
        public int GetId()
        {
            return id;
        }

        public void SetId(int id)
        {
            this.id = id;
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

        public string GetFileFolder()
        {
            return fileFolder;
        }

        public string GetFileFolderEnemy()
        {
            return fileFolderEnemy;
        }
    }
}
