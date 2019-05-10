using Microsoft.AspNetCore.Mvc;
using WebApi_SGP.Helpers;
using WebApi_SGP.Model;
using WebApi_SGP.Repository;
using WebApi_SGP.ViewModel;

namespace WebApi_SGP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        public LoginController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] UsuarioViewModel usuarioViewModel)
        {
            if (!string.IsNullOrEmpty(usuarioViewModel.Login) ||
                (!string.IsNullOrEmpty(usuarioViewModel.Senha)))
            {
                var usuario = new Usuario();
                usuario.UsuLogin = usuarioViewModel.Login.ToString().ToUpper();
                usuario.UsuSenha = ConverterMD5.RetornarMD5String(usuarioViewModel.Login + usuarioViewModel.Senha.ToString().ToUpper() + usuarioViewModel.Login);

                if (_usuarioRepository.Login(usuario))
                    return Ok();
            }
            return BadRequest();
        }
    }
}