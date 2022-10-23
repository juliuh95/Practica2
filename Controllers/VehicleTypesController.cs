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

        [HttpGet("id:int")]
        public async Task<ActionResult<List<VehicleTypeDTO>>> Get(int id)
        {

        }

        }
}