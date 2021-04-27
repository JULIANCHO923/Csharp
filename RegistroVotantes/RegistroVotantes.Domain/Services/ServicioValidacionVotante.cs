using RegistroVotantes.Domain.Entities;
using RegistroVotantes.Domain.Entities.Excepciones;
using RegistroVotantes.Domain.Ports;
using System;
using System.Threading.Tasks;

namespace RegistroVotantes.Domain.Services
{
    public class ServicioValidacionVotante
    {
        private readonly IGenericRepository<Votante> Repo;
        private readonly ConstantesVotante constantes = new ConstantesVotante();

        public ServicioValidacionVotante()
        {
        }

        public ServicioValidacionVotante(ConstantesVotante constantes)
        {
            this.constantes = constantes;
        }

        public ServicioValidacionVotante(IGenericRepository<Votante> repo)
        {
            Repo = repo;
        }

        public ServicioValidacionVotante(IGenericRepository<Votante> repo, ConstantesVotante constantes)
        {
            Repo = repo;
            this.constantes = constantes;
        }

        public async Task<Votante> RegistrarVotante(Votante v)
        {
            TieneEdadMinimaPermitida(v.FechaDeNacimiento);
            TieneNacionalidadPermitida(v.Nacionalidad);
            return await Repo.AddAsync(v);
        }

        public bool TieneEdadMinimaPermitida(DateTime fechaDeNacimiento)
        {
            var edadEnAnos = (int)(DateTime.Now.Subtract(fechaDeNacimiento).TotalDays / 365);
            if (edadEnAnos < constantes.EDADPERMITIDA)
            {
                throw new FechaDeNacimientoException(fechaDeNacimiento);
            }
            return true;
        }

        public bool TieneNacionalidadPermitida(string nacionalidad)
        {
            if (!nacionalidad.Equals(this.constantes.NACIONALIDADPERMITIDA))
            {
                throw new NacionalidadException(nacionalidad);
            }

            return true;
        }
    }
}