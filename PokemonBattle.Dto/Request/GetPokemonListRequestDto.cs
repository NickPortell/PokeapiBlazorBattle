using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattle.Dto.Request
{
    public class GetPokemonListRequestDto
    {
        public int Limit { get; set; }

        public int Offset { get; set; }
    }
}
