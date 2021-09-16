using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Solicitud
    {
        public Solicitud()
        {
            Mantenimientos = new HashSet<Mantenimiento>();
        }

        public int IdSolicitud { get; set; }
        public int IdEmpresa { get; set; }
        public int IdSanatorio { get; set; }
        public int IdMaquina { get; set; }
        public string Tdescripcion { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual Maquina IdMaquinaNavigation { get; set; }
        public virtual Sanatorio IdSanatorioNavigation { get; set; }
        public virtual ICollection<Mantenimiento> Mantenimientos { get; set; }
    }
}
