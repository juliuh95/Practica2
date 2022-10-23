using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Practica2.Data;

namespace Practica2.Controllers
{
    [ApiController]
    [Route ("api/vehicleTypes")]
    public class VehicleTypesController : Controller
    {
        public VehicleTypesController(ApplicationDbContext context, IMapper mapper )
                                                                    :base(context, mapper)
        {
            
        }

    }
}