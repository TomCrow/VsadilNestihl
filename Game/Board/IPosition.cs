﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.Game.Board
{
    public interface IPosition
    {
        IPlace GetPlace();
        int GetPositionId();
        string GetName();
    }
}
