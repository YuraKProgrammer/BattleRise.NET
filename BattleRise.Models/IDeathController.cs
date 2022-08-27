using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models
{
    public interface IDeathController
    {
        public Army Control(Army army);
    }
}
