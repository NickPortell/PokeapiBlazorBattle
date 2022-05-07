using PokemonBattle.Models.V1.Pokemon;
using System.Collections.Generic;

namespace PokemonBattle.Client.StateManagement
{
    public class StateManager
    {
        public PokemonCollection Pokedex { get; set; }

        public List<PokemonData> PokemonTeam { get; set; }

    }
}
