using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonBattle.Models.V1.Pokemon
{
    public class HeldItem
    {
        public Item Data { get; set; }
        
        public VersionDetail[] VersionDetails { get; set; }
    }
}
