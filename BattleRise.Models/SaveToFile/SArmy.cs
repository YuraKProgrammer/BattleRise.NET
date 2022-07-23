using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models.SaveToFile
{
    public class SArmy
    {
        public int lastId = 0;

        public SArmy(List<SFighter> fighters)
        {
            _fighters = fighters;
            if (fighters != null)
                lastId = fighters.Count;
        }

        private List<SFighter> _fighters;
        public SFighter GetById(int id)
        {
            return _fighters.Where(f => f.id == id).FirstOrDefault();
        }
        public int GetArmySize()
        {
            if (_fighters != null)
            {
                return _fighters.Count;
            }
            else
            {
                _fighters = new List<SFighter>();
                return _fighters.Count;
            }
        }

        public void AddFighter(SFighter fighter)
        {
            if (_fighters == null)
            {
                _fighters = new List<SFighter>();
            }
            fighter.id = lastId + 1;
            lastId = lastId + 1;
            _fighters.Add(fighter);
        }

        public void RemoveFighter(int id)
        {
            var fighter = _fighters.Where(f => f.id == id).FirstOrDefault();
            _fighters.Remove(fighter);
        }

        public List<SFighter> GetFighters()
        {
            return _fighters;
        }

        public void UpdateFighter(SFighter fighter)
        {
            var id = fighter.id;
            _fighters.Remove(_fighters.Where(f => f.id == id).FirstOrDefault());
            _fighters.Add(fighter);
        }

        public void UpdateFighters(List<SFighter> fighters)
        {
            _fighters = fighters;
        }
    }
}
