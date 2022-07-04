using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models
{
    internal class Warrior : IFighter
    {
        public int id { get; set; }
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

        public Warrior(int level, int x, int y, Side side)
        {
            this.x = x;
            this.y = y;
            health = 10;
            damage = 3;
            speed = 2;
            range = 1;
            cost = 10;
            level = 1;
            this.level = level;
            this.health = health * Math.Pow(1.1, level - 1);
            this.damage = damage * Math.Pow(1.1, level - 1);
            this.side = side;
        }
        public IFighter Active(Army army)
        {
           if (army != null)
            {
                if (targetId == null)
                {
                    SelectTarget(army);
                }
                if (targetId != null && targetId > 0 && army.GetById(targetId)!=null)
                {
                    StepToTarget(army.GetById(targetId));
                    if (GetRangeToTarget(army.GetById(targetId)) <= range)
                    {
                        if (isAttack == true)
                            isAttack = false;
                        if (isAttack == false && army.GetById(targetId).GetHealth()>0){
                            isAttack = true;
                            var attackedEnemy = Attack(army);
                            return attackedEnemy;
                        }
                    }
                }
            }
            return null;
        }

        public IFighter Attack(Army army)
        {
            var enemy = army.GetById(targetId);
            enemy.SetHealth(enemy.GetHealth() - damage);
            return enemy;
        }

        public void SelectTarget(Army army)
        {
            var min = 1000000;
            IFighter minTarget = null;
            for (int i = 0; i < army.GetArmySize(); i++)
            {
                if (army.GetById(i).GetSide() == Side.Enemy) 
                {
                    var enemy = army.GetById(i);
                    var range = GetRangeToTarget(enemy);
                    if (range < min)
                    {
                        min = range;
                        minTarget = enemy;
                    }
                }
            }
            targetId = minTarget.GetId();
        }

        public void StepToTarget(IFighter fighter)
        {
            var angle = Math.Atan2(Math.Abs(y - fighter.GetY()),Math.Abs(x - fighter.GetX())) * (180/Math.PI);
            var dx = speed * Math.Cos(angle);
            var dy = speed * Math.Sin(angle);
            x+=(int)dx;
            y+=(int)dy;
        }

        public int GetRangeToTarget(IFighter fighter)
        {
            var enemy = fighter;
            var range = (int)Math.Sqrt((x * x - enemy.GetX() * enemy.GetX()) + (y * y - enemy.GetY() * enemy.GetY()));
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
    }
}
