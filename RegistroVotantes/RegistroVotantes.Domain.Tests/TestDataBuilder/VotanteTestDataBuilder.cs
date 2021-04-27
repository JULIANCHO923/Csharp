using RegistroVotantes.Domain.Entities;
using System;

namespace RegistroVotantes.Domain.Tests.TestDataBuilder
{
    public class VotanteTestDataBuilder
    {
        public string Nacionalidad;

        public DateTime FechaDeNacimiento;

        public VotanteTestDataBuilder ConValoresPorDefecto()
        {
            Nacionalidad = new ConstantesVotante().NACIONALIDAD;
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

        public Votante Construir()
        {
            return new Votante(this.Nacionalidad, this.FechaDeNacimiento);
        }
    }
}