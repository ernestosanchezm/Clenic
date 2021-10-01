using Business.Constants;
using Business.DTO.Usuarios;
using Infrastructure.Data;
using System;
using System.Linq;

namespace Business.MainModule
{
    public class UsuarioBusiness
    {
        private SqlContext ctx;
        public UsuarioBusiness()
        {
            ctx = new SqlContext();
        }

        public Tuple<int?,int?> LoginUser(string nameuser,string psw)
        {
            var objLog=ctx.Usuarios.SingleOrDefault(e=>e.Tusername==nameuser && e.Tpassword==psw);
        
            if (objLog != null)
            {
                return new Tuple<int?,int?>(objLog.IdUsuario,objLog.TtipoUsuario);                
            }
            else return null;   
        }

        public ColaboradorLogDTO DataColaborador(int IngenieroId)
        {
            var objcolaborador= ctx.Colaboradors.SingleOrDefault(e => e.IdColaborador== IngenieroId);

            if (objcolaborador is null) return null;
            return new ColaboradorLogDTO
            {
                IdColaborador = objcolaborador.IdEmpresa,
                NColaborador= objcolaborador.Tnombre,
                NDNI = objcolaborador.Tdni,
                Direccion = objcolaborador.Tdireccion,
                TTipoColaborador= objcolaborador.TtipoColaborador
            };
        }

        public CentroSaludLogDTO DataCentroSalud(int SanatorioId)
        {
            var objingeniero = ctx.CentroSaluds.SingleOrDefault(e => e.IdCentroSalud == SanatorioId);

            if (objingeniero is null) return null;
            return new CentroSaludLogDTO
            {
                IdCentroSalud = objingeniero.IdCentroSalud,
                NCentroSalud = objingeniero.TrazonSocial,
                NEncargado= objingeniero.Tencargado,
                Direccion = objingeniero.Tdireccion
            };
        }

    }
}
