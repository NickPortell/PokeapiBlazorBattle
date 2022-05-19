using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattle.Dto.Request
{
    public class GetPokemonBaseStatsRequestDto
    {
        public string Name { get; set; }

        public int Id { get; set; }
    }
}
