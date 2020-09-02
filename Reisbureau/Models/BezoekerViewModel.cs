using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reisbureau.Models
{
    public class BezoekerViewModel
    {
        [Required(ErrorMessage = "Naam is een verplicht veld")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "De naam bevat min. {2}, max. {1} tekens")]
        public string Naam { get; set; }
        [Required(ErrorMessage = "Voornaam is een verplicht veld")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "De voornaam bevat min. {2}, max. {1} tekens")]
        public string Voornaam { get; set; }
        [Required(ErrorMessage = "Adres is een verplicht veld")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "het adres bevat min. {2}, max. {1} tekens")]
        public string Adres { get; set; }
        [Required(ErrorMessage = "Postcode is een verplicht veld")]
        [RegularExpression(@"\d[4]", ErrorMessage = "Postcode verkeerd")]
        public int Postcode { get; set; }
        [Required(ErrorMessage = "Gemeente is een verplicht veld")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "het adres bevat min. {2}, max. {1} tekens")]
        public string Gemeente { get; set; }
        [Required(ErrorMessage = "Emailadres is een verplicht veld")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Emailadres verkeerd")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefoonnummer is een verplicht veld")]
        [RegularExpression(@"\d[3]/\d[6]", ErrorMessage = "Telefoonnummer verkeerd")]
        public string Telefoonnummer { get; set; }

    }
}
