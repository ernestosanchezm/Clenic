using Business.Constants;
using Infrastructure.Data;
using System;
using System.Linq;

namespace Business.MainModule
{
    public class MantenimientoBusiness
    {
        private SqlContext ctx;
        public MantenimientoBusiness()
        {
            ctx = new SqlContext();
        }

        public bool CambiarEstadoMantenimiento(int idmantenimiento,string estado) {
            try
            {
                var objmantenimiento = ctx.Mantenimientos.SingleOrDefault(e => e.IdMantenimiento==idmantenimiento);
                if (objmantenimiento is null) return false;
                else
                {
                    objmantenimiento.Testado = estado;
                    ctx.Mantenimientos.Update(objmantenimiento);
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }
    }
}
