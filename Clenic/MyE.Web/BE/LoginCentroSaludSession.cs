using Business.DTO.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyE.Web.BE
{
    public class LoginCentroSaludSession
    {
        public string Nameuser { get; set; }
        public string Token{ get; set; }
        public CentroSaludLogDTO CentroSaludDTO { get; set; }
    }
}
