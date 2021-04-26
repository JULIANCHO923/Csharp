using RegistroVotantes.Domain.Entities;
using RegistroVotantes.Domain.Ports;
using RegistroVotantes.Domain.Services;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RegistroVotantes.Domain.Tests
{
    [TestClass]
    public class VotanteServiceTest_3_Mock
    {

        ServicioValidacionVotante svv;
        IGenericRepository<Votante> _mockRepo;
        Constantes constantes;

        [TestInitialize]
        public void Initialize()
        {

            _mockRepo = Substitute.For<IGenericRepository<Votante>>();
            constantes = new Constantes();
            svv = new ServicioValidacionVotante(_mockRepo, constantes);
        }


        [TestMethod]
        public void VotanteExitoso()
        {
            var votanteMayor = new Votante
            {
                FechaDeNacimiento = DateTime.Now.AddYears(-20),
                Nacionalidad = "Colombiano"
            };

            _mockRepo.AddAsync(Arg.Any<Votante>()).Returns(Task.FromResult(new Votante()));

            var resultado = svv.RegistrarVotante(votanteMayor).Result;

            Assert.IsTrue(resultado is DomainEntity);
        }


        [TestMethod, ExpectedException(typeof(Exception))]
        public void EsMayorDeEdadError()
        {
            var votanteMayor = new Votante
            {
                FechaDeNacimiento = DateTime.Now,
                Nacionalidad = "Colombiano"
            };

            svv.EdadMinima(votanteMayor.FechaDeNacimiento);
        }

        [TestMethod]
        public void EsMayorDeEdadExitoso()
        {
            var votanteMayor = new Votante
            {
                FechaDeNacimiento = DateTime.Now.AddYears(-20),
                Nacionalidad = "Colombiano"
            };

            var resultado = svv.EdadMinima(votanteMayor.FechaDeNacimiento);
            Assert.AreEqual(true, resultado);
        }

        [TestMethod]        
        public void EsNAcionalExitoso()
        {
            var votanteMayor = new Votante
            {
                FechaDeNacimiento = DateTime.Now.AddYears(-20),
                Nacionalidad = "Colombiano"
            };

            var puedeVotarPorNacionalidad = svv.EsNacional(votanteMayor.Nacionalidad);
            Assert.AreEqual(true, puedeVotarPorNacionalidad);
        }


        [TestMethod, ExpectedException(typeof(Exception))]
        public void EsNacionalError()
        {
            var votanteMayor = new Votante
            {
                FechaDeNacimiento = DateTime.Now,
                Nacionalidad = "Venezolano"
            };

            var resultado =  svv.EsNacional(votanteMayor.Nacionalidad);
        }






    }
}
