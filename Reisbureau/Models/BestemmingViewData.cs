using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reisbureau.Models
{
    public class BestemmingViewData
    {
        
        [Required]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "De bestemming bevat min. {2}, max. {1} tekens")]
        public string Bestemming { get; set; }

    }
}
