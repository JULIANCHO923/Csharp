using System;
using System.Runtime.Serialization;

namespace RegistroVotantes.Domain.Entities.Excepciones
{
    [Serializable]
    public class NacionalidadException : Exception
    {
        public NacionalidadException(string nacionalidad) : base(String.Format("Nacionalidad no permitida: '{0}'. La Nacionalidad debe ser 'Colombiano'", nacionalidad))
        {
        }

        protected NacionalidadException(SerializationInfo info, StreamingContext context)
        : base(info, context)
        {
        }
    }
}