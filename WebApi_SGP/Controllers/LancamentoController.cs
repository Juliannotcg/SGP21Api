using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_SGP.Model;
using WebApi_SGP.Repository;
using WebApi_SGP.ViewModel;

namespace WebApi_SGP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentoController : ControllerBase
    {
        private readonly LancamentoRepository _lancamentoRepository;
        private readonly UsuarioRepository _usuarioRepository;

        public LancamentoController(LancamentoRepository lancamentoRepository, UsuarioRepository usuarioRepository)
        {
            _lancamentoRepository = lancamentoRepository;
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public IActionResult Post([FromBody]LancamentoViewModel lancamentoViewModel)
        {
            var retornarUsuario = _usuarioRepository.GetUsuarioLogin(lancamentoViewModel.Login);
            var folhaPonto = new FolhaPonto();
            folhaPonto.Usuario = retornarUsuario;

            return Ok();
        }
    }
}
