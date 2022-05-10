using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonBattle.Models.V1.Pokemon
{
    public class Statistic
    {
        public int Base_Stat { get; set; }
        public int Effort { get; set; }

        public StatData Stat { get; set; }
    }
}
