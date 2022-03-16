using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonBattle.Models.V1.Pokemon
{
    public class Stat
    {
        public int BaseStat { get; set; }
        public int Effort { get; set; }

        public StatData Data { get; set; }
    }
}
