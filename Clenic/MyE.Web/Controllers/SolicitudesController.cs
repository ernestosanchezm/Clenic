using Business.MainModule;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyE.Web.Controllers
{
    public class SolicitudesController : Controller
    {
        private readonly SolicitudBusiness solicitudBusiness;
        public SolicitudesController() {
            solicitudBusiness = new SolicitudBusiness();
        }
        public IActionResult Index()
        {           
            return View();
        }
        public IActionResult ListaSolicitudes(int IdCentroSalud)
        {
            var ListSolicitudes = solicitudBusiness.ListarSolicitudesPorCentroSalud(IdCentroSalud);
            return View();
        }
    }
}
