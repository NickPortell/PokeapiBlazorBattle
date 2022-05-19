using PokemonBattle.Models.V1.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattle.Dto.Response
{
    public class GetPokemonBaseStatsResponseDto : BaseHttpResponseDto
    {
        public Statistic[] Stats { get; set; }
    }
}
