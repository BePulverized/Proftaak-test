namespace Proftaak_test
{
    public class Verbinding
    {
        public decimal Id { get; set; }
        public decimal? SectorIdVan { get; set; }
        public decimal? SectorIdNaar { get; set; }
    
        public virtual Sector Sector { get; set; }
        public virtual Sector Sector1 { get; set; }
    }
}
