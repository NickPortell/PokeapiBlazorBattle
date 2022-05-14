using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokemonBattle.Models.V1.Pokemon
{
    public class Generation_III
    {
        [JsonPropertyName("Emerald")]
        public Emerald_Sprites EmeraldSprites { get; set; }

        [JsonPropertyName("FireRed-LeafGreen")]
        public FireRed_LeafGreen_Sprites FireRedLeafGreenSprites { get; set; }

        [JsonPropertyName("Ruby-Sapphire")]
        public Ruby_Sapphire_Sprites RubySapphireSprites { get; set; }
    }
}
