using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokemonBattle.Models.V1.Pokemon
{
    public class OtherSprites
    {
        public DreamWorldSprites Dream_World { get; set; }
        public HomeSprites Home { get; set; }
        
        [JsonPropertyName("Official-Artwork")]
        public OfficialSprites Official_Artwork { get; set; }
    }
}
