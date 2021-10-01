using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Colaborador
    {
        public Colaborador()
        {
            Mantenimientos = new HashSet<Mantenimiento>();
        }

        public int IdColaborador { get; set; }
        public string Tnombre { get; set; }
        public string Tdni { get; set; }
        public string Tdireccion { get; set; }
        public int IdEmpresa { get; set; }
        public string Testado { get; set; }
        public int? TtipoColaborador { get; set; }

        public virtual Usuario IdColaboradorNavigation { get; set; }
        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual ICollection<Mantenimiento> Mantenimientos { get; set; }
    }
}
