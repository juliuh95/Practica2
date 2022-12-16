using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica3.Data;
using Practica3.DTOs;
using Practica3.Entidades;

namespace Practica3.Controllers
{
    [ApiController]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;
        private readonly ILogger<ProductsController> logger;
        public ProductsController(ILogger<ProductsController> logger, ApplicationDbContext context, IMapper mapper)

        {
            this.logger = logger;
            this.mapper = mapper;
            this.context = context;
        }

        //Select * from Product
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return await context.Product.ToListAsync();
        }


        //Busqueda por parametro
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            var Product = await context.Product.FirstOrDefaultAsync(x => x.Id == id);

            if (Product == null)
            {
                return NotFound();
            }
            return mapper.Map<ProductDTO>(Product);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductCreacionDTO ProductCreacionDTO)
        {
            var Product = mapper.Map<ProductType>(ProductCreacionDTO);
            context.Add(Product);
            await context.SaveChangesAsync();
            return NoContent();// 204
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Product Product, int id)
        {
            if (Product.Id != id)
            {
                return BadRequest("El tipo de vehiculo no existe");

            }
            var existe = await context.Product.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }
            context.Update(Product);
            await context.SaveChangesAsync();
            return Ok();//200
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            var Product = await context.Product.FirstOrDefaultAsync(x => x.Id == id);

            if (Product == null)
            {
                return NotFound();
            }
            context.Remove(Product);
            await context.SaveChangesAsync();
            return NoContent();//204
        }
    }
}
