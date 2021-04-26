using RegistroVotantes.Domain.Entities;
using RegistroVotantes.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace RegistroVotantes.Domain.Tests
{
    [TestClass]
    public class VotanteServiceTest_2_DataBuilder
    {

        ServicioValidacionVotante svv;
        Constantes constantes;

        [TestInitialize]
        public void Initialize()
        {
            constantes = new Constantes();
            svv = new ServicioValidacionVotante(constantes);
        }



        //Convertir en Data Builder
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
