using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class CentroSalud
    {
        public CentroSalud()
        {
            Maquinas = new HashSet<Maquina>();
        }

        public int IdCentroSalud { get; set; }
        public string TrazonSocial { get; set; }
        public string Truc { get; set; }
        public string Tencargado { get; set; }
        public string Tdireccion { get; set; }

        public virtual Usuario IdCentroSaludNavigation { get; set; }
        public virtual ICollection<Maquina> Maquinas { get; set; }
    }
}
