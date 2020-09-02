using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Reisbureau.Models;

namespace Reisbureau.Models
{
    public class BezoekerViewModel
    {
        [Display(Name = "Naam :")]
        [Required]
        
        public string Naam { get; set; }

        [Display(Name = "Voornaam :")]
        [Required]
     
        public string Voornaam { get; set; }
        
        [Display(Name = "Adres :")]
        [Required]
        
        public string Adres { get; set; }

        [Display(Name = "Postcode :")]
        [Required]
   
        public int Postcode { get; set; }

        [Display(Name = "Gemeente :")]
        [Required]
       
        public string Gemeente { get; set; }

        [Display(Name = "Emailadres :")]
        [Required]
       [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Telefoonnummer :")]
        [Required]
        
        public string Telefoonnummer { get; set; }

    }
}
