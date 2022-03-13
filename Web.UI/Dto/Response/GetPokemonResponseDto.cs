using Web.UI.Models.Pokemon;

namespace Web.UI.Dto.Response
{
    public class GetPokemonResponseDto : BaseHttpResponseDto
    {
        //public PokemonData Data { get; set; }

        public Ability[] Abilities { get; set; }
        public int Base_Experience { get; set; }
        public Form[] Forms { get; set; }
        public Game[] Game_Indices { get; set; }
        public string Height { get; set; }
        public HeldItem[] Held_Items { get; set; }
        public int Id { get; set; }
        public bool Is_Default { get; set; }
        public string Location_Area_Encounters { get; set; }
        public Move[] Moves { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public PastType[] Past_Types { get; set; }
        public PokemonSpecies Species { get; set; }
        public PokemonSprites Sprites { get; set; }
        public Stat[] Stats { get; set; }
        public PokemonType[] Types { get; set; }
        public int Weight { get; set; }
    }
}
