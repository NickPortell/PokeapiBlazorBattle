using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.UI.Models.Pokemon
{
    public class PastType
    {
        public Generation Gen { get; set; }

        public PokemonType[] Types { get; set; }
    }
}
