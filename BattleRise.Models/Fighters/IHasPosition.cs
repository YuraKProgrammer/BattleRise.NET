﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.Models.Fighters
{
    public interface IHasPosition
    {
        int GetX();
        int GetY();
    }
}
