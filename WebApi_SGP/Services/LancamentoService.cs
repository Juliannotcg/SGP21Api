using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_SGP.Model;
using WebApi_SGP.Repository;
using WebApi_SGP.ViewModel;

namespace WebApi_SGP.Services
{
    public class LancamentoService
    {
        private readonly LancamentoRepository _lancamentoRepository;
        private readonly UsuarioRepository _usuarioRepository;
        private readonly FolhaPontoRepository _folhaPontoRepository;

        public LancamentoService(LancamentoRepository lancamentoRepository,
            UsuarioRepository usuarioRepository,
            FolhaPontoRepository folhaPontoRepository)
        {
            _lancamentoRepository = lancamentoRepository;
            _usuarioRepository = usuarioRepository;
            _folhaPontoRepository = folhaPontoRepository;
        }
    
        public bool PermiteInserir(LancamentoViewModel lancamentoViewModel)
        {
            var usuario = _usuarioRepository.GetUsuarioLogin(lancamentoViewModel.Login);
            var lancamento = new Lancamento();

            lancamento.FolhaPonto = new FolhaPonto();
            lancamento.FolhaPonto.FlpData = DateTime.Now;

            lancamento.FolhaPonto.Usuario = usuario;

            lancamento.FolhaPonto = _folhaPontoRepository.GetFolhaPonto(lancamento.FolhaPonto);



            return true;

        }
    }
}
