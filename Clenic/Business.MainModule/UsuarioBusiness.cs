using Business.Constants;
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

        public object LoginUser(string nameuser,string psw)
        {
            var objLog=ctx.Usuarios.SingleOrDefault(e=>e.Tusername==nameuser && e.Tpassword==psw);

            if (objLog != null)
            {
                if (Constantes.TIPO_USUARIO_EMPRESA == objLog.TtipoUsuario)
                {
                    var objempresa = ctx.Empresas.SingleOrDefault(e => e.IdEmpresa == objLog.IdUsuario);

                    return new
                    {
                        IdUsuario = objempresa.IdEmpresa,
                        NAdmin = objempresa.Tadministrador,
                        Direccion = objempresa.Tdireccion
                    };
                }
                else if (Constantes.TIPO_USUARIO_INGENIERO == objLog.TtipoUsuario)
                {
                    var objIng = ctx.Ingenieros.SingleOrDefault(e => e.IdIngeniero == objLog.IdUsuario);

                    return new
                    {
                        IdUsuario = objIng.IdEmpresa,
                        NIngeniero = objIng.Tnombre,
                        NAdmin = objIng.Tdni,
                        Direccion = objIng.Tdireccion
                    };
                }
                else //(Constantes.TIPO_USUARIO_SANATORIO == objLog.TtipoUsuario)
                {
                    var objIng = ctx.Sanatorios.SingleOrDefault(e => e.IdSanatorio == objLog.IdUsuario);

                    return new
                    {
                        IdUsuario = objIng.IdSanatorio,
                        NIngeniero = objIng.Tencargado,
                        NAdmin = objIng.TrazonSocial,
                        Direccion = objIng.Truc
                    };
                }
            }
            else return null;   
        }
    }
}
