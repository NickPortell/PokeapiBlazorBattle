using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Web.UI.Dto.Request;
using Web.UI.Dto.Response;
using Web.UI.Models.Pokemon;

namespace Web.UI.PokeapiService.Repositories
{
    public class PokemonRepository
    {
        private HttpClient PokemonClient;

        public PokemonRepository()
        {
            // This should probably be initialized in Singleton scope?
            PokemonClient = new HttpClient();
            PokemonClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/pokemon");
        }

        public async Task<GetPokemonCollectionResponseDto> GetPokemonCollection(GetPokemonCollectionRequestDto request)
        {
            try
            {
                string requestString = PokemonClient.BaseAddress + $"?limit={request.Limit}&offset={request.Offset}";
                var response = await PokemonClient.GetFromJsonAsync<GetPokemonCollectionResponseDto>(requestString);
                return response;
            }
            catch (Exception ex)
            {
                var response = new GetPokemonCollectionResponseDto()
                {
                    Status = "500",
                    Message = "Error: Request for Pokemon Collection was invalid."
                };
                return response;
            }
        }
        
        public async Task<GetPokemonResponseDto> GetPokemonById(GetPokemonRequestDto request)
        {
            try
            {
                var response = await PokemonClient.GetFromJsonAsync<GetPokemonResponseDto>(PokemonClient.BaseAddress + $"/{request.PokemonId}");
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
                var response = await PokemonClient.GetFromJsonAsync<GetPokemonResponseDto>(PokemonClient.BaseAddress + $"/{request.PokemonName}");
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

        public async Task<PokemonCollection> MapPokemonCollection(int limit, int offset)
        {
            var request = new GetPokemonCollectionRequestDto
            {
                Limit = limit,
                Offset = offset
            };

            var response = await GetPokemonCollection(request);

            PokemonCollection collection = new PokemonCollection
            {
                Count = response.Count,
                Next = response.Next,
                Previous = response.Previous,
                Results = response.Results
            };

            return collection;
        }
        
        public async Task<PokemonData> MapPokemonToPokemonData(PokemonData pokemon)
        {
            var request = new GetPokemonRequestDto
            {
                PokemonId = pokemon.Id,
                PokemonName = pokemon.Name
            };

            var response = await GetPokemonByName(request);

            pokemon.Abilities = response.Abilities;
            pokemon.Base_Experience = response.Base_Experience;
            pokemon.Forms = response.Forms;
            pokemon.Game_Indices = response.Game_Indices;
            pokemon.Height = response.Height;
            pokemon.Held_Items = response.Held_Items;
            pokemon.Id = response.Id;
            pokemon.Is_Default = response.Is_Default;
            pokemon.Location_Area_Encounters = response.Location_Area_Encounters;
            pokemon.Moves = response.Moves;
            pokemon.Order = response.Order;
            pokemon.Past_Types = response.Past_Types;
            pokemon.Species = response.Species;
            pokemon.Sprites = response.Sprites;
            pokemon.Stats = response.Stats;
            pokemon.Types = response.Types;
            pokemon.Weight = response.Weight;

            return pokemon;
        }
    }
}
