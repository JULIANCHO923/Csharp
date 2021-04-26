using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroVotantes.Domain.Entities;
using RegistroVotantes.Domain.Services;
using RegistroVotantes.Domain.Tests.TestDataBuilder;
using System;

namespace RegistroVotantes.Domain.Tests
{
    [TestClass]
    public class VotanteServiceTest_2_DataBuilder
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
        public void CuandoVotanteTieneNacionalidadPermitidaEntoncesValidacionDeNacionalidadRetornaVerdadero()
        {
            // Arrange
            Votante votanteValido = new VotanteTestDataBuilder().ConValoresDePrueba().Build();

            // Act
            var tieneNacionalidadPermitida = svv.TieneNacionalidadPermitida(votanteValido.Nacionalidad);

            // Assert
            Assert.IsTrue(tieneNacionalidadPermitida);
        }

        // Assert
        [TestMethod, ExpectedException(typeof(Exception))]
        public void CuandoVotanteNoTieneNacionalidadPermitidaEntoncesValidacionDeNacionalidadRetornaExcepcion()
        {
            // Arrange
            Votante votanteNoValido = new VotanteTestDataBuilder().ConValoresDePrueba().ConNacionalidad("Español").Build();

            // Act
            svv.TieneNacionalidadPermitida(votanteNoValido.Nacionalidad);
        }
    }
}