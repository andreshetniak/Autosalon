using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Autosalon.WebHost.Infrastrucure
{
    public partial class FuelType
    {
        public FuelType()
        {
            Characteristics = new HashSet<Characteristics>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Characteristics> Characteristics { get; set; }
    }
}
