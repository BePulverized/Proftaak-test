using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;

namespace Proftaak_test
{
    using System;

    public class TramOnderhoud
    {
        public decimal Id { get; set; }

        [Required]
        [Display(Name = "Medewerker")]
        public decimal? MedewerkerId { get; set; }
        [Required]
        [Display(Name = "Tram Nummer")]
        public decimal? TramId { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Datum")]
        public DateTime? DatumTijdstip { get; set; }
        public DateTime? BeschikbaarDatum { get; set; }
        [Required]
        [Display(Name = "Reparatie soort")]
        public int Onderhoudstypeid { get; set; }
        public string Onderhoudstypenaam { get; set; } // purely for a view..

        [Display(Name="Beschrijving")]
        [StringLength(245, ErrorMessage = "Please fill in a description under {0} characters")]
        [DataType(DataType.MultilineText)]
        public string OnderhoudsBeschrijving { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Tram Tram { get; set; }
    }
}
