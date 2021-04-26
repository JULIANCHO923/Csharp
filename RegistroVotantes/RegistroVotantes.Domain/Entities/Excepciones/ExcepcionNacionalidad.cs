using NPOI.Util;
using System;

namespace RegistroVotantes.Domain.Entities.Excepciones
{
    [Serializable]
    public class ExcepcionNacionalidad : Exception
    {
        public ExcepcionNacionalidad(string nacionalidad) : base(String.Format("Nacionalidad no permitida: '{0}'. La Nacionalidad debe ser 'Colombiano'", nacionalidad))
        {
        }
    }
}
