using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Maquina
    {
        public Maquina()
        {
            Solicituds = new HashSet<Solicitud>();
        }

        public int IdMaquina { get; set; }
        public string Tmarca { get; set; }
        public string Tmodelo { get; set; }
        public string Ttipo { get; set; }

        public virtual ICollection<Solicitud> Solicituds { get; set; }
    }
}
