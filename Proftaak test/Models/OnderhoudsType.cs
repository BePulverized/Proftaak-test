using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;
using ICT4Rails.Models;

namespace Proftaak_test
{
    using System;

    public class OnderhoudsType : GenericKeyValueModel
    {
        public override int Id { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Please fill in a name under {0} characters")]
        public override string Name { get; set; }
    }
}
