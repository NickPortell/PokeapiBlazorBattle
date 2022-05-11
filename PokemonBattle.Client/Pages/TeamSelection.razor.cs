using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using PokemonBattle.Client.Controllers;
using PokemonBattle.Client.StateManagement;
using PokemonBattle.Dto.Request;
using PokemonBattle.Models.V1.Pokemon;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonBattle.Client.Pages
{
    public partial class TeamSelection : ComponentBase
    {
        public Dictionary<string, ElementReference> PokemonTeamSlotElements { get; set; }

        public string ClickedClass { get; set; }

        public bool isInitialized;


        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        private PokemonController PokemonController { get; set; }

        [Inject]
        public StateManager state { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var request = new GetPokemonCollectionRequestDto
            {
                Limit = 10,
                Offset = 10
            };

            state.Pokedex = await GetPokemonCollection(request);
            state.PokemonTeam = GetSelectedTeam();
            PokemonTeamSlotElements = PokemonTeamSlotElements == null
                                      ? new Dictionary<string, ElementReference>()
                                      : PokemonTeamSlotElements;
            state.PokemonTeamSlotClasses = state.PokemonTeamSlotClasses == null ? GetTeamSlotClasses() : state.PokemonTeamSlotClasses;
            ClickedClass = "Clicked";
            isInitialized = state.Pokedex != null && state.PokemonTeam != null;
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
            state.SelectedPokemon = pokemon;
        }

        public List<PokemonData> GetSelectedTeam()
        {
            var pokemonTeam = new List<PokemonData>()
            {
                state.Pokedex.PokemonList[0],
                null,
                state.Pokedex.PokemonList[2],
                state.Pokedex.PokemonList[3],
                null,
                null
            };
            return pokemonTeam;
        }

        public List<string> GetTeamSlotClasses()
        {
            List<string> teamSlotClasses = new List<string>();

            foreach (var pokemon in state.PokemonTeam)
            {
                teamSlotClasses.Add(SetSlotBaseClass(""));
            }
            return teamSlotClasses;
        }

        private string SetSlotBaseClass(string classList)
        {
            return string.IsNullOrEmpty(classList) ? state.PokemonTeamSlotBaseClass : classList;
        }

        public void ClickTeamSlot(int slotIndex)
        {
            ClearClickedFromClassList(slotIndex);

            List<string> classList = state.PokemonTeamSlotClasses[slotIndex].Split(' ').ToList();
            if (!classList.Contains(ClickedClass))
            {
                classList.Add(ClickedClass);
            }
            else
            {
                classList.Remove(ClickedClass);
                state.SelectedPokemon = null;
            }
            state.PokemonTeamSlotClasses[slotIndex] = string.Join(' ', classList);
        }

        private void ClearClickedFromClassList(int slotIndexToAvoid)
        {
            for (int i = 0; i < state.PokemonTeamSlotClasses.Count; i++)
            {
                if (state.PokemonTeamSlotClasses[i].Contains(ClickedClass) && i != slotIndexToAvoid)
                {
                    List<string> classList = state.PokemonTeamSlotClasses[i].Split(' ').ToList();
                    classList.Remove(ClickedClass);
                    state.PokemonTeamSlotClasses[i] = string.Join(' ', classList);
                }
            }
        }
    }
}
