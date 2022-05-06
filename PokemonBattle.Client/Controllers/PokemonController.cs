using PokemonBattle.Client.Orchestrators;
using PokemonBattle.Dto.Request;
using PokemonBattle.Dto.Response;
using PokemonBattle.Models.V1.Pokemon;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PokemonBattle.Client.Controllers
{
    public class PokemonController : Controller
    {
        private IPokemonOrchestrator PokemonOrchestrator;

        public PokemonController(IPokemonOrchestrator pokemonOrchestrator)
        {
            PokemonOrchestrator = pokemonOrchestrator;
        }

        public async Task<PokemonCollection> GetPokemonCollection(GetPokemonCollectionRequestDto request)
        {
            try
            {
                var response = await PokemonOrchestrator.GetPokemonCollection(request);
                return response;
            }
            catch (Exception ex)
            {
                var response = new PokemonCollection(new List<PokemonData>());
                return response;
            }
        }

        public async Task<GetPokemonResponseDto> GetPokemonById(GetPokemonRequestDto request)
        {
            try
            {
                var response = await PokemonOrchestrator.GetPokemonById(request);
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
                var response = await PokemonOrchestrator.GetPokemonByName(request);
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
