using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonBattle.Models.V1.Pokemon
{
    public class PokemonCollection
    {
        public List<PokemonData> PokemonList { get; set; }

        public PokemonCollection(List<PokemonData> pokemonList)
        {
            PokemonList = pokemonList;
        }
    }
}
