using System;

namespace Business.DTO
{
    public class SolicitudDTO
    {
        public int IdSolicitud { get; set; }
        public int IdMaquina { get; set; }
        public string NMaquina{ get; set; }
        public string NSerie { get; set; }
        public string TdescripcionSolicitud { get; set; }
        public int IdEmpresa { get; set; }
        public string NEmpresa { get; set; }
    }
}
