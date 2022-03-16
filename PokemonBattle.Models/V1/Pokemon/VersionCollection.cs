using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonBattle.Models.V1.Pokemon
{
    public class VersionCollection
    {
        public Generation_I Gen_I { get; set; }
        public Generation_II Gen_II { get; set; }
        public Generation_III Gen_III { get; set; }
        public Generation_IV Gen_IV { get; set; }
        public Generation_V Gen_V { get; set; }
        public Generation_VI Gen_VI { get; set; }
        public Generation_VII Gen_VII { get; set; }
        public Generation_VIII Gen_VIII { get; set; }
    }
}
