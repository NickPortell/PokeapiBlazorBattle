using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokemonBattle.Models.V1.Pokemon
{
    public class VersionCollection
    {
        [JsonPropertyName("Generation-I")]
        public Generation_I Gen_I { get; set; }

        [JsonPropertyName("Generation-II")]
        public Generation_II Gen_II { get; set; }

        [JsonPropertyName("Generation-III")]
        public Generation_III Gen_III { get; set; }

        [JsonPropertyName("Generation-IV")]
        public Generation_IV Gen_IV { get; set; }

        [JsonPropertyName("Generation-V")]
        public Generation_V Gen_V { get; set; }

        [JsonPropertyName("Generation-VI")]
        public Generation_VI Gen_VI { get; set; }

        [JsonPropertyName("Generation-VII")]
        public Generation_VII Gen_VII { get; set; }

        [JsonPropertyName("Generation-VIII")]
        public Generation_VIII Gen_VIII { get; set; }
    }
}
