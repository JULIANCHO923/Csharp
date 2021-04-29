using System;
using System.Runtime.Serialization;

namespace RegistroVotantes.Dominio.Entidades.Excepciones
{
    [Serializable]
    public class FechaDeNacimientoException : Exception
    {
        public FechaDeNacimientoException(DateTime fechaDeNacimiento) : base(String.Format("Fecha de nacimiento no permitida: '{0}'. No cumple con el minimo de edad permitida", fechaDeNacimiento))
        {
        }

        protected FechaDeNacimientoException(SerializationInfo info, StreamingContext context)
        : base(info, context)
        {
        }
    }
}