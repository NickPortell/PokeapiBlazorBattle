using Microsoft.AspNetCore.Components;
using PokemonBattle.Infrastructure.Repositories;
using PokemonBattle.Models.V1.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using System.IO;

namespace PokemonBattle.Server.Components.Classes.Shared
{
    public class PokemonDataBase : ComponentBase
    {
        public PokemonRepository PokemonRepository = new PokemonRepository();

        public PokemonCollection Pokedex { get; set; } = new PokemonCollection();

        public List<PokemonData> PokemonDataList { get; set; } = new List<PokemonData>();

        public List<PokemonData> PokemonTeam { get; set; } = new List<PokemonData>();

        public string SelectedPokeId { get; set; }

        public bool isInitialized;

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        public string DefaultTeamPokemonImgUrl = "Content\\PokeballEmptyOutline.png";
        public string DefaultPokemonImg = "data:image/png;base64,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";



        protected override async Task OnInitializedAsync()
        {
            Pokedex = await GetPokemonCollection();
            PokemonDataList = await GetPokemonDataList();
            PokemonTeam = GetTableData();
            isInitialized = Pokedex != null && PokemonDataList != null && PokemonTeam != null;
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

        //public string GetDefaultTeamPokemonImage(string path)
        //{
        //    string imgStream;

        //    using (var fileStream = new FileStream(path, FileMode.Open))
        //    {
        //        imgStream = fileStream.Read()
        //    }

        //        return ""
        //}
    }
}
