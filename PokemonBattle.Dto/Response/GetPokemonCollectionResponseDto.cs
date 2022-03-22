using  PokemonBattle.Models.V1.Pokemon;

namespace PokemonBattle.Dto.Response
{
    public class GetPokemonCollectionResponseDto : BaseHttpResponseDto
    {
        public int Count { get; set; }

        public string Next { get; set; }

        public string Previous { get; set; }

        public Pokemon[] Results { get; set; }
    }
}
