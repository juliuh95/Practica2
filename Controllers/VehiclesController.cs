using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica2.Data;
using Practica2.DTOs;
using Practica2.Entidades;

namespace Practica2.Controllers
{
    [ApiController]
    [Route("api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;
        private readonly ILogger<VehiclesController> logger;
        public VehiclesController(ILogger<VehiclesController> logger, ApplicationDbContext context, IMapper mapper)

        {
            this.logger = logger;
            this.mapper = mapper;
            this.context = context;
        }

        //Select * from Vehicle
        [HttpGet]
        public async Task<ActionResult<List<Vehicle>>> Get()
        {
            return await context.Vehicle.ToListAsync();
        }


        //Busqueda por parametro
        [HttpGet("{id:int}")]
        public async Task<ActionResult<VehicleDTO>> Get(int id)
        {
            var vehicle = await context.Vehicle.FirstOrDefaultAsync(x => x.Id == id);

            if (vehicle == null)
            {
                return NotFound();
            }
            return mapper.Map<VehicleDTO>(vehicle);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VehicleCreacionDTO vehicleCreacionDTO)
        {
            var vehicle = mapper.Map<VehicleType>(vehicleCreacionDTO);
            context.Add(vehicle);
            await context.SaveChangesAsync();
            return NoContent();// 204
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Vehicle vehicle, int id)
        {
            if (vehicle.Id != id)
            {
                return BadRequest("El tipo de vehiculo no existe");

            }
            var existe = await context.Vehicle.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }
            context.Update(vehicle);
            await context.SaveChangesAsync();
            return Ok();//200
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            var vehicle = await context.Vehicle.FirstOrDefaultAsync(x => x.Id == id);

            if (vehicle == null)
            {
                return NotFound();
            }
            context.Remove(vehicle);
            await context.SaveChangesAsync();
            return NoContent();//204
        }
    }
}
