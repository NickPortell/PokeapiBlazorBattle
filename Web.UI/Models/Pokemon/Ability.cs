using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.UI.Models.Pokemon
{
    public class Ability
    {
        public AbilityData Data { get; set; }

        public bool IsHidden { get; set; }

        public int Slot { get; set; }
    }
}
