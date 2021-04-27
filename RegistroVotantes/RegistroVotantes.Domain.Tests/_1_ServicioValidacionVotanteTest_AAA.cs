using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroVotantes.Domain.Entities;
using RegistroVotantes.Domain.Entities.Excepciones;
using RegistroVotantes.Domain.Services;
using System;

namespace RegistroVotantes.Domain.Tests
{
    [TestClass]
    public class _1_ServicioValidacionVotanteTest_AAA
    {
        private ServicioValidacionVotante servicioValidacionVotante;
        private ConstantesVotante constantesVotante;

        [TestInitialize]
        public void Initialize()
        {
            constantesVotante = new ConstantesVotante();
            servicioValidacionVotante = new ServicioValidacionVotante(constantesVotante);
        }

        [TestMethod]
        public void EdadValida()
        {
            DateTime FechaDeNacimiento = DateTime.Now.AddYears(-20); servicioValidacionVotante.TieneEdadMinimaPermitida(FechaDeNacimiento);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void CuandoVotanteTieneEdadPermitidaEntoncesValidacionDeEdadRetornaVerdadero()
        {
            // Arrange
            var votanteConEdadPermitida = new Votante
            {
                FechaDeNacimiento = DateTime.Now.AddYears(-20),
                Nacionalidad = "Colombiano"
            };

            // Act
            bool tieneEdadPermitida = servicioValidacionVotante.TieneEdadMinimaPermitida(votanteConEdadPermitida.FechaDeNacimiento);

            // Assert
            Assert.IsTrue(tieneEdadPermitida, "Fecha de Nacimiento No Permitida");
        }

        // Assert
        [TestMethod, ExpectedException(typeof(FechaDeNacimientoException))]
        public void CuandoVotanteNoTieneEdadPermitidaEntoncesValidacionDeEdadRetornaExcepcion()
        {
            // Arrange
            var votanteMenorEdadPermitida = new Votante
            {
                FechaDeNacimiento = DateTime.Now,
                Nacionalidad = "Colombiano"
            };

            // Act
            servicioValidacionVotante.TieneEdadMinimaPermitida(votanteMenorEdadPermitida.FechaDeNacimiento);
        }
    }
}