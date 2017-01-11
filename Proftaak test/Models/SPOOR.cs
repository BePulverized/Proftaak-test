namespace Proftaak_test
{
    using System.Collections.Generic;
    
    public class Spoor
    {
        public decimal Id { get; set; }
        public decimal? RemiseId { get; set; }
        public decimal? Nummer { get; set; }
        public decimal? Lengte { get; set; }
        public bool? Beschikbaar { get; set; }
        public bool? InUitRijspoor { get; set; }
    
        public virtual REMISE Remise { get; set; }
        public virtual List<Reservering> Reserveringen { get; set; }
        public virtual List<Sector> Sectoren { get; set; }

        public Spoor(decimal? nummer)
        {
            Nummer = nummer;
            
        }
    }
}
