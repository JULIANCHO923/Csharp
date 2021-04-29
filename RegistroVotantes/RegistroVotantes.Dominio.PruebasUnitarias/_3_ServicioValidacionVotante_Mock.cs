using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RegistroVotantes.Dominio.Entidades;
using RegistroVotantes.Dominio.PruebasUnitarias;
using RegistroVotantes.Dominio.Puertos;
using RegistroVotantes.Dominio.Servicios;
using System.Threading.Tasks;

namespace RegistroVotantes.Dominio.PruebasUnitarias
{
    [TestClass]
    public class _3_ServicioValidacionVotante_Mock
    {
        private ServicioValidacionVotante servicioValidacionVotante;
        private IGenericRepository<Votante> _mockRepo;
        private ConstantesVotante constantesVotante;

        [TestInitialize]
        public void Initialize()
        {
            constantesVotante = new ConstantesVotante();

            _mockRepo = Substitute.For<IGenericRepository<Votante>>();

            servicioValidacionVotante = new ServicioValidacionVotante(_mockRepo, constantesVotante);
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

            Assert.IsNotNull(votanteRegistrado.Id, "El GUID devuelto del votante es nulo");
            
            Assert.IsTrue(_mockRepo.Received(1).AddAsync(Arg.Any<Votante>()).IsCompletedSuccessfully, "El mock de la adición del Votante no se completó satisfactoriamente");
        }
    }
}