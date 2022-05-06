using PokemonBattle.Dto.Request;
using PokemonBattle.Dto.Response;
using PokemonBattle.Models.V1.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattle.Infrastructure.Repositories
{
    public interface IPokemonRepository
    {
        public Task<GetPokemonCollectionResponseDto> GetPokemonCollection(GetPokemonCollectionRequestDto request);

        public Task<GetPokemonResponseDto> GetPokemonById(GetPokemonRequestDto request);

        public Task<GetPokemonResponseDto> GetPokemonByName(GetPokemonRequestDto request);
    }
}
