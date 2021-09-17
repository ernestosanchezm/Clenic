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
        public int TtipoUsuario { get; set; }

        public virtual Empresa Empresa { get; set; }
        public virtual Ingeniero Ingeniero { get; set; }
        public virtual Sanatorio Sanatorio { get; set; }
    }
}
