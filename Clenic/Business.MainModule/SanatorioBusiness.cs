﻿using Domain.Entities;
using Infrastructure.Data;
using System;
using System.Linq;

namespace Business.MainModule
{
    public class SanatorioBusiness
    {
        private SqlContext ctx;
        public SanatorioBusiness()
        {
            ctx = new SqlContext();
        }

        public bool RegistrarSanatorio(string nameuser,string psw,string RazonSocial, string RUC, string Encargado, string Direccion)
        {
            var objUsuario = new Usuario
            {                
                Tusername = nameuser,
                Tpassword = psw
            };
            ctx.Usuarios.Add(objUsuario);
            var objSanatorio = new Sanatorio
            {
                IdSanatorioNavigation=objUsuario,
                Tencargado=Encargado,
                Tdireccion=Direccion,
                TrazonSocial=RazonSocial,
                Truc=RUC
            };
            ctx.Sanatorios.Add(objSanatorio);
            ctx.SaveChanges();
            return true;
        }           
    }
}
