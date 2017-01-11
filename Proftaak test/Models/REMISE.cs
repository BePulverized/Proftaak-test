namespace Proftaak_test
{
    using System.Collections.Generic;

    public class Remise
    {
        public decimal ID { get; set; }
        public string Naam { get; set; }
        public decimal? GroteServiceBeurtenPerDag { get; set; }
        public decimal? KleineServiceBeurtenPerDag { get; set; }
        public decimal? GroteSchoonmaakBeurtenPerDag { get; set; }
        public decimal? KleineSchoonmaakBeurtenPerDag { get; set; }

        public virtual List<Lijn> LIJNs { get; set; }
        public virtual List<Spoor> SPOORs { get; set; }
        public virtual List<Tram> TRAMs { get; set; }
    }
}
