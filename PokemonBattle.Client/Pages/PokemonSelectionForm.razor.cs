using Microsoft.AspNetCore.Components;
using PokemonBattle.Client.Controllers;
using PokemonBattle.Client.StateManagement;
using PokemonBattle.Models.V1.Pokemon;
using System.Collections.Generic;

namespace PokemonBattle.Client.Pages
{
    public partial class PokemonSelectionForm : ComponentBase
    {
        [Parameter]
        public List<PokemonData> PokemonTeamData { get; set; }
        [Parameter]
        public List<PokemonData> PokemonList { get; set; }

        public PokemonData Pokemon { get; set; }

        public string DefaultPokemonImg = "Content\\MissingNo.png";

        [Inject]
        public StateManager GetState { get; set; }

    }
}
