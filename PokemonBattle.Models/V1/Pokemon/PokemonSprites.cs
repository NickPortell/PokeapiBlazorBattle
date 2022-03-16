using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonBattle.Models.Pokemon
{
    public class PokemonSprites
    {
        public string Back_Default { get; set; }

        public string Back_Female { get; set; }

        public string Back_Shiny { get; set; }

        public string Back_Shiny_Female { get; set; }

        public string Front_Default { get; set; }

        public string Front_Female { get; set; }

        public string Front_Shiny { get; set; }

        public string Front_Shiny_Female { get; set; }

        public OtherSprites Other { get; set; }

        public VersionCollection Versions { get; set; }


    }
}
