using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Collections.Generic;
using System.Linq;

namespace PokemonBattle.Client.Shared
{
    public partial class NavMenu : ComponentBase
    {
        private string NavBarClass = "";

        private void ToggleNavMenu(MouseEventArgs args)
        {
            List<string> classList = NavBarClass.Split(' ').ToList();

            if (classList.Contains("collapse") == false)
            {
                classList.Add("collapse");
            }
            else
            {
                classList.Remove("collapse");
            }

            NavBarClass = string.Join(' ', classList).Trim();
        }
    }
}
