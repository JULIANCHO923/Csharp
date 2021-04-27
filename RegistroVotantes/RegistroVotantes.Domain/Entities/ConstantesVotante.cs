using System;

namespace RegistroVotantes.Domain.Entities
{
    public class ConstantesVotante
    {
        public readonly string NACIONALIDAD = "Colombiano";
        public readonly int FECHANACIONALIDAD = (int)(DateTime.Now.Subtract(DateTime.Now.AddYears(-18)).TotalDays / 365);
    }
}