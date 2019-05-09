using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_SGP.Repository;
using WebApi_SGP.ViewModel;

namespace WebApi_SGP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentoController : ControllerBase
    {
        private readonly LancamentoRepository _lancamentoRepository;

        public LancamentoController(LancamentoRepository lancamentoRepository)
        {
            _lancamentoRepository = lancamentoRepository;
        }

        [HttpPost]
        public IActionResult Post([FromBody]LancamentoViewModel lancamentoViewModel)
        {

            return Ok();
        }
    }
}