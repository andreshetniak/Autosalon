using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Autosalon.WebHost.Infrastrucure
{
    public partial class Car
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string MainImage { get; set; }

        public virtual Characteristics Characteristics { get; set; }
    }
}
