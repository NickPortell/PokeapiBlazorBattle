﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonBattle.Models.V1.Pokemon
{
    public class PokemonType
    {
        public int Slot { get; set; }

        public PokemonTypeData Type { get; set; }
    }
}
