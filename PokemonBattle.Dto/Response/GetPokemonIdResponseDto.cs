using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattle.Dto.Response
{
    public class GetPokemonIdResponseDto : BaseHttpResponseDto
    {
        public int Id { get; set; }
    }
}
