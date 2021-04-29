using System;

namespace RegistroVotantes.Dominio.Servicios
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class DomainServiceAttribute : Attribute
    {
    }
}