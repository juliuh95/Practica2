using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica3.Data;
using Practica3.DTOs;
using Practica3.Entidades;

namespace Practica3.Controllers
{
    [ApiController]
    [Route("api/details")]
    public class DetailsController : Controller
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;
        private readonly ILogger<DetailsController> logger;
        public DetailsController(ILogger<DetailsController> logger, ApplicationDbContext context, IMapper mapper)

        {
            this.logger = logger;
            this.mapper = mapper;
            this.context = context;
        }

        //Select * from ProductType
        [HttpGet]
        public async Task<ActionResult<List<Detail>>> Get()
        {
            return await context.Detail.ToListAsync();
        }


        //Busqueda por parametro
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DetailDTO>> Get(int id)
        {
            var detail = await context.Detail.FirstOrDefaultAsync(x => x.Id == id);

            if (detail == null)
            {
                return NotFound();
            }
            return mapper.Map<DetailDTO>(detail);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DetailCreacionDTO detailCreacionDTO)
        {
            var detail = mapper.Map<Detail>(detailCreacionDTO);
            context.Add(detail);
            await context.SaveChangesAsync();
            return NoContent();// 204
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Detail detail, int id)
        {
            if (detail.Id != id)
            {
                return BadRequest("El tipo de vehiculo no existe");

            }
            var existe = await context.Detail.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }
            context.Update(detail);
            await context.SaveChangesAsync();
            return Ok();//200
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            var detail = await context.Detail.FirstOrDefaultAsync(x => x.Id == id);

            if (detail == null)
            {
                return NotFound();
            }
            context.Remove(detail);
            await context.SaveChangesAsync();
            return NoContent();//204
        }

    }
}
