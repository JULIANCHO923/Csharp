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
    public class VotanteServiceTest_1_AAA
    {

        ServicioValidacionVotante svv;
        Constantes constantes;

        [TestInitialize]
        public void Initialize()
        {
            constantes = new Constantes();
            svv = new ServicioValidacionVotante(constantes);
        }

        [TestMethod]
        public void CuandoVotantoEsMayorOIgualDe18YNacionalidadEsColombianoEntoncesValidacionRetornaVerdadero()
        {
            // Arrange
            var votanteMayor = new Votante
            {
                FechaDeNacimiento = DateTime.Now.AddYears(-20),
                Nacionalidad = "Colombiano"
            };

            // Act
            var resultado = svv.EdadMinima(votanteMayor.FechaDeNacimiento);

            // Assert
            Assert.AreEqual(true, resultado);
        }

        // Assert
        [TestMethod, ExpectedException(typeof(Exception))]
        public void CuandoVotanteNoEsMayorDeEdadSistemaRespondeConExcepcion()
        {
            // Arrange
            var votanteMayor = new Votante
            {
                FechaDeNacimiento = DateTime.Now,
                Nacionalidad = "Colombiano"
            };

            // Act
            svv.EdadMinima(votanteMayor.FechaDeNacimiento);
        }
        
    }
}
