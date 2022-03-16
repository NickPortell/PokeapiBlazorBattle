using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonBattle.Models.V1.Pokemon
{
    public class VersionDetail
    {
        public int Rarity { get; set; }

        public GameVersion Version { get; set; }
    }
}
