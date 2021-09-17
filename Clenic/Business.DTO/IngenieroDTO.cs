using System;

namespace Business.DTO
{
    public class IngenieroDTO
    {
        public int IdIngeniero { get; set; }
        public string NIngeniero{ get; set; }
        public string Dni{ get; set; }
        public string TDireccion { get; set; }
        public int IdEmpresa { get; set; }
        public string EstadoIngeniero { get; set; }
    }
}
