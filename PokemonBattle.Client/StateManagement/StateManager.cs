using PokemonBattle.Models.V1.Pokemon;
using System.Collections.Generic;

namespace PokemonBattle.Client.StateManagement
{
    public class StateManager
    {
        public PokemonCollection Pokedex { get; set; }

        public List<PokemonData> PokemonTeam { get; set; }

        public List<string> PokemonTeamSlotClasses { get; set; }


        public string PokemonTeamContainerBaseClass => "pokemon-team-container";
        public string PokemonTeamSlotBaseClass => "pokemon-team-slot";
        public string PokemonTeamImageBaseClass => "pokemon-team-img";
        public string PokemonTeamNameBaseClass => "pokemon-team-name";
        public string EmptyPokemonBaseClass => "empty-pokeball";

        public PokemonData SelectedPokemon { get; set; }
        public int SelectedSlotIndex { get; set; }
    }
}
