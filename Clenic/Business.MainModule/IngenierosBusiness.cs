using Business.DTO;
using Domain.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.MainModule
{
    public class IngenierosBusiness
    {
        private SqlContext ctx;
        public IngenierosBusiness()
        {
            ctx = new SqlContext();
        }


        public bool RegistrarIngeniero(string nameuser, string psw, string Direccion,string dni,string nombre,int idempresa)
        {
            var objUsuario = new Usuario
            {
                Tusername = nameuser,
                Tpassword = psw
            };
            ctx.Usuarios.Add(objUsuario);
            var objIngeniero = new Ingeniero
            {
               IdIngenieroNavigation=objUsuario,
               Tdireccion=Direccion,
               Tdni=dni,
               Tnombre= nombre,
               IdEmpresa= idempresa
            };
            ctx.Ingenieros.Add(objIngeniero);
            ctx.SaveChanges();
            return true;
        }

        public List<IngenieroDTO> ListarIngenierosActivosXEmpresa(int idempresa)
        {
            var listIngenieros = ctx.Ingenieros
                                .Where(e=>e.IdEmpresa==idempresa)
                                .Select(e => new IngenieroDTO{
                                    Dni=e.Tdni,
                                    EstadoIngeniero="A",
                                    IdEmpresa=e.IdEmpresa,
                                    IdIngeniero=e.IdIngeniero,
                                    NIngeniero=e.Tnombre,
                                    TDireccion=e.Tdireccion
                                })
                                .ToList();
            return listIngenieros;
        }
        public IngenieroDTO DetalleIngeniero(int idingeniero)
        {
            try {
                var e = ctx.Ingenieros
                                  .FirstOrDefault(e => e.IdIngeniero == idingeniero);

                return new IngenieroDTO
                {
                    Dni = e.Tdni,
                    EstadoIngeniero = "A",
                    IdEmpresa = e.IdEmpresa,
                    IdIngeniero = e.IdIngeniero,
                    NIngeniero = e.Tnombre,
                    TDireccion = e.Tdireccion
                };
            } catch {
                return null;
            }                                        
        }
    }
}
