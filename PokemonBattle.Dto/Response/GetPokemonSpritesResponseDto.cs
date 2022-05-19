using PokemonBattle.Models.V1.Pokemon;

namespace PokemonBattle.Dto.Response
{
    public class GetPokemonSpritesResponseDto : BaseHttpResponseDto
    {
        public PokemonSprites Sprites { get; set; }
    }
}
