using PokemonBattle.Dto.Request;
using PokemonBattle.Dto.Response;
using PokemonBattle.Models.V1.Pokemon;
using System.Threading.Tasks;

namespace PokemonBattle.Client.Orchestrators
{
    public interface IPokemonOrchestrator
    {

        public Task<PokemonCollection> GetPokemonCollection(GetPokemonCollectionRequestDto request);

        public Task<GetPokemonResponseDto> GetPokemonById(GetPokemonRequestDto request);

        public Task<GetPokemonResponseDto> GetPokemonByName(GetPokemonRequestDto request);

    }
}
