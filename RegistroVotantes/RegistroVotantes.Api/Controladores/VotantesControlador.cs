using Microsoft.AspNetCore.Mvc;
using RegistroVotantes.Dominio.Entidades;
using RegistroVotantes.Dominio.Servicios;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RegistroVotantes.Api.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotantesControlador : ControllerBase
    {
        private readonly ServicioValidacionVotante _srv;

        public VotantesControlador(ServicioValidacionVotante srv)
        {
            _srv = srv;
        }

        [HttpPost]
        public async Task<Object> RegistroVotante([FromBody] Votante v)
        {
            return await _srv.RegistrarVotante(v);
        }
    }
}