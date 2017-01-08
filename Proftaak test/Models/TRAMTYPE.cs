namespace Proftaak_test
{
    using System.Collections.Generic;
    
    public class Tramtype
    {
        public decimal Id { get; set; }
        public string Omschrijving { get; set; }
        public virtual List<Tram> TraMs { get; set; }
    }
}
