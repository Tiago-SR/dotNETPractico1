using BL.IBLs;
using Microsoft.AspNetCore.Mvc;
using Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IBL_Personas _persona;
        public PersonaController(IBL_Personas _bl) {
            _persona = _bl;
        }
        // GET: api/<PersonaController>
        [HttpGet]
        public IEnumerable<Persona> Get()
        {
            return _persona.GetPersonas();
        }

        // GET api/<PersonaController>/5
        [HttpGet("{id}")]
        public Persona Get(int id)
        {
            return _persona.GetPersona(id);
        }

        // POST api/<PersonaController>
        [HttpPost]
        public Persona Post([FromBody]Persona value) {
            return _persona.AddPersona(value);
        }

        // PUT api/<PersonaController>/5
        [HttpPut("{id}")]
        public Persona Put([FromBody]Persona value) {
            return _persona.UpdatePersona(value);
        }

        // DELETE api/<PersonaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
           _persona.DeletePersona(id);
        }
    }
}
