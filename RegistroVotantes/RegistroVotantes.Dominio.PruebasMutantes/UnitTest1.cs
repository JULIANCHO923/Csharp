using Microsoft.VisualStudio.TestTools.UnitTesting;
using NinjaTurtles;
using RegistroVotantes.Dominio.Servicios;

namespace RegistroVotantes.Dominio.PruebasMutantes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod,MutationTest]
        public void MethodUnderTest_Mutation_Tests()
        {
            MutationTestBuilder<ServicioValidacionVotante>
                .For("TieneEdadMinimaPermitida")
                .Run();
        }

        [TestMethod, MutationTest]
        public void MethodUnderTest_Mutation_Test2()
        {
            MutationTestBuilder<ServicioValidacionVotante>.For("TieneNacionalidadPermitida")
                .Run();
        }
        
    }
}
