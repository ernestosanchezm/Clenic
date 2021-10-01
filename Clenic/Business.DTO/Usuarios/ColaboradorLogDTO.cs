using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DTO.Usuarios
{
    public class ColaboradorLogDTO
    {
        public int IdColaborador { get; set; }
        public string NColaborador { get; set; }
        public string Direccion { get; set; }
        public string NDNI { get; set; }
        public int? TTipoColaborador { get; set; }
    }
}
