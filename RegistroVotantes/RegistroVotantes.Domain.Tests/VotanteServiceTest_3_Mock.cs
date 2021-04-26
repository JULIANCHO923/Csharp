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
    public class VotanteServiceTest_3_Mock
    {
        private ServicioValidacionVotante svv;
        private IGenericRepository<Votante> _mockRepo;
        private Constantes constantes;

        [TestInitialize]
        public void Initialize()
        {
            constantes = new Constantes();

            _mockRepo = Substitute.For<IGenericRepository<Votante>>();

            svv = new ServicioValidacionVotante(_mockRepo, constantes);
        }

        [TestMethod]
        public void VotanteExitoso()
        {
            // Arrange
            Votante votanteValido = new VotanteTestDataBuilder().ConValoresDePrueba().Build();

            _mockRepo.AddAsync(Arg.Any<Votante>()).Returns(Task.FromResult(new Votante()));

            // Act
            var votanteRegistrado = svv.RegistrarVotante(votanteValido).Result;

            // Assert
            Assert.IsTrue(votanteRegistrado is DomainEntity);
        }
    }
}