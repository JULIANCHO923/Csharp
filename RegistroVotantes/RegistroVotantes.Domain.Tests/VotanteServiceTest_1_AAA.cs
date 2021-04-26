using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroVotantes.Domain.Entities;
using RegistroVotantes.Domain.Services;
using System;

namespace RegistroVotantes.Domain.Tests
{
    [TestClass]
    public class VotanteServiceTest_1_AAA
    {
        private ServicioValidacionVotante svv;
        private Constantes constantes;

        [TestInitialize]
        public void Initialize()
        {
            constantes = new Constantes();
            svv = new ServicioValidacionVotante(constantes);
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
            bool tieneEdadPermitida = svv.TieneEdadMinimaPermitida(votanteConEdadPermitida.FechaDeNacimiento);

            // Assert
            Assert.IsTrue(tieneEdadPermitida);
        }

        // Assert
        [TestMethod, ExpectedException(typeof(Exception))]
        public void CuandoVotanteNoTieneEdadPermitidaEntoncesValidacionDeEdadRetornaExcepcion()
        {
            // Arrange
            var votanteMenorEdadPermitida = new Votante
            {
                FechaDeNacimiento = DateTime.Now,
                Nacionalidad = "Colombiano"
            };

            // Act
            svv.TieneEdadMinimaPermitida(votanteMenorEdadPermitida.FechaDeNacimiento);
        }
    }
}