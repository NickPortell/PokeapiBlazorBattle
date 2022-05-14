using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokemonBattle.Models.V1.Pokemon
{
    public class Generation_V
    {
        [JsonPropertyName("Black-White")]
        public Black_White_Sprites BlackWhiteSprites { get; set; }
    }
}
