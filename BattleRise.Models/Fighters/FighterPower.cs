using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models.Fighters
{
    public enum FighterPower
    {
        [Power("Обычный")]
        Ordinary,
        [Power("Необычный")]
        Unusual,
        [Power("Редкий")]
        Rare,
        [Power("Эпический")]
        Epic,
        [Power("Легендарный")]
        Legendary,
        [Power("Божественный")]
        Divine
    }
}
