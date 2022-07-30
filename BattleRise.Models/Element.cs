using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models
{
    public enum Element
    {
        [Element("Огонь")]
        Fire,
        [Element("Земля")]
        Earth,
        [Element("Вода")]
        Water,
        [Element("Ветер")]
        Wind,
        [Element("Жизнь")]
        Life,
        [Element("Металл")]
        Metal,
        [Element("Энергия")]
        Energy,
        [Element("Сила")]
        Strength,
        [Element("Тень")]
        Shadow,
        [Element("Свет")]
        Light,
        [Element("Создание")]
        Creation,
        [Element("Разрушение")]
        Destruction,
        [Element("Восстановление")]
        Recovery,
        [Element("Случайность")]
        Random
    }
}
