using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroVotantes.Domain.Entities;
using RegistroVotantes.Domain.Entities.Excepciones;
using RegistroVotantes.Domain.Services;
using System;

namespace RegistroVotantes.Domain.Tests
{
    [TestClass]
    public class _1_ValidacionVotante_FechaNacimiento_AAA
    {
        private ServicioValidacionVotante servicioValidacionVotante;
        private Constantes constantes;

        [TestInitialize]
        public void Initialize()
        {
            constantes = new Constantes();
            servicioValidacionVotante = new ServicioValidacionVotante(constantes);
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
        [TestMethod, ExpectedException(typeof(ExcepcionFechaDeNacimiento))]
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