//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proftaak_test
{
    using System.Collections.Generic;

    public class REMISE
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
