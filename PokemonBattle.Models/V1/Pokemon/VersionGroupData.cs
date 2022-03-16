using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonBattle.Models.Pokemon
{
    public class VersionGroupData
    {
        public int LevelLearned { get; set; }

        public MethodData Method { get; set; }

        public GameVersionGroup VersionGroup { get; set; }
    }
}
