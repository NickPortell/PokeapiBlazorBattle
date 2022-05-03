using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using PokemonBattle.Infrastructure.Repositories;
using PokemonBattle.Models.V1.Pokemon;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonBattle.Client.Components.Classes.Shared
{
    public class PokemonDataBase : ComponentBase
    {
        public PokemonRepository PokemonRepository = new PokemonRepository();

        public PokemonCollection Pokedex { get; set; } = new PokemonCollection();

        public List<PokemonData> PokemonDataList { get; set; } = new List<PokemonData>();

        public List<PokemonData> PokemonTeam { get; set; } = new List<PokemonData>();

        public PokemonData SelectedPokemon { get; set; }

        public string SelectedPokeSlotId { get; set; }

        public bool isInitialized;

        public bool DisplaySideTray;

        public string PokemonTeamContainerBaseClass { get; set; }
        public string PokemonTeamSlotBaseClass { get; set; }
        public string PokemonTeamImageBaseClass { get; set; }
        public string PokemonTeamNameBaseClass { get; set; }
        public string EmptyPokemonBaseClass { get; set; }

        public string ClickedClass = "Clicked";

        public List<string> PokemonTeamSlotClasses = new List<string>();
        public Dictionary<string, ElementReference> PokemonTeamSlotElements = new Dictionary<string, ElementReference>();

        public ElementReference SelectedPokemonSlot { get; set; }

        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        private IJSObjectReference JSModule;

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        public string DefaultTeamPokemonImgUrl = "Content\\PokeballEmptyOutline.png";
        public string DefaultPokemonImg = "Content\\MissingNo.png";


        protected override async Task OnInitializedAsync()
        {
            Pokedex = await GetPokemonCollection();
            PokemonDataList = await GetPokemonDataList();
            PokemonTeam = GetTableData();
            SetBaseClasses();
            SetPokemonTeamSlotClasses();
            JSModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./Scripts/TeamSelection.js");
            isInitialized = Pokedex != null && PokemonDataList != null && PokemonTeam != null;
            DisplaySideTray = SelectedPokemon != null;
        }

        public void SetBaseClasses()
        {
            PokemonTeamContainerBaseClass = "pokemon-team-container";
            PokemonTeamSlotBaseClass = "pokemon-team-slot";
            PokemonTeamImageBaseClass = "pokemon-team-img";
            PokemonTeamNameBaseClass = "pokemon-team-name";
            EmptyPokemonBaseClass = "empty-pokeball";
        }

        public void SetPokemonTeamSlotClasses()
        {
            for (int i = 0; i < PokemonTeam.Count; i++)
            {
                PokemonTeamSlotClasses.Add(PokemonTeamSlotBaseClass);
            }
        }

        public async Task<PokemonCollection> GetPokemonCollection()
        {
            bool localStorageHasPokeCollection = await LocalStorage.ContainKeyAsync("PokeCollection");
            if (localStorageHasPokeCollection)
            {
                var pokeCollectionLocally = await LocalStorage.GetItemAsync<PokemonCollection>("PokeCollection");

                if (pokeCollectionLocally == null)
                {
                    var mappedPokemon = await PokemonRepository.MapPokemonCollection(10, 10);
                    await LocalStorage.SetItemAsync("PokeCollection", mappedPokemon);
                }
            }
            else
            {
                var mappedPokemon = await PokemonRepository.MapPokemonCollection(10, 10);
                await LocalStorage.SetItemAsync("PokeCollection", mappedPokemon);
            }
            return await LocalStorage.GetItemAsync<PokemonCollection>("PokeCollection");
        }

        public async Task<List<PokemonData>> GetPokemonDataList()
        {
            bool localStorageHasPokemonDataList = await LocalStorage.ContainKeyAsync("PokemonDataList");
            if (localStorageHasPokemonDataList)
            {
                var pokemonDataList = await LocalStorage.GetItemAsync<List<PokemonData>>("PokemonDataList");

                if (pokemonDataList == null)
                {
                    var pokeData = await GetPokeData(Pokedex.Results);
                    await LocalStorage.SetItemAsync("PokemonDataList", pokeData);
                }
            }
            else
            {
                var pokeData = await GetPokeData(Pokedex.Results);
                await LocalStorage.SetItemAsync("PokemonDataList", pokeData);
            }
            return await LocalStorage.GetItemAsync<List<PokemonData>>("PokemonDataList");
        }

        public async Task<List<PokemonData>> GetPokeData(Pokemon[] pokemons)
        {
            List<PokemonData> pokemonDataList = new List<PokemonData>();

            foreach (var pokemon in pokemons)
            {
                PokemonData poke = new PokemonData
                {
                    Name = pokemon.Name
                };

                poke = await PokemonRepository.MapPokemonToPokemonData(poke);

                pokemonDataList.Add(poke);
            }

            return pokemonDataList;
        }

        protected List<PokemonData> GetTableData()
        {
            return GetSelectedTeam();
        }


        public List<PokemonData> GetSelectedTeam()
        {
            var pokeDataList = new List<PokemonData>()
            {
                PokemonDataList[0],
                null,
                PokemonDataList[2],
                PokemonDataList[3],
                null,
                null
            };
            return pokeDataList;
        }

        public async void ClickPokemon(ElementReference slot, string slotId, MouseEventArgs args)
        {            
            await JSRuntime.InvokeVoidAsync("deselectOtherTeamSlots", PokemonTeamSlotBaseClass, ClickedClass);
            await JSRuntime.InvokeVoidAsync("clickPokemonTeamSlot", slot, ClickedClass);
            SelectedPokeSlotId = slotId;
            SelectedPokemon = GetPokemonDataBySlotId(SelectedPokeSlotId);
        }

        private int GetPokemonIdFromSlotId(string slotId)
        {
            return int.Parse(slotId.Split('-')[0]);
        }

        public PokemonData GetPokemonDataBySlotId(string slotId)
        {
            return string.IsNullOrEmpty(slotId) || slotId.Contains("empty-slot") ? null : PokemonDataList.FirstOrDefault(p => p.Id == GetPokemonIdFromSlotId(slotId));
        }
    }
}
