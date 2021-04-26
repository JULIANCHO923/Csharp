using RegistroVotantes.Domain.Entities;
using RegistroVotantes.Domain.Ports;
using System;
using System.Threading.Tasks;

namespace RegistroVotantes.Domain.Services
{
    public class ServicioValidacionVotante
    {
        private readonly IGenericRepository<Votante> Repo;
        private readonly Constantes constantes = new Constantes();

        public ServicioValidacionVotante()
        {
        }

        public ServicioValidacionVotante(Constantes constantes)
        {
            this.constantes = constantes;
        }

        public ServicioValidacionVotante(IGenericRepository<Votante> repo)
        {
            Repo = repo;
        }

        public ServicioValidacionVotante(IGenericRepository<Votante> repo, Constantes constantes)
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
            if (edadEnAnos < 18)
            {
                throw new Exception("No puede votar por ser menor de 18 años");
            }
            return true;
        }

        public bool TieneNacionalidadPermitida(string nacionalidad)
        {
            if (!nacionalidad.Equals(this.constantes.NACIONALIDAD))
            {
                throw new Exception("No puede votar por no ser colombiano");
            }

            return true;
        }
    }
}