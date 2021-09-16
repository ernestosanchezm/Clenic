using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Tusername { get; set; }
        public string Tpassword { get; set; }

        public virtual Ingeniero IdUsuario1 { get; set; }
        public virtual Sanatorio IdUsuario2 { get; set; }
        public virtual Empresa IdUsuarioNavigation { get; set; }
    }
}
