using System.ComponentModel.DataAnnotations;

namespace MyE.Web.Models.Home
{
    public class LoginModel
    {   
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Usuario { get; set; }
              
        [Required]
        public string Clave { get; set; }
    }
}
