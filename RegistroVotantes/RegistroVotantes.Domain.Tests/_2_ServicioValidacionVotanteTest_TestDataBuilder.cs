using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroVotantes.Domain.Entities;
using RegistroVotantes.Domain.Entities.Excepciones;
using RegistroVotantes.Domain.Services;
using RegistroVotantes.Domain.Tests.TestDataBuilder;

namespace RegistroVotantes.Domain.Tests
{
    [TestClass]
    public class _2_ServicioValidacionVotanteTest_TestDataBuilder
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
        [TestMethod, ExpectedException(typeof(NacionalidadException))]
        public void CuandoVotanteNoTieneNacionalidadPermitidaEntoncesValidacionDeNacionalidadRetornaExcepcion()
        {
            // Arrange
            Votante votanteNoValido = new VotanteTestDataBuilder().ConValoresPorDefecto().ConNacionalidad("Español").Construir();

            // Act
            servicioValidacionVotante.TieneNacionalidadPermitida(votanteNoValido.Nacionalidad);
        }
    }
}