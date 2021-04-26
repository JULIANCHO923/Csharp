using RegistroVotantes.Domain.Entities;
using RegistroVotantes.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RegistroVotantes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotantesController : ControllerBase
    {

        readonly ServicioValidacionVotante _srv;

        public VotantesController(ServicioValidacionVotante srv)
        {
            _srv = srv;
        }

   
        // POST api/<VotantesController>
        [HttpPost]
        public async Task<Object> RegistroVotante([FromBody] Votante v)
        {
            return await _srv.RegistrarVotante(v);
        }
/*
        [HttpGet("{id}")]
        public async Task<Application.Person.PersonDto> GetById(Guid id)
        {
            return await _Mediator.Send(new Application.Person.PersonQuery(id));
        }
*/
    }
}
