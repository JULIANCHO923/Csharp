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
        public void CuandoSeRealizaSolicitudPostConUnVotanteValidoEntoncesVotanteRegistradoSatisfactoriamenteRetornaOkEnHttpStatusCode()
        {
            // Arrange
            Votante votanteValido = new VotanteTestDataBuilder().ConValoresPorDefecto().Construir();

            // Act
            var c = this.TestClient.PostAsync(postVotantes, votanteValido, new JsonMediaTypeFormatter()).Result;

            // Assert
            c.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, c.StatusCode);
        }

        [TestMethod]
        public void CuandoVotanteConGUINoPermitidaSeIntentaRegistrarAccedientoAlMetodoPostVotanteEntoncesRetornaraBadRequestEnHttpStatusCode()
        {
            // Arrange
            var votanteConJsonMalFormado = new
            {
                Id = "123456",
                FechaDeNacimiento = DateTime.Now.AddYears(-30),
                Nacionalidad = "Colombiano"
            };

            // Act
            var c = this.TestClient.PostAsync(postVotantes, votanteConJsonMalFormado, new JsonMediaTypeFormatter()).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, c.StatusCode);
        }

        [TestMethod]
        public void CuandoVotanteConFechaDeNacimientoNoPermitidaSeIntentaRegistrarAccedientoAlMetodoPostVotanteEntoncesRetornaraInternalServerErrorEnHttpStatusCode()
        {
            // Arrange
            Votante votanteNoPermitido = new VotanteTestDataBuilder().ConValoresPorDefecto().ConFechaDeNacimiento(DateTime.Now.AddYears(-10)).Construir();     

            // Act
            var c = this.TestClient.PostAsync(postVotantes, votanteNoPermitido, new JsonMediaTypeFormatter()).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.InternalServerError, c.StatusCode);
        }
       
        [TestMethod]
        public void CuandoVotanteConNacionalidadNoPermitidaSeIntentaRegistrarAccedientoAlMetodoPostVotanteEntoncesRetornaraInternalServerErrorEnHttpStatusCode()
        {
            // Arrange
            Votante votanteNoPermitido = new VotanteTestDataBuilder().ConValoresPorDefecto().ConNacionalidad("Puertorricense").Construir();
            
            // Act
            var c = this.TestClient.PostAsync(postVotantes, votanteNoPermitido, new JsonMediaTypeFormatter()).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.InternalServerError, c.StatusCode);
        }
    }
}