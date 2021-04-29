using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroVotantes.Dominio.Entidades;
using RegistroVotantes.Dominio.PruebasUnitarias;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace RegistroVotantes.Api.ApiTest
{
    [TestClass]
    public class VotanteControllerTest : IntegrationTestBuilder
    {

        private string postVotantes;

        [TestInitialize]
        public void Initialize()
        {
            BootstrapTestingSuite();
            postVotantes = "api/votantesControlador";
        }


        [TestMethod]
        public void CuandoSolicitudPostVotanteValidoEntoncesVotanteRegistradoSatisfactoriamente()
        {
            Votante votanteValido = new VotanteTestDataBuilder().ConValoresPorDefecto().Construir();

            var c = this.TestClient.PostAsync(postVotantes, votanteValido, new JsonMediaTypeFormatter()).Result;
            c.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, c.StatusCode);
        }

        [TestMethod]
        public void PostPersonError()
        {
            var votante = new
            {
                Id = "123456",
                FechaDeNacimiento = DateTime.Now.AddYears(-30),
                Nacionalidad = "Colombiano"
            };

            var c = this.TestClient.PostAsync(postVotantes, votante, new JsonMediaTypeFormatter()).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, c.StatusCode);
        }

        [TestMethod]
        public void PostPersonErrorFecha()
        {
            Votante votante = new Votante()
            {
                FechaDeNacimiento = DateTime.Now.AddYears(-10),
                Nacionalidad = "Colombiano"
            };

            var c = this.TestClient.PostAsync(postVotantes, votante, new JsonMediaTypeFormatter()).Result;

            Assert.AreEqual(HttpStatusCode.InternalServerError, c.StatusCode);
        }
       
        [TestMethod]
        public void PostPersonErrorNacionalidad()
        {
            var votante = new
            {
                FechaDeNacimiento = DateTime.Now.AddYears(-30),
                Nacionalidad = "Puertorricense"
            };

            var c = this.TestClient.PostAsync(postVotantes, votante, new JsonMediaTypeFormatter()).Result;

            Assert.AreEqual(HttpStatusCode.InternalServerError, c.StatusCode);
        }
    }
}