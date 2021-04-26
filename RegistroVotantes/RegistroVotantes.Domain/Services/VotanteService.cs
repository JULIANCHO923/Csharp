using RegistroVotantes.Domain.Entities;
using RegistroVotantes.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RegistroVotantes.Domain.Services
{
    [DomainService]
    public class VotanteService : IVotanteService, IDisposable
    {
        private readonly IGenericRepository<Votante> _VotanteRepository;

        public VotanteService(IGenericRepository<Votante> votanteRepository)
        {
            _VotanteRepository = votanteRepository;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            this._VotanteRepository.Dispose();
        }

        public async Task<IEnumerable<Votante>> FindVotanteAsync(Expression<Func<Votante, bool>> filter)
        {
            return await _VotanteRepository.GetAsync(filter, includeObjectProperties: x => x.Nacionalidad).ConfigureAwait(false);
        }

        public async Task<Votante> SaveVotanteAsync(Votante votante)
        {
            return await _VotanteRepository.AddAsync(votante).ConfigureAwait(false);
        }
    }
}