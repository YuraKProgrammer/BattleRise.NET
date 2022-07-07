﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models.Fighters
{
    public class Skeleton : IFighter
    {
        public string name { get; }
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
        public const string fileFolder = @"D:\images\4.jpg";

        public Skeleton(int level, int x, int y, Side side)
        {
            this.x = x;
            this.y = y;
            name = "Скелет";
            health = 5;
            damage = 2;
            speed = 2;
            range = 4;
            cost = 7;
            this.level = level;
            health = health * Math.Pow(1.1, level - 1);
            damage = damage * Math.Pow(1.1, level - 1);
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
                if (targetId != null && targetId > 0 && army.GetById(targetId) != null)
                {
                    StepToTarget(army.GetById(targetId));
                    if (GetRangeToTarget(army.GetById(targetId)) <= range)
                    {
                        if (isAttack == true)
                            isAttack = false;
                        if (isAttack == false && army.GetById(targetId).GetHealth() > 0)
                        {
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
            var angle = Math.Atan2(Math.Abs(y - fighter.GetY()), Math.Abs(x - fighter.GetX())) * (180 / Math.PI);
            var dx = speed * Math.Cos(angle);
            var dy = speed * Math.Sin(angle);
            x += (int)dx;
            y += (int)dy;
        }

        public int GetRangeToTarget(IFighter fighter)
        {
            var enemy = fighter;
            var range = (int)Math.Sqrt(x * x - enemy.GetX() * enemy.GetX() + (y * y - enemy.GetY() * enemy.GetY()));
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
    }
}