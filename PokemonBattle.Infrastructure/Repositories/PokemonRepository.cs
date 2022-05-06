using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PokemonBattle.Dto.Request;
using PokemonBattle.Dto.Response;
using PokemonBattle.Models.V1.Pokemon;

namespace PokemonBattle.Infrastructure.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private HttpClient PokemonClient;

        public PokemonRepository(HttpClient pokemonClient)
        {
            // This should probably be initialized in Singleton scope?
            PokemonClient = pokemonClient;
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
        
       
    }
}
