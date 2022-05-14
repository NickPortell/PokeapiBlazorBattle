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
        public StateManager State { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var request = new GetPokemonCollectionRequestDto
            {
                Limit = 10,
                Offset = 10
            };

            State.Pokedex = await GetPokemonCollection(request);
            State.PokemonTeam = await GetSelectedTeam();
            PokemonTeamSlotElements = PokemonTeamSlotElements == null
                                      ? new Dictionary<string, ElementReference>()
                                      : PokemonTeamSlotElements;
            State.PokemonTeamSlotClasses = State.PokemonTeamSlotClasses == null ? GetTeamSlotClasses() : State.PokemonTeamSlotClasses;
            ClickedClass = "Clicked";
            isInitialized = State.Pokedex != null && State.PokemonTeam != null;
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
            State.SelectedPokemon = pokemon;
        }

        public async void ChangePokemonSlot(PokemonData pokemon)
        {
            State.PokemonTeam[State.SelectedSlotIndex] = pokemon;
            State.SelectedPokemon = pokemon;
            await LocalStorage.SetItemAsync<List<PokemonData>>("PokemonTeam", State.PokemonTeam);
            ShouldRender();
        }

        public async Task<List<PokemonData>> GetSelectedTeam()
        {
            var teamLocally = await LocalStorage.GetItemAsync<List<PokemonData>>("PokemonTeam");

            if (teamLocally == null || teamLocally.Count < 6)
            {
                if (State.PokemonTeam != null && State.PokemonTeam.Count == 6)
                {
                    await LocalStorage.SetItemAsync<List<PokemonData>>("PokemonTeam", State.PokemonTeam);
                    teamLocally = State.PokemonTeam;
                }
                else
                {
                    teamLocally = new List<PokemonData>()
                    {
                        null,
                        null,
                        null,
                        null,
                        null,
                        null
                    };
                    await LocalStorage.SetItemAsync<List<PokemonData>>("PokemonTeam", teamLocally);
                }
            }

            if (State.PokemonTeam == null || State.PokemonTeam.Count < 6)
            {
                State.PokemonTeam = await LocalStorage.GetItemAsync<List<PokemonData>>("PokemonTeam");
            }
            else if (State.PokemonTeam.Select(p => p != null && teamLocally.Contains(p) && (State.PokemonTeam.IndexOf(p) == teamLocally.IndexOf(p))).Contains(false))
            {
                await LocalStorage.SetItemAsync<List<PokemonData>>("PokemonTeam", State.PokemonTeam);
            }

            return State.PokemonTeam;
        }

        public List<string> GetTeamSlotClasses()
        {
            List<string> teamSlotClasses = new List<string>();

            foreach (var pokemon in State.PokemonTeam)
            {
                teamSlotClasses.Add(SetSlotBaseClass(""));
            }
            return teamSlotClasses;
        }

        private string SetSlotBaseClass(string classList)
        {
            return string.IsNullOrEmpty(classList) ? State.PokemonTeamSlotBaseClass : classList;
        }

        public void ClickTeamSlot(int slotIndex)
        {
            ClearClickedFromClassList(slotIndex);

            List<string> classList = State.PokemonTeamSlotClasses[slotIndex].Split(' ').ToList();
            if (!classList.Contains(ClickedClass))
            {
                classList.Add(ClickedClass);
            }
            else
            {
                classList.Remove(ClickedClass);
                State.SelectedPokemon = null;
            }
            State.PokemonTeamSlotClasses[slotIndex] = string.Join(' ', classList);
            State.SelectedSlotIndex = slotIndex;
        }

        private void ClearClickedFromClassList(int slotIndexToAvoid)
        {
            for (int i = 0; i < State.PokemonTeamSlotClasses.Count; i++)
            {
                if (State.PokemonTeamSlotClasses[i].Contains(ClickedClass) && i != slotIndexToAvoid)
                {
                    List<string> classList = State.PokemonTeamSlotClasses[i].Split(' ').ToList();
                    classList.Remove(ClickedClass);
                    State.PokemonTeamSlotClasses[i] = string.Join(' ', classList);
                }
            }
        }
    }
}
