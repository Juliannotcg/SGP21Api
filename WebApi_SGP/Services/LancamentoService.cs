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

            if (!_folhaPontoRepository.VerificarExisteFolhaDia(lancamento.FolhaPonto))
            {
                lancamento.FolhaPonto.FlpData = DateTime.Now;
                lancamento.FolhaPonto.FlpTrabalhadas = 0;
                lancamento.FolhaPonto.FlpAbonadas = 0;
                lancamento.FolhaPonto.FlpHorasPlanoIncentivo = 0;
                lancamento.FolhaPonto.FlpEntradas = 0;
                lancamento.FolhaPonto.FlpSaidas = 0;
                lancamento.FolhaPonto.FlpAbonos = 0;
                lancamento.FolhaPonto.FlpCumpriuPlanoIncentivo = false;

                _folhaPontoRepository.Add(lancamento.FolhaPonto);
            }

            lancamento.LanDataHora = DateTime.Now;
            lancamento.LanTipo = Convert.ToInt16(lancamentoViewModel.LanTipo);
            lancamento.LanEdicaoManual = false;
            lancamento.LanObservacao = "";

            _lancamentoRepository.Add(lancamento);
            return true;

        }
    }
}
