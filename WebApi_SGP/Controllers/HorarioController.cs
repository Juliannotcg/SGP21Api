using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi_SGP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorarioController : ControllerBase
    {
        [HttpGet]
        public DateTime Get()
        {
            return DateTime.Now;
        }
    }
}
