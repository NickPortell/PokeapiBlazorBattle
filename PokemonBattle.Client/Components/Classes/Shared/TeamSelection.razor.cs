using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PokemonBattle.Client.Controllers;
using PokemonBattle.Dto.Request;
using PokemonBattle.Models.V1.Pokemon;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonBattle.Client.Components.Classes.Shared
{
    public class TeamSelection : ComponentBase
    {
        public PokemonData SelectedPokemon { get; set; }
        public PokemonCollection Pokedex { get; set; }

        public List<PokemonData> PokemonTeam { get; set; }

        public bool isInitialized;

        public string PokemonTeamContainerBaseClass => "pokemon-team-container";
        public string PokemonTeamSlotBaseClass => "pokemon-team-slot";
        public string PokemonTeamImageBaseClass => "pokemon-team-img";
        public string PokemonTeamNameBaseClass => "pokemon-team-name";
        public string EmptyPokemonBaseClass => "empty-pokeball";



        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        private PokemonController PokemonController { get; set; }


        protected override async Task OnInitializedAsync()
        {
            var request = new GetPokemonCollectionRequestDto
            {
                Limit = 10,
                Offset = 10
            };

            Pokedex = await GetPokemonCollection(request);
            PokemonTeam = GetSelectedTeam();
            isInitialized = Pokedex != null && PokemonTeam != null;
        }

        private async Task<PokemonCollection> GetPokemonCollection(GetPokemonCollectionRequestDto request)
        {
            bool localStorageHasPokeCollection = await LocalStorage.ContainKeyAsync("Pokedex");
            if (localStorageHasPokeCollection)
            {
                var pokeCollectionLocally = await LocalStorage.GetItemAsync<PokemonCollection>("Pokedex");

                if (pokeCollectionLocally.PokemonList == null || pokeCollectionLocally.PokemonList.Count < 1)
                {
                    var response = await PokemonController.GetPokemonCollection(request);
                    await LocalStorage.SetItemAsync("Pokedex", response);
                }
            }
            else
            {
                var response = await PokemonController.GetPokemonCollection(request);
                await LocalStorage.SetItemAsync("Pokedex", response);
            }
            return await LocalStorage.GetItemAsync<PokemonCollection>("Pokedex");
        }

        public void SelectPokemon(PokemonData pokemon)
        {
            SelectedPokemon = pokemon;
        }

        public List<PokemonData> GetSelectedTeam()
        {
            var pokemonTeam = new List<PokemonData>()
            {
                Pokedex.PokemonList[0],
                null,
                Pokedex.PokemonList[2],
                Pokedex.PokemonList[3],
                null,
                null
            };
            return pokemonTeam;
        }
    }
}
