using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokemonBattle.Models.V1.Pokemon
{
    public class Generation_IV
    {
        [JsonPropertyName("Diamond-Pearl")]
        public Diamond_Pearl_Sprites DiamondPearlSprites { get; set; }

        [JsonPropertyName("HeartGold-SoulSilver")]
        public HeartGold_SoulSilver_Sprites HeartGoldSoulSilverSprites { get; set; }

        [JsonPropertyName("Platinum")]
        public Platinum_Sprites PlatinumSprites { get; set; }
    }
}
