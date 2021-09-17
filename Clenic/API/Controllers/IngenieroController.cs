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
    public class IngenieroController : ControllerBase
    {
        IngenierosBusiness ingenieroBusiness = default(IngenierosBusiness);
        // GET: api/<SolicitudesController>
        public IngenieroController()
        {
            ingenieroBusiness = new IngenierosBusiness();
        }

        [HttpPost]
        [Route("registraringeniero")]
        public bool RegistrarIngeniero(IngenieroReg objingeniero)
        {
            try
            {
                return ingenieroBusiness.RegistrarIngeniero(objingeniero.nameuser, objingeniero.psw, objingeniero.Direccion, objingeniero.dni, objingeniero.nombre, objingeniero.idempresa);
            }
            catch
            {
                return false;
            }
        }

        [HttpPost]
        [Route("detalleingeniero")]
        public IngenieroDTO DetalleIngeniero(int idingeniero)
        {
            try {
                return ingenieroBusiness.DetalleIngeniero(idingeniero);
            } catch {
                return null;
            }           
        }

        [HttpGet]
        [Route("listaringenierosactivosxempresa")]
        public List<IngenieroDTO> ListarIngenierosActivosXEmpresa(int idempresa)
        {
            try
            {
                return ingenieroBusiness.ListarIngenierosActivosXEmpresa(idempresa);
            }
            catch
            {
                return null;
            }
        }

    }
}
