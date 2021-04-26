using RegistroVotantes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
