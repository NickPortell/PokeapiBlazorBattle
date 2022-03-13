using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.UI.Models.Pokemon
{
    public class HeldItem
    {
        public Item Data { get; set; }
        
        public VersionDetail[] VersionDetails { get; set; }
    }
}
