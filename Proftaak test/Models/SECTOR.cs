namespace Proftaak_test
{
    using System.Collections.Generic;
    
    public class Sector
    {
    
        public decimal Id { get; set; }
        public decimal? SpoorId { get; set; }
        public decimal TramId { get; set; }
        public decimal? Nummer { get; set; }
        public bool? Beschikbaar { get; set; }
        public bool? Blokkade { get; set; }
    
        public virtual List<Verbinding> Verbindingen { get; set; }
        public virtual List<Verbinding> Verbindingen1 { get; set; }
        public virtual Spoor Spoor { get; set; }
        public virtual Tram Tram { get; set; }

        public Sector(decimal? nummer, Spoor spoor, Tram tram)
        {
            Spoor = spoor;
            Tram = tram;
            Nummer = nummer;
        }

        public Sector(decimal id, decimal? nummer, decimal spoorid, Tram tram, bool beschikbaar, bool blokkade)
        {
            Id = id;
            SpoorId = spoorid;
            Tram = tram;
            Nummer = nummer;
            Beschikbaar = beschikbaar;
            Blokkade = blokkade;
        }
    }
}
