using System.ComponentModel.DataAnnotations;

namespace MyE.Web.Models.Home
{
    public class LoginModel
    {  

        [Display(Name ="Codigo")]
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Usuario { get; set; }

        [Display(Name ="Contraseña")]
        [Required]
        public string Clave { get; set; }
    }
}
