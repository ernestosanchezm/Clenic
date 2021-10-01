using Business.Constants;
using Business.Helpers;
using Business.MainModule;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyE.Web.BE;
using MyE.Web.Models;
using MyE.Web.Models.Home;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyE.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly UsuarioBusiness ServiceUser;        
        public HomeController()
        {
            ServiceUser = new UsuarioBusiness();
        }
        public IActionResult Index()
        {
            return RedirectToAction("Login");      
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginModel model)
        {
            var response = default(IActionResult);
                        
            try
            {

                var idusuario_tipo= ServiceUser.LoginUser(model.Usuario,model.Clave);

                if (idusuario_tipo is null) return base.SwalErrorResponse("Credenciales invalidas", "Error de acceso");
                if (idusuario_tipo.Item2 == Constantes.TIPO_USUARIO_COLABORADOR)
                {
                    var objColaborador=ServiceUser.DataColaborador(idusuario_tipo.Item1.Value);                   
                    HttpContext.Session.Set(
                        "USUARIO", 
                        ConvertHelper.ToByteArray(JsonConvert.SerializeObject(new LoginColaboradorSession { 
                            ColaboradorLoginDTO=objColaborador,
                            Nameuser=model.Usuario  
                        })));
                }

                if (idusuario_tipo.Item2 == Constantes.TIPO_USUARIO_CENTROSALUD)
                {
                    var objcentrosalud= ServiceUser.DataCentroSalud(idusuario_tipo.Item1.Value);
                    HttpContext.Session.Set(
                        "USUARIO",
                        ConvertHelper.ToByteArray(JsonConvert.SerializeObject(new LoginCentroSaludSession
                        {
                            CentroSaludDTO = objcentrosalud,
                            Nameuser = model.Usuario,
                        })));
                }
               
            }
            catch (Exception ex)
            {
                //model.Clave = null;
                //base.AddLog(model, ex);
                //response = base.SwalResponseError(ex);
            }
            finally
            {
                //try { ctx.SaveChanges(); } catch { }
                //try { ctx.Dispose(); } catch { }
            }
            return response;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
