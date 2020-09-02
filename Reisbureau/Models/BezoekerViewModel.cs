using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reisbureau.Models
{
    public class BezoekerViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "De naam bevat min. {2}, max. {1} tekens")]
        public string Naam { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "De voornaam bevat min. {2}, max. {1} tekens")]
        public string Voornaam { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "het adres bevat min. {2}, max. {1} tekens")]
        public string Adres { get; set; }
        [Required]
        [RegularExpression(@"\d[4]", ErrorMessage = "Postcode verkeerd")]
        public int Postcode { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "het adres bevat min. {2}, max. {1} tekens")]
        public string Gemeente { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Emailadres verkeerd")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"\d[3]/\d[6]", ErrorMessage = "Telefoonnummer verkeerd")]
        public string Telefoonnummer { get; set; }

    }
}
