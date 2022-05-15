using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokemonBattle.Models.V1.Pokemon
{
    public class Ability
    {
        [JsonPropertyName("Ability")]
        public AbilityData AbilityData { get; set; }

        public bool Is_Hidden { get; set; }

        public int Slot { get; set; }
    }
}
