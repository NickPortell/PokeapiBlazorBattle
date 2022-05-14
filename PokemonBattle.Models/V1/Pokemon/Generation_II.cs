using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokemonBattle.Models.V1.Pokemon
{
    public class Generation_II
    {
        [JsonPropertyName("Crystal")]
        public Crystal_Sprites CrystalSprites { get; set; }

        [JsonPropertyName("Gold")]
        public Gold_Sprites GoldSprites { get; set; }

        [JsonPropertyName("Silver")]
        public Silver_Sprites SilverSprites { get; set; }
    }
}
