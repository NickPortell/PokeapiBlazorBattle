﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.UI.Models.Pokemon
{
    public class Stat
    {
        public int BaseStat { get; set; }
        public int Effort { get; set; }

        public StatData Data { get; set; }
    }
}
