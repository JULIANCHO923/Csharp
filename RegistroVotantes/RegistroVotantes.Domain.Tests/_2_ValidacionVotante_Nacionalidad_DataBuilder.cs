using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroVotantes.Domain.Entities;
using RegistroVotantes.Domain.Entities.Excepciones;
using RegistroVotantes.Domain.Services;
using RegistroVotantes.Domain.Tests.TestDataBuilder;
using System;

namespace RegistroVotantes.Domain.Tests
{
    [TestClass]
    public class _2_ValidacionVotante_Nacionalidad_DataBuilder
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
        public void CuandoVotanteTieneNacionalidadPermitidaEntoncesValidacionDeNacionalidadRetornaVerdadero()
        {
            // Arrange
            Votante votanteValido = new VotanteTestDataBuilder().ConValoresPorDefecto().Construir();

            // Act
            var tieneNacionalidadPermitida = servicioValidacionVotante.TieneNacionalidadPermitida(votanteValido.Nacionalidad);

            // Assert
            Assert.IsTrue(tieneNacionalidadPermitida, "Nacionalidad No Valida");
        }

        // Assert
        [TestMethod, ExpectedException(typeof(ExcepcionNacionalidad))]
        public void CuandoVotanteNoTieneNacionalidadPermitidaEntoncesValidacionDeNacionalidadRetornaExcepcion()
        {
            // Arrange
            Votante votanteNoValido = new VotanteTestDataBuilder().ConValoresPorDefecto().ConNacionalidad("Español").Construir();

            // Act
     servicioValidacionVotante.TieneNacionalidadPermitida(votanteNoValido.Nacionalidad);
        }
    }
}