using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GuitarTabASP.Models
{
    public class UserViewModel
    {
        //Gebruikersnaam
        [DisplayName("Gebruikersnaam")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Vul een gebruikersnaam in.")]
        [StringLength(30,MinimumLength = 4,ErrorMessage ="Je naam moet tussen 4 en 30 tekens zijn.")]
        public string Gebruikersnaam { get; set; }
        //email
        [DisplayName("Email")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Vul een email in.")]
        [StringLength(45,MinimumLength =8,ErrorMessage ="Je email moet tussen de 8 en 45 tekens zijn.")]
        public string email { get; set; }
        //Wachtwoord
        [DisplayName("Wachtwoord.")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Vul een wachtwoord in.")]
        [StringLength(30,MinimumLength =8,ErrorMessage ="Uw wachtwoord moet tussen 8 en 30 tekens zijn.")]
        public string wachtwoord { get; set; }
        public int userID { get; set; }

        public UserRatingViewModel rating { get; set; }
        public List<MuziekNummerViewModel> nummers { get; set; }
    }
}
