using BattleRise.Models.Fighters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models
{
    public class ElementDamageController
    {
        public double Control(IFighter attacking, IFighter attacked)
        {
            var e1 = attacking.GetElement();
            var e2 = attacked.GetElement();
            var d = attacking.GetDamage();
            if ((e1 == Element.Fire && e2 == Element.Water) || (e1 == Element.Water && e2 == Element.Fire)) //Огонь>Вода Вода>Огонь
                d = d * 1.1;
            if ((e1 == Element.Light && e2 == Element.Shadow) || (e1 == Element.Shadow && e2 == Element.Light)) //Свет>Тень Тень>Свет
                d = d * 1.1;
            if (e1 == Element.Random && e2 != Element.Random) //Случайность>Все/Случайность
                d = d * 1.1;
            if ((e1 == Element.Destruction && e2 == Element.Creation) || (e1 == Element.Creation && e2 == Element.Destruction)) //Разрушение>Создание Создание>Разрушение
                d = d * 1.1;
            if ((e1 == Element.Destruction && e2 == Element.Recovery) || (e1 == Element.Recovery && e2 == Element.Destruction)) //Разрушение>Восстановление Восстановление>Разрушение
                d = d * 1.1;
            if ((e1 == Element.Metal && e2 == Element.Life) || (e1 == Element.Life && e2 == Element.Metal)) //Металл>Жизнь Жизнь>Металл
                d = d * 1.1;
            if ((e1 == Element.Metal && e2 == Element.Energy) || (e1 == Element.Energy && e2 == Element.Metal)) //Металл<Энергия Энергия<Металл
                d = d / 1.1;
            if (e1 == Element.Wind && (e2 == Element.Earth || e2 == Element.Fire)) //Ветер>Земля Ветер>Огонь
                d = d * 1.1;
            if (e1 == Element.Strength && (e2 == Element.Energy || e2 == Element.Wind || e2 == Element.Water)) //Сила>Энергия Сила>Ветер Сила>Вода 
                d = d * 1.1;
            if ((e1 == Element.Water && e2 == Element.Life) || (e1 == Element.Life && e2 == Element.Water)) //Металл<Энергия Энергия<Металл
                d = d / 1.1;
            //Продолжение должно быть!
            return d;
        }
    }
}
