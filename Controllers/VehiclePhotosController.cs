using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica3.Data;
using Practica3.DTOs;
using Practica3.Entidades;
using Practica3.Servicios;

namespace Practica3.Controllers
{

    [ApiController]
    [Route("api/ProductPhotos")]
    public class ProductPhotosController : Controller
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;
        private readonly ILogger<ProductPhotosController> logger;
        private readonly IAlmacenadorArchivos almacenadorArchivos;
        private readonly string contenedor = "Files";
        public ProductPhotosController(ILogger<ProductPhotosController> logger, ApplicationDbContext context, IMapper mapper, IAlmacenadorArchivos almacenadorArchivos)


        {
            this.logger = logger;
            this.mapper = mapper;
            this.context = context;
            this.almacenadorArchivos = almacenadorArchivos;
        }

        //Select * from ProductType
        [HttpGet]
        public async Task<ActionResult<List<ProductPhoto>>> Get()
        {
            return await context.ProductPhoto.ToListAsync();
        }


        //Busqueda por parametro
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductPhotoDTO>> Get(int id)
        {
            var ProductPhoto = await context.ProductPhoto.FirstOrDefaultAsync(x => x.Id == id);

            if (ProductPhoto == null)
            {
                return NotFound();
            }
            return mapper.Map<ProductPhotoDTO>(ProductPhoto);
        }

      

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ProductPhotoCreacionDTO ProductPhotoCreacionDTO)
        {
            var archivos = mapper.Map<ProductPhoto>(ProductPhotoCreacionDTO);
            if (ProductPhotoCreacionDTO.Foto != null)
            {
              archivos.Foto = await almacenadorArchivos.GuardarArchivo(contenedor, ProductPhotoCreacionDTO.Foto);
            }

            context.Add(archivos);
            await context.SaveChangesAsync();
            return NoContent();// 204
        }

        /*[HttpPut("{id}")]
        public async Task<ActionResult> Put(ProductPhoto ProductPhoto, int id)
        {
            if (ProductPhoto.Id != id)
            {
                return BadRequest("El tipo de vehiculo no existe");

            }
            var existe = await context.ProductPhoto.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }
            context.Update(ProductPhoto);
            await context.SaveChangesAsync();
            return Ok();//200
        }*/

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            var ProductPhoto = await context.ProductPhoto.FirstOrDefaultAsync(x => x.Id == id);

            if (ProductPhoto == null)
            {
                return NotFound();
            }
            context.Remove(ProductPhoto);
            await context.SaveChangesAsync();
            return NoContent();//204
        }
    }
}
