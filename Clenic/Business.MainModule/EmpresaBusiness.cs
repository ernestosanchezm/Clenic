using Domain.Entities;
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

        public bool RegistrarEmpresa(string nameuser,string psw,string razonsocial,string ruc,string nadmin,string direccion)
        {          
            var objUsuario = new Usuario {                 
                Tusername=nameuser,
                Tpassword=psw                
            };
            ctx.Usuarios.Add(objUsuario);
            var objempresa = new Empresa {
                IdEmpresaNavigation=objUsuario,
                Tadministrador=nadmin,
                Tdireccion = direccion,
                TrazonSocial=razonsocial,
                Truc=ruc                
            };
            ctx.Empresas.Add(objempresa);
            ctx.SaveChanges();
            return true;
        }           
    }
}
