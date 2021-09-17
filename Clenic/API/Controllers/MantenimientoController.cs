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
    public class MantenimientoController : ControllerBase
    {
        MantenimientoBusiness mantenimientoBusiness = default(MantenimientoBusiness);
        // GET: api/<SolicitudesController>
        public MantenimientoController()
        {
            mantenimientoBusiness = new MantenimientoBusiness();
        }
        [HttpPost]
        [Route("cambiarestado")]
        public object CambiarEstadoMantenimiento(CambiarMantenimiento obj)
        {
            try {
                return mantenimientoBusiness.CambiarEstadoMantenimiento(obj.idmantenimiento, obj.estado);
              
            } catch {
                return null;
            }           
        }


    }
}
