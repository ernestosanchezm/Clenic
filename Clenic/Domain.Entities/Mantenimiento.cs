using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Mantenimiento
    {
        public Mantenimiento()
        {
            Reportes = new HashSet<Reporte>();
        }

        public int IdMantenimiento { get; set; }
        public int IdSolicitud { get; set; }
        public DateTime Dfecha { get; set; }
        public int QestadoMantenimiento { get; set; }
        public int QestadoIngeniero { get; set; }
        public int IdIngeniero { get; set; }
        public string Testado { get; set; }

        public virtual Colaborador IdIngenieroNavigation { get; set; }
        public virtual Solicitud IdSolicitudNavigation { get; set; }
        public virtual ICollection<Reporte> Reportes { get; set; }
    }
}
