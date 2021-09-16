using Infrastructure.Data;
using System;
using System.Linq;

namespace Business.MainModule
{
    public class EmpresaBusiness
    {
        private SqlContext ctx;
        public EmpresaBusiness()
        {
            ctx = new SqlContext();
        }

        public bool ListarSolicitudesPorEmpresa(int empresaId)
        {
            //var objLog=ctx.Usuarios.SingleOrDefault(e=>e.Tusername==nameuser && e.Tpassword==psw);
            //if (objLog is null)
            //{
            //    return false;
            //}
            return true;
        }
    }
}
