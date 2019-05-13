using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_SGP.Model;
using WebApi_SGP.Repository;
using WebApi_SGP.Services;
using WebApi_SGP.ViewModel;

namespace WebApi_SGP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentoController : ControllerBase
    {
        private readonly LancamentoRepository _lancamentoRepository;
        private readonly UsuarioRepository _usuarioRepository;
        private readonly FolhaPontoRepository _folhaPontoRepository;

        public LancamentoController(LancamentoRepository lancamentoRepository,
            UsuarioRepository usuarioRepository,
            FolhaPontoRepository folhaPontoRepository)
        {
            _lancamentoRepository = lancamentoRepository;
            _usuarioRepository = usuarioRepository;
            _folhaPontoRepository = folhaPontoRepository;
        }

        [HttpPost]
        public IActionResult Post([FromBody]LancamentoViewModel lancamentoViewModel)
        {
            var service = new LancamentoService(_lancamentoRepository,
            _usuarioRepository,
            _folhaPontoRepository);

            var retorno = service.InserirLancamento(lancamentoViewModel);

            return Ok();
        }
    }
}
