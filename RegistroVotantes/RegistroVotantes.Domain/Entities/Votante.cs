using System;

namespace RegistroVotantes.Domain.Entities
{
    public class Votante : EntityBase<Guid>
    {
        public string Nacionalidad { get; set; }

        public DateTime FechaDeNacimiento { get; set; }

        public Votante()
        {
        }

        public Votante(string nacionalidad, DateTime fechaDeNacimiento)
        {
            this.Nacionalidad = nacionalidad;
            this.FechaDeNacimiento = fechaDeNacimiento;
        }
    }
}