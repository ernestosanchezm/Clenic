using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Empresa
    {
        public Empresa()
        {
            Ingenieros = new HashSet<Ingeniero>();
            Solicituds = new HashSet<Solicitud>();
        }

        public int IdEmpresa { get; set; }
        public string TrazonSocial { get; set; }
        public string Truc { get; set; }
        public string Tadministrador { get; set; }
        public string Tdireccion { get; set; }

        public virtual Usuario IdEmpresaNavigation { get; set; }
        public virtual ICollection<Ingeniero> Ingenieros { get; set; }
        public virtual ICollection<Solicitud> Solicituds { get; set; }
    }
}
