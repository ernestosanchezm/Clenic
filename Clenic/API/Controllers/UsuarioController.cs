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
    public class UsuarioController : ControllerBase
    {
        UsuarioBusiness usuarioBusiness = default(UsuarioBusiness);
        // GET: api/<SolicitudesController>
        public UsuarioController()
        {
            usuarioBusiness = new UsuarioBusiness();
        }
        [HttpPost]
        [Route("login")]
        public object Login(LoginRqst objlogin)
        {
            try {
                return usuarioBusiness.LoginUser(objlogin.nameuser, objlogin.psw);
              
            } catch {
                return null;
            }           
        }


    }
}
