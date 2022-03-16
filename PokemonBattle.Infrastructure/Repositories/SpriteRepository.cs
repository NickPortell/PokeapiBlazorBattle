using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PokemonBattle.Dto.Request;
using PokemonBattle.Dto.Response;
using PokemonBattle.Models.V1.Pokemon;

namespace PokemonBattle.Infrastructure.Repositories
{
    public class SpriteRepository
    {
        private HttpClient SpriteClient;
        public SpriteRepository()
        {
            // This should probably be initialized in Singleton scope?
            SpriteClient = new HttpClient();
            SpriteClient.BaseAddress = new Uri("https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon");
        }

        public async Task<GetPokemonBaseSpritesResponseDto> GetPokemonBaseSprites(GetPokemonBaseSpritesRequestDto request)
        {
            try
            {
                var response = new GetPokemonBaseSpritesResponseDto
                {
                    Back_Default = await SpriteClient.GetFromJsonAsync<string>(request.Back_Default),
                    Back_Female = await SpriteClient.GetFromJsonAsync<string>(request.Back_Female),
                    Back_Shiny = await SpriteClient.GetFromJsonAsync<string>(request.Back_Shiny),
                    Back_Shiny_Female = await SpriteClient.GetFromJsonAsync<string>(request.Back_Shiny_Female),
                    Front_Default = await SpriteClient.GetFromJsonAsync<string>(request.Front_Default),
                    Front_Female = await SpriteClient.GetFromJsonAsync<string>(request.Front_Female),
                    Front_Shiny = await SpriteClient.GetFromJsonAsync<string>(request.Front_Shiny),
                    Front_Shiny_Female = await SpriteClient.GetFromJsonAsync<string>(request.Front_Shiny_Female)
                };
                return response;
            }
            catch (Exception ex)
            {
                var response = new GetPokemonBaseSpritesResponseDto()
                {
                    Status = "500",
                    Message = "Error: Request for Pokemon by Id was invalid."
                };
                return response;
            }
        }

        public async Task<PokemonData> MapBaseSpritesToPokemonData(PokemonData pokemon)
        {
            var request = new GetPokemonBaseSpritesRequestDto
            {
                Back_Default = pokemon.Sprites.Back_Default,
                Back_Female = pokemon.Sprites.Back_Female,
                Back_Shiny = pokemon.Sprites.Back_Shiny,
                Back_Shiny_Female = pokemon.Sprites.Back_Shiny_Female,
                Front_Default = pokemon.Sprites.Front_Default,
                Front_Female = pokemon.Sprites.Front_Female,
                Front_Shiny = pokemon.Sprites.Front_Shiny,
                Front_Shiny_Female = pokemon.Sprites.Front_Shiny_Female
            };

            var response = await GetPokemonBaseSprites(request);

            pokemon.Sprites.Back_Default = response.Back_Default;
            pokemon.Sprites.Back_Female = response.Back_Female;
            pokemon.Sprites.Back_Shiny = response.Back_Shiny;
            pokemon.Sprites.Back_Shiny_Female = response.Back_Shiny_Female;
            pokemon.Sprites.Front_Default = response.Front_Default;
            pokemon.Sprites.Front_Female = response.Front_Female;
            pokemon.Sprites.Front_Shiny = response.Front_Shiny;
            pokemon.Sprites.Front_Shiny_Female = response.Front_Shiny_Female;

            return pokemon;
        }
    }
}
