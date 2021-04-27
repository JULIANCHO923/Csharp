using System;
using System.Runtime.Serialization;

namespace RegistroVotantes.Domain.Entities.Excepciones
{
    [Serializable]
    public class FechaDeNacimientoException : Exception
    {
        public FechaDeNacimientoException(DateTime fechaDeNacimiento) : base(String.Format("Fecha de nacimiento no permitida: '{0}'. No cumple con el minimo de edad permitida", fechaDeNacimiento))
        {
        }

        private FechaDeNacimientoException(SerializationInfo info, StreamingContext context)
        : base(info, context)
        {
        }
    }
}