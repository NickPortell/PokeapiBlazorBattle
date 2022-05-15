using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonBattle.Models.V1.Pokemon
{
    public class VersionGroupData
    {
        public int Level_Learned_At { get; set; }

        public MethodData Move_Learn_Method { get; set; }

        public GameVersionGroup Version_Group { get; set; }
    }
}
