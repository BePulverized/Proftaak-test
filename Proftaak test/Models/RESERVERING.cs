
namespace Proftaak_test
{
    public class Reservering
    {
        public decimal ReserveringId { get; set; }
        public decimal? TramId { get; set; }
        public decimal? SpoorId { get; set; }
    
        public virtual Spoor Spoor { get; set; }
        public virtual Tram Tram { get; set; }
    }
}
