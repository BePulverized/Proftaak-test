namespace Proftaak_test
{
    public class TramLijn
    {
        public decimal TlId { get; set; }
        public decimal? TramId { get; set; }
        public decimal? LijnId { get; set; }
        public bool? Gebonden { get; set; }
    
        public virtual Lijn Lijn { get; set; }
        public virtual Tram Tram { get; set; }
    }
}
