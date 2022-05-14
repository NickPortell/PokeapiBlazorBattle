using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokemonBattle.Models.V1.Pokemon
{
    public class Generation_I
    {
        [JsonPropertyName("Red-Blue")]
        public Red_Blue_Sprites RedBlueSprites { get; set; }

        [JsonPropertyName("Yellow")]
        public Yellow_Sprites YellowSprites { get; set; }
    }
}
