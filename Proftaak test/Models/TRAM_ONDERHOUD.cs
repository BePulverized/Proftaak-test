namespace Proftaak_test
{
    using System;

    public class TramOnderhoud
    {
        public decimal Id { get; set; }
        public decimal? MedewerkerId { get; set; }
        public decimal? TramId { get; set; }
        public DateTime? DatumTijdstip { get; set; }
        public DateTime? BeschikbaarDatum { get; set; }
        public int Onderhoudstypeid { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Tram Tram { get; set; }
    }
}
