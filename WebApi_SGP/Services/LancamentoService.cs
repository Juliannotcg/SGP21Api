using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_SGP.Enums;
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
    
        public bool InserirLancamento(LancamentoViewModel lancamentoViewModel)
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
            lancamento.LanTipo = (ETipoLancamento)Convert.ToInt32(lancamentoViewModel.LanTipo);
            lancamento.LanEdicaoManual = false;
            lancamento.LanObservacao = "";

            _lancamentoRepository.Add(lancamento);

            RecalcularDadosFolhaPonto2018(lancamento);



            return true;

        }


        public bool RecalcularDadosFolhaPonto2018(Lancamento lanc)
        {
            List<Lancamento> lancamentos = _lancamentoRepository.GetListLancamento(lanc);

            if (lancamentos.Count == 0)
            {
                //Excluir
                //return executar(nucleo, Operacao.Excluir, ref folha);
            }
            int entradas = 0;
            int saidas = 0;
            int abonos = 0;
            Dictionary<int, ObjAbono> abonosVistos = new Dictionary<int, ObjAbono>();
            TimeSpan trabalhadas = new TimeSpan();
            TimeSpan abonadas = new TimeSpan();
            TimeSpan planoIncentivo = new TimeSpan();
            Lancamento inicio = null;
            foreach (Lancamento lancamento in lancamentos)
            {
                if (lancamento.LanTipo.Equals(ETipoLancamento.Entrada))
                    entradas++;
                else if (lancamento.LanTipo.Equals(ETipoLancamento.FimTurno))
                    saidas++;

                if (!BaseObjeto.EhNulo(lancamento.Abono) && !abonosVistos.ContainsKey(lancamento.Abono.Prop<int>("AbnId")))
                {
                    if (!lancamento.Abono.TipoAbono.Ferias)
                        abonadas += CalcularAbonadas(lancamento.Abono);
                    abonosVistos.Add(lancamento.Abono.Prop<int>("AbnId"), lancamento.Abono);
                    abonos++;
                }
                if (inicio == null)
                    inicio = lancamento;
                else
                {
                    if (!inicio.Tipo.Entrada) throw new Exception("Erro ao calcular horas trabalhadas. O lançamento inicial do período não é de entrada.");
                    if (!lancamento.Tipo.Saida) throw new Exception("Erro ao calcular horas trabalhadas. O lançamento final do período não é de saída.");
                    if (inicio.DataHora > lancamento.DataHora) throw new Exception("Erro ao calcular horas trabalhadas. Data inicial maior que a data final.");
                    if (((!BaseObjeto.EhNulo(inicio.Abono) && inicio.Abono.TipoAbono.Id != 6) || (!BaseObjeto.EhNulo(lancamento.Abono) && lancamento.Abono.TipoAbono.Id != 6))
                        && (inicio.Abono.Id != lancamento.Abono.Id)) throw new Exception("Erro ao calcular horas trabalhadas. Entrada e saída possuem abonos diferentes.");
                    if (BaseObjeto.EhNulo(lancamento.Abono))
                        trabalhadas += lancamento.DataHora - inicio.DataHora;
                    planoIncentivo += CalcularPlanoIncentivo(inicio, lancamento);
                    inicio = null;
                }
            }
            folhaPonto.Propriedades["FlpEntradas"].Valor = entradas;
            folhaPonto.Propriedades["FlpSaidas"].Valor = saidas;
            folhaPonto.Propriedades["FlpAbonos"].Valor = abonos;
            folhaPonto.Propriedades["FlpTrabalhadas"].Valor = trabalhadas.Ticks;
            folhaPonto.Propriedades["FlpAbonadas"].Valor = abonadas.Ticks;
            folhaPonto.Propriedades["FlpHorasPlanoIncentivo"].Valor = planoIncentivo.Ticks;
            folhaPonto.Propriedades["FlpCumpriuPlanoIncentivo"].Valor = planoIncentivo.Ticks >= Parametros.Prop<DateTime>(Constantes.Parametros.QuantidadeHorasPlanoIncentivo).TimeOfDay.Ticks;
            BaseObjeto temp = folhaPonto.Clone();
            if (!executar(nucleo, Operacao.Editar, ref temp))
            {
                nucleo.ListaErros.Add("Ocorreu um erro durante a atualização dos valores da folha de ponto.",
                    "CTRLFLHPNTRCLCLRDDSFLHPNT-001", "", "", GetType().ToString(), TipoErro.Sistema);
                return false;
            }
            else
                return true;

            return true;
        }
    }
}
