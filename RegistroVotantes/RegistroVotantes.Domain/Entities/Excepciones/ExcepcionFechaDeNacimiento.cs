using NPOI.Util;
using System;

namespace RegistroVotantes.Domain.Entities.Excepciones
{
    [Serializable]
    public class ExcepcionFechaDeNacimiento : Exception
    {
        public ExcepcionFechaDeNacimiento(DateTime fechaDeNacimiento) : base(String.Format("Fecha de nacimiento no permitida: '{0}'. No cumple con el minimo de edad permitida", fechaDeNacimiento))
        {
        }
    }
}
