using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroVotantes.Domain.Entities
{
    public class Votante : EntityBase<Guid>
    {
        public string Nacionalidad { get; set; }

        public DateTime FechaDeNacimiento { get; set; }
    }
}
