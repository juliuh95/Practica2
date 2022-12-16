using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica3.Data;
using Practica3.DTOs;
using Practica3.Entidades;

namespace Practica3.Controllers
{
    [ApiController]
    [Route("api/historys")]
    public class HistorysController : Controller
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;
        private readonly ILogger<HistorysController> logger;
        public HistorysController(ILogger<HistorysController> logger, ApplicationDbContext context, IMapper mapper)

        {
            this.logger = logger;
            this.mapper = mapper;
            this.context = context;
        }

        //Select * from History
        [HttpGet]
        public async Task<ActionResult<List<History>>> Get()
        {
            return await context.History.ToListAsync();
        }


        //Busqueda por parametro
        [HttpGet("{id:int}")]
        public async Task<ActionResult<HistoryDTO>> Get(int id)
        {
            var history = await context.History.FirstOrDefaultAsync(x => x.Id == id);

            if (history == null)
            {
                return NotFound();
            }
            return mapper.Map<HistoryDTO>(history);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] HistoryCreacionDTO historyCreacionDTO)
        {
            var history = mapper.Map<History>(historyCreacionDTO);
            context.Add(history);
            await context.SaveChangesAsync();
            return NoContent();// 204
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(History history, int id)
        {
            if (history.Id != id)
            {
                return BadRequest("El tipo de vehiculo no existe");

            }
            var existe = await context.History.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }
            context.Update(history);
            await context.SaveChangesAsync();
            return Ok();//200
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            var history = await context.History.FirstOrDefaultAsync(x => x.Id == id);

            if (history == null)
            {
                return NotFound();
            }
            context.Remove(history);
            await context.SaveChangesAsync();
            return NoContent();//204
        }
    }
}
