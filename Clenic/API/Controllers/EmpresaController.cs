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
    public class EmpresaController : ControllerBase
    {
        EmpresaBusiness empresaBusiness = default(EmpresaBusiness);
        // GET: api/<SolicitudesController>
        public EmpresaController()
        {
            empresaBusiness = new EmpresaBusiness();
        }
        [HttpPost]
        [Route("registrarempresa")]
        public bool RegistrarEmpresa(EmpresaReg objempresa)
        {
            try {
                //int idEmpresa,string nameuser,string psw,string razonsocial,string ruc,string nadmin,string direccion
                return empresaBusiness.RegistrarEmpresa(objempresa.nameuser,
                                objempresa.Psw, objempresa.TRazonSocial, objempresa.TRUC,
                                objempresa.TAdministrador, objempresa.TDireccion);
              
            } catch {
                return false;
            }           
        }


    }
}
