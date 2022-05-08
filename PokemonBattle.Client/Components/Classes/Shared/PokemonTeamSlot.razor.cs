using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using PokemonBattle.Models.V1.Pokemon;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonBattle.Client.Components.Classes.Shared
{
    public class PokemonTeamSlot : ComponentBase
    {
        [Parameter]
        public PokemonData Pokemon { get; set; }

        [Parameter]
        public int SlotIndex { get; set; }

        [Parameter]
        public EventCallback<int> ClickTeamSlot { get; set; }

        [Parameter]
        public EventCallback<PokemonData> SelectPokemon { get; set; }

        [Parameter]
        public EventCallback<List<ElementReference>> GetClickedTeamSlotElements { get; set; }

        [Parameter]
        public EventCallback<KeyValuePair<string, ElementReference>> AddTeamSlotElement { get; set; }

        [Parameter]
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

        public string PokemonTeamSlotBaseClass => "pokemon-team-slot";
        public string PokemonTeamImageBaseClass => "pokemon-team-img";
        public string PokemonTeamNameBaseClass => "pokemon-team-name";
        public string EmptyPokemonBaseClass => "empty-pokeball";

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        protected override async Task OnInitializedAsync()
        {
            SlotId = Pokemon != null ? Pokemon.Id + "-" + SlotIndex : "empty-slot-" + SlotIndex;
            ImgContainerClass = PokemonTeamImageBaseClass;
            ImgName = Pokemon != null ? Pokemon.Name : "empty-pokemon";
            ImgClass = Pokemon != null ? Pokemon.Name + "-img" : EmptyPokemonBaseClass;
            ImgSrc = Pokemon != null ? Pokemon.Sprites.Front_Default : @DefaultTeamPokemonImgUrl;
            ImgAlt = Pokemon != null ? Pokemon.Name : "EmptyPokeball";
            DisplayNameContainerClass = PokemonTeamNameBaseClass;
            DisplayName = Pokemon != null ? Pokemon.Name.ToUpper() : "Empty";
        }

        public async void ClickPokemon(MouseEventArgs args)
        {
            await SelectPokemon.InvokeAsync(Pokemon);
            await ClickTeamSlot.InvokeAsync(SlotIndex);
        }
    }
}
