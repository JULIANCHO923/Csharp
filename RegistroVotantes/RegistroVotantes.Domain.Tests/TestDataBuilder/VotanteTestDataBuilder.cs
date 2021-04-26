using RegistroVotantes.Domain.Entities;
using System;

namespace RegistroVotantes.Domain.Tests.TestDataBuilder
{
    internal class VotanteTestDataBuilder
    {
        public string Nacionalidad;

        public DateTime FechaDeNacimiento;

        public VotanteTestDataBuilder ConValoresDePrueba()
        {
            Nacionalidad = new Constantes().NACIONALIDAD;
            FechaDeNacimiento = DateTime.Now.AddYears(-18);
            return this;
        }

        public VotanteTestDataBuilder ConNacionalidad(string nacionalidad)
        {
            this.Nacionalidad = nacionalidad;
            return this;
        }

        public VotanteTestDataBuilder ConFechaDeNacimiento(DateTime fechaDeNacimiento)
        {
            this.FechaDeNacimiento = fechaDeNacimiento;
            return this;
        }

        public Votante Build()
        {
            return new Votante(this.Nacionalidad, this.FechaDeNacimiento);
        }
    }
}