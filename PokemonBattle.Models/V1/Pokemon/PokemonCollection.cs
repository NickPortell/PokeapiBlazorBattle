using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonBattle.Models.V1.Pokemon
{
    public class PokemonCollection
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public Pokemon[] Results { get; set; }
    }
}
