﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plant_care._4_domain_code
{
    public abstract class Action
    {
        public abstract bool IsDue();
        public abstract bool IsOverdue();
        public abstract void Execute();
    }
}
