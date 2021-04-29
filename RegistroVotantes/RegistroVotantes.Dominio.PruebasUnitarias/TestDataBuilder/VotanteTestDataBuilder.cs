using RegistroVotantes.Dominio.Entidades;
using System;

namespace RegistroVotantes.Dominio.PruebasUnitarias
{
    public class VotanteTestDataBuilder
    {
        public string Nacionalidad;

        public DateTime FechaDeNacimiento;

        public VotanteTestDataBuilder ConValoresPorDefecto()
        {
            Nacionalidad = new ConstantesVotante().NACIONALIDADPERMITIDA;
            FechaDeNacimiento = DateTime.Now.AddYears(-(new ConstantesVotante().EDADPERMITIDA));
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