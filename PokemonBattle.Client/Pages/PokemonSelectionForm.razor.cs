using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PokemonBattle.Client.Controllers;
using PokemonBattle.Client.StateManagement;
using PokemonBattle.Models.V1.Pokemon;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonBattle.Client.Pages
{
    public partial class PokemonSelectionForm : ComponentBase
    {
        [Parameter]
        public EventCallback<PokemonData> ChangePokemonSlot { get; set; }

        public string Pokemon { get; set; }

        public string DefaultPokemonImg = "Content\\MissingNo.png";

        [Inject]
        public StateManager State { get; set; }

        public PokemonData GetPokemonData(string pokemonName)
        {
            try 
            { 
                return State.Pokedex.PokemonList.Find(p => p.Name == Pokemon);
            }
            catch(ArgumentNullException e)
            {
                return null;
            }
        }

        public async void SwapPokemonInSlotWith(PokemonData pokemon, MouseEventArgs args)
        {
            await ChangePokemonSlot.InvokeAsync(pokemon);
        }
    }
}
