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

        public virtual CentroSalud CentroSalud { get; set; }
        public virtual Colaborador Colaborador { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}
