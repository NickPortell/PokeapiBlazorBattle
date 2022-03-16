using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonBattle.Models.V1.Pokemon
{
    public class Move
    {
        public MoveData Data { get; set; }

        public VersionGroupData[] VersionGroupDetails { get; set; }
    }
}
