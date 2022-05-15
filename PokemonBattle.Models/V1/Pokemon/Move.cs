using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokemonBattle.Models.V1.Pokemon
{
    public class Move
    {
        [JsonPropertyName("Move")]
        public MoveData MoveData { get; set; }

        public VersionGroupData[] Version_Group_Details { get; set; }
    }
}
