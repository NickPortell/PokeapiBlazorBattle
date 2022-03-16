namespace Web.UI.Dto.Response
{
    public class GetPokemonBaseSpritesResponseDto : BaseHttpResponseDto
    {
        public string Back_Default { get; set; }

        public string Back_Female { get; set; }

        public string Back_Shiny { get; set; }

        public string Back_Shiny_Female { get; set; }

        public string Front_Default { get; set; }

        public string Front_Female { get; set; }

        public string Front_Shiny { get; set; }

        public string Front_Shiny_Female { get; set; }
    }
}
