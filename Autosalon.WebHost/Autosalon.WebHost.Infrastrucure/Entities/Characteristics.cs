using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Autosalon.WebHost.Infrastrucure
{
    public partial class Characteristics
    {
        public int Id { get; set; }
        public int IdCar { get; set; }
        public int? Transmission { get; set; }
        public int? Fuel { get; set; }
        public int? DriveUnit { get; set; }
        public decimal? EngineVolume { get; set; }
        public int? Horsepower { get; set; }

        public virtual DriveUnitType DriveUnitNavigation { get; set; }
        public virtual FuelType FuelNavigation { get; set; }
        public virtual Car IdCarNavigation { get; set; }
        public virtual TransmissionType TransmissionNavigation { get; set; }
    }
}
