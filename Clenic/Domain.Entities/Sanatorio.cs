using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Sanatorio
    {
        public Sanatorio()
        {
            Solicituds = new HashSet<Solicitud>();
        }

        public int IdSanatorio { get; set; }
        public string TrazonSocial { get; set; }
        public string Truc { get; set; }
        public string Tencargado { get; set; }
        public string Tdireccion { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Solicitud> Solicituds { get; set; }
    }
}
