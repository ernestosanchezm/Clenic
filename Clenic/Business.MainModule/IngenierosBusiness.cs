using Business.Constants;
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

        public bool CambiarEstadoIngeniero(int idingeniero,string estado)
        {
            try {
                var objIngeniero = ctx.Colaboradors.SingleOrDefault(e => e.IdColaborador == idingeniero);
                if (objIngeniero is null) return false;
                else
                {
                    objIngeniero.Testado = estado;
                    ctx.Colaboradors.Update(objIngeniero);
                    ctx.SaveChanges();
                    return true;
                }
            } catch{
                return false;
            }
          

        }

        public bool RegistrarIngeniero(string nameuser, string psw, string Direccion,string dni,string nombre,int idempresa)
        {
            try {
                var objUsuario = new Usuario
                {
                    Tusername = nameuser,
                    Tpassword = psw
                };
                ctx.Usuarios.Add(objUsuario);
                var objIngeniero = new Colaborador
                {
                    IdColaboradorNavigation = objUsuario,
                    Tdireccion = Direccion,
                    Tdni = dni,
                    Tnombre = nombre,
                    IdEmpresa = idempresa,
                    Testado=Constantes.ESTADO_INGENIERO_ACTIVO
                };
                ctx.Colaboradors.Add(objIngeniero);
                ctx.SaveChanges();
                return true;
            } catch{
                return false;
            }
         
        }

        public List<ColaboradorDTO> ListarIngenierosActivosXEmpresa(int idempresa)
        {
            var listIngenieros = ctx.Colaboradors
                                .Where(e=>e.IdEmpresa==idempresa)
                                .Select(e => new ColaboradorDTO{
                                    Dni=e.Tdni,
                                    EstadoIngeniero=e.Testado,
                                    IdEmpresa=e.IdEmpresa,
                                    IdIngeniero=e.IdColaborador,
                                    NIngeniero=e.Tnombre,
                                    TDireccion=e.Tdireccion
                                })
                                .ToList();
            return listIngenieros;
        }
        public ColaboradorDTO DetalleIngeniero(int idingeniero)
        {
            try {
                var e = ctx.Colaboradors
                                  .FirstOrDefault(e => e.IdColaborador == idingeniero);

                return new ColaboradorDTO
                {
                    Dni = e.Tdni,
                    EstadoIngeniero = e.Testado,
                    IdEmpresa = e.IdEmpresa,
                    IdIngeniero = e.IdColaborador,
                    NIngeniero = e.Tnombre,
                    TDireccion = e.Tdireccion
                };
            } catch {
                return null;
            }                                        
        }
    }
}
