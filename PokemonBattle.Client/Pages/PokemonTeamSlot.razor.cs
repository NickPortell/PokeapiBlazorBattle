using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using PokemonBattle.Client.StateManagement;
using PokemonBattle.Models.V1.Pokemon;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonBattle.Client.Pages
{
    public partial class PokemonTeamSlot : ComponentBase
    {
        public PokemonData Pokemon { get; set; }

        [Parameter]
        public int SlotIndex { get; set; }

        [Parameter]
        public EventCallback<int> ClickTeamSlot { get; set; }

        [Parameter]
        public EventCallback<PokemonData> SelectPokemon { get; set; }

        public string SlotClass { get; set; }

        public string SlotId { get; set; }

        public string ImgContainerClass { get; set; }

        public string ImgName { get; set; }

        public string ImgClass { get; set; }

        public string ImgSrc { get; set; }

        public string ImgAlt { get; set; }

        public string DisplayNameContainerClass { get; set; }

        public string DisplayName { get; set; }

        public string DefaultTeamPokemonImgUrl = "Content\\PokeballEmptyOutline.png";

        public ElementReference Slot;

        [Inject]
        public StateManager state { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Pokemon = state.PokemonTeam[SlotIndex];
            SlotClass = state.PokemonTeamSlotClasses[SlotIndex];

            SlotId = Pokemon != null ? Pokemon.Id + "-" + SlotIndex : "empty-slot-" + SlotIndex;
            ImgContainerClass = state.PokemonTeamImageBaseClass;
            ImgName = Pokemon != null ? Pokemon.Name : "empty-pokemon";
            ImgClass = Pokemon != null ? Pokemon.Name + "-img" : state.EmptyPokemonBaseClass;
            ImgSrc = Pokemon != null ? Pokemon.Sprites.Front_Default : @DefaultTeamPokemonImgUrl;
            ImgAlt = Pokemon != null ? Pokemon.Name : "EmptyPokeball";
            DisplayNameContainerClass = state.PokemonTeamNameBaseClass;
            DisplayName = Pokemon != null ? Pokemon.Name.ToUpper() : "Empty";
        }

        protected override async Task OnParametersSetAsync()
        {
            Pokemon = state.PokemonTeam[SlotIndex];
            SlotClass = state.PokemonTeamSlotClasses[SlotIndex];
        }

        public async void ClickPokemon(MouseEventArgs args)
        {
            await SelectPokemon.InvokeAsync(Pokemon);
            await ClickTeamSlot.InvokeAsync(SlotIndex);
        }
    }
}
