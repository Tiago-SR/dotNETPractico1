using BL.IBLs;
using Microsoft.AspNetCore.Mvc;
using Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase {
        private readonly IBL_Vehiculo _vehiculo;
        public VehiculosController(IBL_Vehiculo _bl) {
            _vehiculo = _bl;
        }
        // GET: api/<VehiculosController>
        [HttpGet]
        public IEnumerable<Vehiculo> Get() {
            return _vehiculo.GetVehiculos();
        }

        // GET api/<VehiculosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            Vehiculo v = _vehiculo.GetVehiculo(id);
            if (v is null) {
                return NotFound("No existe vehiculo con esa ID");
            }
            return Ok(v);
        }

        // POST api/<VehiculosController>
        [HttpPost]
        public Vehiculo Post([FromBody] Vehiculo value) {
            return _vehiculo.AddVehiculo(value);
        }

        // PUT api/<VehiculosController>/5
        [HttpPut("{id}")]
        public Vehiculo Put([FromBody] Vehiculo value) {
            return _vehiculo.UpdateVehiculo(value);
        }

        // DELETE api/<VehiculosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
            _vehiculo.DeleteVehiculo(id);
        }
    }
}
