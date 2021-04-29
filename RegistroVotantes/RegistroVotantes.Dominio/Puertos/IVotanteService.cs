using RegistroVotantes.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RegistroVotantes.Dominio.Puertos
{
    public interface IVotanteService
    {
        Task<IEnumerable<Votante>> FindVotanteAsync(Expression<Func<Votante, bool>> filter);

        Task<Votante> SaveVotanteAsync(Votante v);
    }
}