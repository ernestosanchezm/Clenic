using Business.Constants;
using Business.DTO;
using Domain.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Business.MainModule
{
    public class SolicitudBusiness
    {
        private SqlContext ctx;
        public SolicitudBusiness()
        {
            ctx = new SqlContext();
        }

        public bool RegistrarSolicitud(int IdMaquina,string Descripcion,int IdEmpresa )
        {
            try {
                ctx.Solicituds.Add(new Solicitud
                {
                    IdMaquina = IdMaquina,
                    IdEmpresa = IdEmpresa,
                    Tdescripcion = Descripcion
                });
                ctx.SaveChanges();
                return true;
            } catch {
                return false;
            }     
        }

        public List<SolicitudDTO> ListarSolicitudesPorCentroSalud(int idsanatorio)
        {
            try {
                var listarSolicitudes = ctx.Solicituds
                                   .Include(e => e.IdMaquinaNavigation)
                                   .Include(e => e.IdEmpresaNavigation)
                                   .Where(e => e.IdMaquinaNavigation.IdSanatorio == idsanatorio)
                                   .Select(e => new SolicitudDTO
                                   {
                                       IdEmpresa = e.IdEmpresa,
                                       NEmpresa = e.IdEmpresaNavigation.TrazonSocial,
                                       IdMaquina = e.IdMaquina,
                                       IdSolicitud = e.IdSolicitud,
                                       NMaquina = e.IdMaquinaNavigation.Tmarca + e.IdMaquinaNavigation.Tmodelo,
                                       NSerie = e.IdMaquinaNavigation.Tserie,
                                       TdescripcionSolicitud = e.Tdescripcion
                                   })
                                   .ToList();
                return listarSolicitudes;
            }
            catch
            {
                return null;
            }
        }

        public List<SolicitudDTO> ListarSolicitudesPorEmpresa(int idEmpresa)
        {
            try
            {
                var listarSolicitudes = ctx.Solicituds
                                   .Include(e => e.IdMaquinaNavigation)
                                   .Include(e => e.IdEmpresaNavigation)
                                   .Where(e => e.IdEmpresa == idEmpresa)
                                   .Select(e => new SolicitudDTO
                                   {
                                       IdEmpresa = e.IdEmpresa,
                                       NEmpresa = e.IdEmpresaNavigation.TrazonSocial,
                                       IdMaquina = e.IdMaquina,
                                       IdSolicitud = e.IdSolicitud,
                                       NMaquina = e.IdMaquinaNavigation.Tmarca + e.IdMaquinaNavigation.Tmodelo,
                                       NSerie = e.IdMaquinaNavigation.Tserie,
                                       TdescripcionSolicitud = e.Tdescripcion
                                   })
                                   .ToList();
                return listarSolicitudes;
            }
            catch
            {
                return null;
            }
        }

    }
}
