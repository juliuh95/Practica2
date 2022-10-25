using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica2.Data;
using Practica2.DTOs;
using Practica2.Entidades;

namespace Practica2.Controllers
{
    [ApiController]
    [Route ("api/vehicleTypes")]
    public class VehicleTypesController : Controller
    {

        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;
        private readonly ILogger<VehicleTypesController> logger;
        public VehicleTypesController(ILogger<VehicleTypesController> logger, ApplicationDbContext context, IMapper mapper )
                                                                  
        {
            this.logger = logger;
            this.mapper = mapper;   
            this.context = context;
        }

        //Select * from VehicleType
        [HttpGet]
        public async Task<ActionResult<List<VehicleType>>> Get()
        {
            return await context.VehicleType.ToListAsync();
        }


        //Busqueda por parametro
        [HttpGet("{id:int}")]
        public async Task<ActionResult<VehicleTypeDTO>> Get(int id)
        {
            var vehicleType = await context.VehicleType.FirstOrDefaultAsync(x => x.Id == id);

            if (vehicleType == null)
            {
                return NotFound();
            }
            return mapper.Map<VehicleTypeDTO>(vehicleType); 
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]VehicleTypeCreacionDTO vehicleTypeCreacionDTO)
        {
             var vehicleType = mapper.Map<VehicleType>(vehicleTypeCreacionDTO);
             context.Add(vehicleType);
             await context.SaveChangesAsync();
             return NoContent();// 204
        }

       [HttpPut("{id}")]
        public async Task<ActionResult> Put(VehicleType vehicleType, int id)
        {
            if (vehicleType.Id != id)
            {
                return BadRequest("El tipo de vehiculo no existe");

            }
                var existe = await context.VehicleType.AnyAsync(x => x.Id == id);

                if(!existe)
                {
                    return NotFound();
                }
                context.Update(vehicleType);
                await context.SaveChangesAsync();
                return Ok();//200
         }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete( int id)
        {
            
            var vehicleType = await context.VehicleType.FirstOrDefaultAsync (x => x.Id == id);

            if (vehicleType == null)
            {
                return NotFound();
            }
            context.Remove(vehicleType);
            await context.SaveChangesAsync();
            return NoContent();//204
        } 
       

    }

    }
