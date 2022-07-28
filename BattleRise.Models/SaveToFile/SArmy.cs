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
            var fl = _fighters.ToList();
            fl.AddRange(fighters);
            _fighters = fl.ToArray();
            if (fighters != null)
                lastId = fighters.Count();
        }

        private readonly SFighter[] _fighters = new SFighter[] { };
        public SFighter GetById(int id)
        {
            return _fighters.Where(f => f.id == id).FirstOrDefault();
        }
        public int GetArmySize()
        {
                return _fighters.Length;
        }
        public List<SFighter> GetFighters()
        {
            return _fighters.ToList();
        }
    }
}
