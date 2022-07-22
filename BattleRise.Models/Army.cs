using BattleRise.Models.Fighters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models
{
    public class Army
    {
        public int lastId = 0;

        public Army(List<IFighter> fighters)
        {
            _fighters= fighters;
            if (fighters!=null)
                lastId=fighters.Count;
        }

        public static Army UnitArmies(Army army1, Army army2)
        {
            var f1 = army1.GetFighters();
            var f2 = army2.GetFighters();
            var f3 = new List<IFighter>();
            for (int i = 1; i <= f1.Count; i++)
            {
                var f = f1[i-1];
                f.SetId(i);
                f3.Add(f);
            }
            for (int j = f1.Count+1; j <= f2.Count; j++)
            {
                var f = f2[j - f1.Count()-1];
                f.SetId(j);
                f3.Add(f);
            }
            return new Army(f3);
        }

        private List<IFighter> _fighters;
        public IFighter GetById(int id)
        {
            return _fighters.Where(f => f.GetId() == id).FirstOrDefault();
        }
        public int GetArmySize()
        {
            if (_fighters != null)
            {
                return _fighters.Count;
            }
            else
            {
                _fighters=new List<IFighter>();
                return _fighters.Count;
            }
        }

        public void AddFighter(IFighter fighter)
        {
            if (_fighters == null)
            {
                _fighters = new List<IFighter>();
            }
            fighter.SetId(lastId+1);
            lastId=lastId+1;
            _fighters.Add(fighter);
        }

        public void RemoveFighter(int id)
        {
            var fighter = _fighters.Where(f => f.GetId() == id).FirstOrDefault();
            _fighters.Remove(fighter);
        }

        public List<IFighter> GetFighters()
        {
            return _fighters;
        }

        public void UpdateFighter(IFighter fighter)
        {
            var id = fighter.GetId();
            _fighters.Remove(_fighters.Where(f => f.GetId() == id).FirstOrDefault());
            _fighters.Add(fighter);
        }

        public void UpdateFighters(List<IFighter> fighters)
        {
            _fighters = fighters;
        }
    }
}
