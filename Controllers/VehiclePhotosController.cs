using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica2.Data;
using Practica2.DTOs;
using Practica2.Entidades;
using Practica2.Servicios;

namespace Practica2.Controllers
{

    [ApiController]
    [Route("api/vehiclePhotos")]
    public class VehiclePhotosController : Controller
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;
        private readonly ILogger<VehiclePhotosController> logger;
        private readonly IAlmacenadorArchivos almacenadorArchivos;
        private readonly string contenedor = "Files";
        public VehiclePhotosController(ILogger<VehiclePhotosController> logger, ApplicationDbContext context, IMapper mapper, IAlmacenadorArchivos almacenadorArchivos)


        {
            this.logger = logger;
            this.mapper = mapper;
            this.context = context;
            this.almacenadorArchivos = almacenadorArchivos;
        }

        //Select * from VehicleType
        [HttpGet]
        public async Task<ActionResult<List<VehiclePhoto>>> Get()
        {
            return await context.VehiclePhoto.ToListAsync();
        }


        //Busqueda por parametro
        [HttpGet("{id:int}")]
        public async Task<ActionResult<VehiclePhotoDTO>> Get(int id)
        {
            var vehiclePhoto = await context.VehiclePhoto.FirstOrDefaultAsync(x => x.Id == id);

            if (vehiclePhoto == null)
            {
                return NotFound();
            }
            return mapper.Map<VehiclePhotoDTO>(vehiclePhoto);
        }

      

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] VehiclePhotoCreacionDTO vehiclePhotoCreacionDTO)
        {
            var archivos = mapper.Map<VehiclePhoto>(vehiclePhotoCreacionDTO);
            if (vehiclePhotoCreacionDTO.Foto != null)
            {
              archivos.Foto = await almacenadorArchivos.GuardarArchivo(contenedor, vehiclePhotoCreacionDTO.Foto);
            }

            context.Add(archivos);
            await context.SaveChangesAsync();
            return NoContent();// 204
        }

        /*[HttpPut("{id}")]
        public async Task<ActionResult> Put(VehiclePhoto vehiclePhoto, int id)
        {
            if (vehiclePhoto.Id != id)
            {
                return BadRequest("El tipo de vehiculo no existe");

            }
            var existe = await context.VehiclePhoto.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }
            context.Update(vehiclePhoto);
            await context.SaveChangesAsync();
            return Ok();//200
        }*/

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            var vehiclePhoto = await context.VehiclePhoto.FirstOrDefaultAsync(x => x.Id == id);

            if (vehiclePhoto == null)
            {
                return NotFound();
            }
            context.Remove(vehiclePhoto);
            await context.SaveChangesAsync();
            return NoContent();//204
        }
    }
}
