using Microsoft.AspNetCore.Components;
using PokemonBattle.Client.Controllers;
using PokemonBattle.Models.V1.Pokemon;
using System.Threading.Tasks;

namespace PokemonBattle.Client.Components.Classes.Shared
{
    public class PokemonSideTray : ComponentBase
    {

        [Parameter]
        public PokemonData Pokemon { get; set; }

        public string ImgContainerClass { get; set; }
        public string ImgSrc { get; set; }
        public string ImgName { get; set; }
        public string ImgClass { get; set; }
        public string ImgAlt { get; set; }
        public string DisplayName { get; set; }

        public string EmptyPokemonBaseClass { get; set; }

        public string DefaultTeamPokemonImgUrl = "Content\\PokeballEmptyOutline.png";

        public string DefaultPokemonImg = "Content\\MissingNo.png";

        public bool DisplaySideTray { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            SetBaseClasses();
            ImgContainerClass = "pokemon-spotlight-sidetray";
            ImgSrc = Pokemon != null ? Pokemon.Sprites.Front_Default : @DefaultTeamPokemonImgUrl;
            ImgName = Pokemon != null ? Pokemon.Name : "empty-pokemon";
            ImgClass = Pokemon != null ? Pokemon.Name + "-img" : EmptyPokemonBaseClass;
            ImgAlt = Pokemon != null ? Pokemon.Name : "EmptyPokeball";
            DisplayName = Pokemon != null ? Pokemon.Name.ToUpper() : "Empty";
            DisplaySideTray = Pokemon != null;
        }

        public void SetBaseClasses()
        {
            EmptyPokemonBaseClass = "empty-pokeball";
        }
    }
}
