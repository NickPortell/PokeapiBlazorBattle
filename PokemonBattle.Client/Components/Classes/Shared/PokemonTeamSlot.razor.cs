using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using PokemonBattle.Models.V1.Pokemon;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonBattle.Client.Components.Classes.Shared
{
    public class PokemonTeamSlot : PokemonDataBase
    {
        [Parameter]
        public PokemonData Pokemon { get; set; }

        [Parameter]
        public int SlotIndex { get; set; }


        public string ClickedClass { get; set; }


        public string SlotClass { get; set; }

        public string SlotId { get; set; }


        public string ImgContainerClass { get; set; }

        public string ImgName { get; set; }

        public string ImgClass { get; set; }

        public string ImgSrc { get; set; }

        public string ImgAlt { get; set; }

        public string DisplayNameContainerClass { get; set; }

        public string DisplayName { get; set; }


        public ElementReference Slot;

        public Dictionary<string, ElementReference> PokemonTeamSlotElements => new Dictionary<string, ElementReference>();


        protected override async Task OnParametersSetAsync()
        {
            ClickedClass = "Clicked";
            SlotClass = PokemonTeamSlotBaseClass;
            SlotId = Pokemon != null ? Pokemon.Id + "-" + SlotIndex : "empty-slot-" + SlotIndex;
            ImgContainerClass =  PokemonTeamImageBaseClass;
            ImgName = Pokemon != null ? Pokemon.Name : "empty-pokemon";
            ImgClass = Pokemon != null ? Pokemon.Name + "-img" : EmptyPokemonBaseClass;
            ImgSrc = Pokemon != null ? Pokemon.Sprites.Front_Default : @DefaultTeamPokemonImgUrl;
            ImgAlt = Pokemon != null ? Pokemon.Name : "EmptyPokeball";
            DisplayNameContainerClass = PokemonTeamNameBaseClass;
            DisplayName = Pokemon != null ? Pokemon.Name.ToUpper() : "Empty";
        }

        private int GetPokemonIdFromSlotId(string slotId)
        {
            return int.Parse(slotId.Split('-')[0]);
        }

        public PokemonData GetPokemonDataBySlotId(string slotId)
        {
            return string.IsNullOrEmpty(slotId)
                   || slotId.Contains("empty-slot")
                   ? null : PokemonDataList.FirstOrDefault(p => p.Id == GetPokemonIdFromSlotId(slotId));
        }

        public async void ClickPokemon(ElementReference slot, string slotId, MouseEventArgs args)
        {
            await JSRuntime.InvokeVoidAsync("deselectOtherTeamSlots", PokemonTeamSlotBaseClass, ClickedClass);
            await JSRuntime.InvokeVoidAsync("clickPokemonTeamSlot", slot, ClickedClass);
            SelectedPokemon = GetPokemonDataBySlotId(slotId);
        }
    }
}
