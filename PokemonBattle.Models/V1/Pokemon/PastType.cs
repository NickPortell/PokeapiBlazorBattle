using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonBattle.Models.V1.Pokemon
{
    public class PastType
    {
        public Generation Generation { get; set; }

        public PokemonType[] Types { get; set; }
    }
}
