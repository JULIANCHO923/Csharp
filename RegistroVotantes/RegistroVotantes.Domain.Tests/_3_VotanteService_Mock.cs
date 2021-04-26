using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RegistroVotantes.Domain.Entities;
using RegistroVotantes.Domain.Ports;
using RegistroVotantes.Domain.Services;
using RegistroVotantes.Domain.Tests.TestDataBuilder;
using System.Threading.Tasks;

namespace RegistroVotantes.Domain.Tests
{
    [TestClass]
    public class _3_VotanteService_Mock
    {
        private ServicioValidacionVotante servicioValidacionVotante;
        private IGenericRepository<Votante> _mockRepo;
        private Constantes constantes;

        [TestInitialize]
        public void Initialize()
        {
            constantes = new Constantes();

            _mockRepo = Substitute.For<IGenericRepository<Votante>>();

            servicioValidacionVotante = new ServicioValidacionVotante(_mockRepo, constantes);
        }

        [TestMethod]
        public void CuandoIngresoVotanteValidoEntoncesRegistrarVotanteRetornaEntidadVotante()
        {
            // Arrange
            Votante votanteValido = new VotanteTestDataBuilder().ConValoresPorDefecto().Construir();

            _mockRepo.AddAsync(Arg.Any<Votante>()).Returns(Task.FromResult(new Votante()));

            // Act
            var votanteRegistrado = servicioValidacionVotante.RegistrarVotante(votanteValido).Result;

            // Assert
            Assert.IsTrue(votanteRegistrado is DomainEntity, "El Votante registrado no es un entidad del dominio");
        }
    }
}