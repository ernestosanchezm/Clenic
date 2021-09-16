using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Reporte
    {
        public int IdReporte { get; set; }
        public int IdMantenimiento { get; set; }
        public int Qcalificacion { get; set; }
        public string Tcomentarios { get; set; }
        public DateTime Dfecha { get; set; }

        public virtual Mantenimiento IdMantenimientoNavigation { get; set; }
    }
}
