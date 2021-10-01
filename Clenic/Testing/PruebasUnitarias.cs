using API;
using Business.Constants;
using DistributedServices.DTO;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyE.API.Controllers;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Testing
{
    [TestClass]
    public class PruebasUnitarias
    {
        private readonly HttpClient _client;
        public PruebasUnitarias()
        {          
        }
        [TestMethod]
        public void TestCambiarEstadoIngeniero()
        {
            var controller = new IngenieroController();
            int idingeniero = 3; string estado = Constantes.ESTADO_INGENIERO_ACTIVO;
            controller.CambiarEstadoIngeniero(new CambiarEstadoIngeniero {idingeniero= idingeniero, estado=estado });

            var contexto2 = new SqlContext();
            var estadoIng=contexto2.Ingenieros.Single(e=>e.IdIngeniero==idingeniero).Testado;

            Assert.IsTrue(estadoIng==estado,"EL CAMBIO DE ESTADO SE REALIZO DE FORMA EXITOSA");

        }
        [TestMethod]
        public void TestDetalleIngeniero()
        {
            var controller = new IngenieroController();
            int idingeniero = 3; 
            var objIng=controller.DetalleIngeniero(idingeniero);

            var contexto2 = new SqlContext();
            var objIng2 = contexto2.Ingenieros.Single(e => e.IdIngeniero == idingeniero);
            var result = false;
            if (objIng.Dni == objIng2.Tdni && objIng.IdEmpresa == objIng2.IdEmpresa && objIng.NIngeniero == objIng2.Tnombre) result = true;
            Assert.IsTrue(result , "LA CONSULTA DEL DETALLE DE UN AUDITOR FUE EXITOSA");

        }
        [TestMethod]
        public void TestListarIngenierosActivosPorEmpresa()
        {
            var controller = new IngenieroController();
            int idEmpresa = 2;
            var cantIngActivos1 = controller.ListarIngenierosActivosXEmpresa(idEmpresa).Count();

            var contexto2 = new SqlContext();
            var cantIngActivos2= contexto2.Ingenieros.Where(e => e.IdEmpresa == idEmpresa).Count();
                       
            Assert.IsTrue(cantIngActivos1== cantIngActivos2, "LA CONSULTA DE AUDITORES DISPONIBLES FUE EXITOSA");

        }

    }
}
