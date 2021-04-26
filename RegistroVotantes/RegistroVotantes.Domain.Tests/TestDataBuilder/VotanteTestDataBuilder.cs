using RegistroVotantes.Domain.Entities;
using System;

namespace RegistroVotantes.Domain.Tests.TestDataBuilder
{
    class VotanteTestDataBuilder
    {
        public string Nacionalidad;

        public DateTime FechaDeNacimiento;

        public VotanteTestDataBuilder ConValoresDePrueba()
        {
            Nacionalidad = new Constantes().NACIONALIDAD;
            FechaDeNacimiento = DateTime.Now.AddYears(-18);
            return this;
        }
    }
}
