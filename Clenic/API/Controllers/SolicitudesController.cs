using Business.DTO;
using Business.MainModule;
using DistributedServices.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudesController : ControllerBase
    {
        SolicitudBusiness solicitudBusiness = default(SolicitudBusiness);
        // GET: api/<SolicitudesController>
        public SolicitudesController()
        {
            solicitudBusiness = new SolicitudBusiness();
        }
        [HttpPost]
        [Route("registrarsolicitud")]
        public bool RegistrarSolicitud(SolicitudReg objInsert)
        {
            try {
                solicitudBusiness.RegistrarSolicitud(objInsert.IdMaquina, objInsert.Descripcion, objInsert.IdEmpresa);
                return true;
            } catch { 
                return false; 
            }
           
        }


        [HttpGet]        
        [Route("listbyencargado")]
        public List<SolicitudDTO> ListByEncargado(int idsanatorio)
        {
            try
            {
                return solicitudBusiness.ListarSolicitudesPorEncargado(idsanatorio);
            }
            catch
            {
                return null;
            }
     
        }

        [HttpGet]
        [Route("listbyempresa")]
        public List<SolicitudDTO> LisByEmpresa(int idempresa)
        {
            try
            {
                return solicitudBusiness.ListarSolicitudesPorEmpresa(idempresa);
            }
            catch
            {
                return null;
            }


        }
    }
}
