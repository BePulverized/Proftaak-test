namespace Proftaak_test
{
    using System.Collections.Generic;
    
    public class Tram
    {
        public decimal Id { get; set; }
        public decimal? RemiseIdStandplaats { get; set; }
        public decimal? TramtypeId { get; set; }
        public decimal? Nummer { get; set; }
        public decimal? Lengte { get; set; }
        public bool? Vervuild { get; set; }
        public bool? Defect { get; set; }
        public bool? ConducteurGeschikt { get; set; }
        public bool? Beschikbaar { get; set; }
    
        public virtual REMISE Remise { get; set; }
        public virtual List<Reservering> Reserveringen { get; set; }
        public virtual List<Sector> Sectoren { get; set; }
        public virtual List<TramLijn> TramLijnen { get; set; }
        public virtual List<TramOnderhoud> TramOnderhouds { get; set; }
        public virtual Tramtype Tramtype { get; set; }
    }
}
