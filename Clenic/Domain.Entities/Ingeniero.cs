using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Ingeniero
    {
        public Ingeniero()
        {
            Mantenimientos = new HashSet<Mantenimiento>();
        }

        public int IdIngeniero { get; set; }
        public string Tnombre { get; set; }
        public string Tdni { get; set; }
        public string Tdireccion { get; set; }
        public int IdEmpresa { get; set; }
        public string Testado { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual Usuario IdIngenieroNavigation { get; set; }
        public virtual ICollection<Mantenimiento> Mantenimientos { get; set; }
    }
}
