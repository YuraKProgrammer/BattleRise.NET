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
            if (_fighters!=null && fighters!=null)
                _fighters.AddRange(fighters);
            if (fighters!=null)
                lastId=fighters.Count;
        }

        private List<IFighter> _fighters = new List<IFighter>();
        public IFighter GetById(int id)
        {
            return _fighters.Where(f => f.Id == id).FirstOrDefault();
        }
        public int GetArmySize()
        {
                return _fighters.Count;
        }

        public void AddFighter(IFighter fighter)
        {
            fighter.Id = lastId+1;
            lastId=lastId+1;
            _fighters.Add(fighter);
        }

        public void RemoveFighter(int id)
        {
            var fighter = _fighters.Where(f => f.Id == id).FirstOrDefault();
            _fighters.Remove(fighter);
        }

        public List<IFighter> GetFighters()
        {
            return _fighters;
        }

        public void UpdateFighter(IFighter fighter)
        {
            var id = fighter.Id;
            _fighters.Remove(_fighters.Where(f => f.Id == id).FirstOrDefault());
            _fighters.Add(fighter);
        }

        public void UpdateFighters(List<IFighter> fighters)
        {
            _fighters.Clear();
            _fighters.AddRange(fighters);
        }
    }
}
