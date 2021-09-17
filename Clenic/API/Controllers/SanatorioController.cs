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
    public class SanatorioController : ControllerBase
    {
        SanatorioBusiness sanatorioBusiness = default(SanatorioBusiness);
        // GET: api/<SolicitudesController>
        public SanatorioController()
        {
            sanatorioBusiness = new SanatorioBusiness();
        }
        [HttpPost]
        [Route("registrarsanatorio")]
        public bool RegistrarSanatorio(SanatorioReg objSanatorio)
        {
            try {
                return sanatorioBusiness.RegistrarSanatorio(objSanatorio.nameuser, objSanatorio.psw, objSanatorio.RazonSocial, objSanatorio.RUC, objSanatorio.Encargado, objSanatorio.Direccion);
              
            } catch {
                return false;
            }           
        }


    }
}
