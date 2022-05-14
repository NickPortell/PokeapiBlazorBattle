using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokemonBattle.Models.V1.Pokemon
{
    public class Generation_VI
    {
        [JsonPropertyName("OmegaRuby-AlphaSapphire")]
        public OmegaRuby_AlphaSapphire_Sprites OmegaRubyAlphaSapphireSprites { get; set; }

        [JsonPropertyName("X-Y")]
        public X_Y_Sprites XYSprites { get; set; }
    }
}
