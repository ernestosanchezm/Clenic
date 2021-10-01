using Business.Helpers;
using Microsoft.AspNetCore.Mvc;
using MyE.Web.BE;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyE.Web.Controllers
{
    public class BaseController : Controller
    {
        [NonAction]
        protected LoginCentroSaludSession GetUsuarioCentroSalud()
        {         
            var bUsuario = default(byte[]);
            HttpContext.Session.TryGetValue("USUARIO", out bUsuario);
            var jsonUsuario = ConvertHelper.FromByteArray<string>(bUsuario);
            var usuario = JsonConvert.DeserializeObject<LoginCentroSaludSession>(jsonUsuario);

            return usuario;
        }

        [NonAction]
        protected LoginColaboradorSession GetUsuarioColaborador()
        {        
            var bUsuario = default(byte[]);
            HttpContext.Session.TryGetValue("USUARIO", out bUsuario);
            var jsonUsuario = ConvertHelper.FromByteArray<string>(bUsuario);
            var usuario = JsonConvert.DeserializeObject<LoginColaboradorSession>(jsonUsuario);

            return usuario;
        }

        [NonAction]
        protected void ValidarModelo(object model)
        {
            if (model == null)
                throw new Exception("No se ha enviado ningún dato.");

            if (!ModelState.IsValid)
            {
                var result = new List<string>();

                var errorMessages = ModelState.Values.Select(x => x.Errors.Select(y => new { y.ErrorMessage }));

                foreach (var x in errorMessages)
                    foreach (var y in x)
                        result.Add(y.ErrorMessage ?? "");

                result.RemoveAll(string.IsNullOrEmpty);

                var message = (result.Count > 1 ? "-" : "") + string.Join("\n-", result.ToArray());

                throw new Exception(message);
            }
        }

      
        [NonAction]
        protected JsonResult SwalResponse(string text, string icon = "success", string title = "¡La operación se realizo con exito!")
        {
            return Json(new
            {
                icon,
                title,
                text
            });
        }
             

        [NonAction]
        protected JsonResult SwalErrorResponse(string msg = null, string titulo = null)
        {
            return Json(new
            {
                icon = "warning",
                title = titulo ?? "¡Incorrecto!",
                text = msg ?? "La operación no se realizó."
            });
        }

        [NonAction]
        protected JsonResult SwalResponseSuccess(string msg = null, string titulo = null)
        {
            return Json(new
            {
                icon = "success",
                title = titulo ?? "¡Correcto!",
                text = msg ?? "La operación se realizó correctamente."
            });
        }
               
    }
}
