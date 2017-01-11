namespace Proftaak_test
{
    using System.Collections.Generic;
    
    public partial class Lijn
    {
    
        public decimal Id { get; set; }
        public decimal? RemiseId { get; set; }
        public decimal? Nummer { get; set; }
        public bool? ConducteurRijdtMee { get; set; }
    
        public virtual List<TramLijn> TramLijn { get; set; }
        public virtual Remise Remise { get; set; }
    }
}
