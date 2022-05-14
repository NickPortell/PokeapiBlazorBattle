using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokemonBattle.Models.V1.Pokemon
{
    public class Generation_VII
    {
        public Icons Icons { get; set; }

        [JsonPropertyName("Ultra-Sun-Ultra-Moon")]
        public UltraSun_UltraMoon_Sprites UltraSunUltraMoonSprites { get; set; }
    }
}
