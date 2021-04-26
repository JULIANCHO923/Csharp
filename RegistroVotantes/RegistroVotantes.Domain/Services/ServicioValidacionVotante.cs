using RegistroVotantes.Domain.Entities;
using RegistroVotantes.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RegistroVotantes.Domain.Services
{
    public class ServicioValidacionVotante
    {
        readonly IGenericRepository<Votante> Repo;
        readonly Constantes constantes;
        public ServicioValidacionVotante(Constantes constantes)
        {
            this.constantes = constantes;
        }

        public ServicioValidacionVotante(IGenericRepository<Votante> repo, Constantes constantes)
        {
            Repo = repo;
            this.constantes = constantes;
        }
        
        public async Task<Votante> RegistrarVotante(Votante v)
        {
            EdadMinima(v.FechaDeNacimiento);
            EsNacional(v.Nacionalidad);
            return await Repo.AddAsync(v);
        }

        public bool EdadMinima(DateTime entonces)
        {
            var edadEnAnos = (int)(DateTime.Now.Subtract(entonces).TotalDays / 365);
            if (edadEnAnos < 18)
            {
                throw new Exception("No puede votar por ser menor de 18 años");
            }
            return true;
                    
        }

        public bool EsNacional(string nacionalidad)
        {
            if (!nacionalidad.Equals(this.constantes.NACIONALIDAD))
            {
                throw new Exception("No puede votar por no ser colombiano");
            }

            return true;
        }
    }
}
