using System;
using System.Threading.Tasks;
using Web.UI.Dto.Request;
using Web.UI.Dto.Response;
using System.Net.Http.Json;
using System.Net.Http;

namespace Web.UI.PokeapiService.Repositories
{
    public class PokemonRepository
    {
        private HttpClient PokemonClient;

        public PokemonRepository()
        {
            // This should probably be initialized in Singleton scope?
            PokemonClient = new HttpClient();
            PokemonClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
        }

        public async Task<GetPokemonResponseDto> GetPokemonById(GetPokemonRequestDto request)
        {
            try
            {
                var response = await PokemonClient.GetFromJsonAsync<GetPokemonResponseDto>(PokemonClient.BaseAddress + $"pokemon/{request.PokemonId}");
                return response;
            }
            catch (Exception)
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
                var response = await PokemonClient.GetFromJsonAsync<GetPokemonResponseDto>(PokemonClient.BaseAddress + $"pokemon/{request.PokemonName}");
                return response;
            }
            catch (Exception)
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
