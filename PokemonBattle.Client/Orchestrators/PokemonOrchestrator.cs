using PokemonBattle.Dto.Request;
using PokemonBattle.Dto.Response;
using PokemonBattle.Infrastructure.Repositories;
using PokemonBattle.Models.V1.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonBattle.Client.Orchestrators
{
    public class PokemonOrchestrator : IPokemonOrchestrator
    {
        private IPokemonRepository PokemonRepository;

        public PokemonOrchestrator(IPokemonRepository pokemonRepo)
        {
            PokemonRepository = pokemonRepo;
        }

        

        public async Task<GetPokemonResponseDto> GetPokemonById(GetPokemonRequestDto request)
        {
            try
            {
                var response = await PokemonRepository.GetPokemonById(request);
                return response;
            }
            catch (Exception ex)
            {
                var response = new GetPokemonResponseDto()
                {
                    Status = "500",
                    Message = "Error: Request for Pokemon by Id was invalid."
                };
                return response;
            }
        }

        public async Task<GetPokemonResponseDto> GetPokemonByName(GetPokemonRequestDto request)
        {
            try
            {
                var response = await PokemonRepository.GetPokemonByName(request);
                return response;
            }
            catch (Exception ex)
            {
                var response = new GetPokemonResponseDto()
                {
                    Status = "500",
                    Message = "Error: Request for Pokemon by Name was invalid."
                };
                return response;
            }
        }

        public async Task<PokemonCollection> GetPokemonCollection(GetPokemonCollectionRequestDto request)
        {
            try
            {
                var response = await PokemonRepository.GetPokemonCollection(request);
                var pokemonDataList = response.Results.Select(r => MapToPokemonData(PokemonRepository.GetPokemonByName(new GetPokemonRequestDto { PokemonName = r.Name }).Result)).ToList();
                var collection = new PokemonCollection(pokemonDataList);
                return collection;
            }
            catch (Exception ex)
            {
                var pokemonList = new List<PokemonData>();
                var collection = new PokemonCollection(pokemonList);
                return collection;
            }
        }

        private PokemonData MapToPokemonData(GetPokemonResponseDto response)
        {
            var pokemon = new PokemonData
            {
                Abilities = response.Abilities,
                Base_Experience = response.Base_Experience,
                Forms = response.Forms,
                Game_Indices = response.Game_Indices,
                Height = response.Height,
                Held_Items = response.Held_Items,
                Id = response.Id,
                Is_Default = response.Is_Default,
                Location_Area_Encounters = response.Location_Area_Encounters,
                Moves = response.Moves,
                Order = response.Order,
                Past_Types = response.Past_Types,
                Species = response.Species,
                Sprites = response.Sprites,
                Stats = response.Stats,
                Types = response.Types,
                Weight = response.Weight
            };

            return pokemon;
        }
    }
}
