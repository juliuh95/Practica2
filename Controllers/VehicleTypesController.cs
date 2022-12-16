using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica3.Data;
using Practica3.DTOs;
using Practica3.Entidades;

namespace Practica3.Controllers
{
    [ApiController]
    [Route ("api/ProductTypes")]
    public class ProductTypesController : Controller
    {

        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;
        private readonly ILogger<ProductTypesController> logger;
        public ProductTypesController(ILogger<ProductTypesController> logger, ApplicationDbContext context, IMapper mapper )
                                                                  
        {
            this.logger = logger;
            this.mapper = mapper;   
            this.context = context;
        }

        //Select * from ProductType
        [HttpGet]
        public async Task<ActionResult<List<ProductType>>> Get()
        {
            return await context.ProductType.ToListAsync();
        }


        //Busqueda por parametro
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductTypeDTO>> Get(int id)
        {
            var ProductType = await context.ProductType.FirstOrDefaultAsync(x => x.Id == id);

            if (ProductType == null)
            {
                return NotFound();
            }
            return mapper.Map<ProductTypeDTO>(ProductType); 
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]ProductTypeCreacionDTO ProductTypeCreacionDTO)
        {
             var ProductType = mapper.Map<ProductType>(ProductTypeCreacionDTO);
             context.Add(ProductType);
             await context.SaveChangesAsync();
             return NoContent();// 204
        }

       [HttpPut("{id}")]
        public async Task<ActionResult> Put(ProductType ProductType, int id)
        {
            if (ProductType.Id != id)
            {
                return BadRequest("El tipo de vehiculo no existe");

            }
                var existe = await context.ProductType.AnyAsync(x => x.Id == id);

                if(!existe)
                {
                    return NotFound();
                }
                context.Update(ProductType);
                await context.SaveChangesAsync();
                return Ok();//200
         }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete( int id)
        {
            
            var ProductType = await context.ProductType.FirstOrDefaultAsync (x => x.Id == id);

            if (ProductType == null)
            {
                return NotFound();
            }
            context.Remove(ProductType);
            await context.SaveChangesAsync();
            return NoContent();//204
        } 
       

    }

    }
