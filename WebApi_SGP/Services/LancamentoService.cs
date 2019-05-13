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

            //RecalcularDadosFolhaPonto2018(lancamento);



            return true;

        }


        //public bool RecalcularDadosFolhaPonto2018(Lancamento lanc)
        //{
        //    List<Lancamento> lancamentos = _lancamentoRepository.GetListLancamento(lanc);

        //    if (lancamentos.Count == 0)
        //    {
        //        //Excluir
        //        //return executar(nucleo, Operacao.Excluir, ref folha);
        //    }
        //    int entradas = 0;
        //    int saidas = 0;
        //    int abonos = 0;
        //    Dictionary<int, Abono> abonosVistos = new Dictionary<int, Abono>();
        //    TimeSpan trabalhadas = new TimeSpan();
        //    TimeSpan abonadas = new TimeSpan();
        //    TimeSpan planoIncentivo = new TimeSpan();
        //    Lancamento inicio = null;
        //    foreach (Lancamento lancamento in lancamentos)
        //    {
        //        if (lancamento.LanTipo.Equals(ETipoLancamento.Entrada))
        //            entradas++;
        //        else if (lancamento.LanTipo.Equals(ETipoLancamento.FimTurno))
        //            saidas++;

        //        if (lancamento.Abono != null && !abonosVistos.ContainsKey(lancamento.Abono.AbnId))
        //        {
        //            if (!lancamento.Abono.AbnTipo.Ferias)
        //                abonadas += CalcularAbonadas(lancamento.Abono);
        //            abonosVistos.Add(lancamento.Abono.Prop<int>("AbnId"), lancamento.Abono);
        //            abonos++;
        //        }
        //        if (inicio == null)
        //            inicio = lancamento;
        //        else
        //        {
        //            if (!inicio.Tipo.Entrada) throw new Exception("Erro ao calcular horas trabalhadas. O lançamento inicial do período não é de entrada.");
        //            if (!lancamento.Tipo.Saida) throw new Exception("Erro ao calcular horas trabalhadas. O lançamento final do período não é de saída.");
        //            if (inicio.DataHora > lancamento.DataHora) throw new Exception("Erro ao calcular horas trabalhadas. Data inicial maior que a data final.");
        //            if (((!BaseObjeto.EhNulo(inicio.Abono) && inicio.Abono.TipoAbono.Id != 6) || (!BaseObjeto.EhNulo(lancamento.Abono) && lancamento.Abono.TipoAbono.Id != 6))
        //                && (inicio.Abono.Id != lancamento.Abono.Id)) throw new Exception("Erro ao calcular horas trabalhadas. Entrada e saída possuem abonos diferentes.");
        //            if (BaseObjeto.EhNulo(lancamento.Abono))
        //                trabalhadas += lancamento.DataHora - inicio.DataHora;
        //            planoIncentivo += CalcularPlanoIncentivo(inicio, lancamento);
        //            inicio = null;
        //        }
        //    }

        //    lanc.FolhaPonto.FlpEntradas = entradas;
        //    lanc.FolhaPonto.FlpSaidas = saidas;
        //    lanc.FolhaPonto.FlpAbonos = abonos;
        //    lanc.FolhaPonto.FlpTrabalhadas = trabalhadas.Ticks;
        //    lanc.FolhaPonto.FlpAbonadas = abonadas.Ticks;
        //    lanc.FolhaPonto.FlpHorasPlanoIncentivo = planoIncentivo.Ticks;
        //    lanc.FolhaPonto.FlpCumpriuPlanoIncentivo = planoIncentivo.Ticks >= Parametros.Prop<DateTime>(Constantes.Parametros.QuantidadeHorasPlanoIncentivo).TimeOfDay.Ticks;

         
        //    if (!executar(nucleo, Operacao.Editar, ref temp))
        //    {
        //        nucleo.ListaErros.Add("Ocorreu um erro durante a atualização dos valores da folha de ponto.",
        //            "CTRLFLHPNTRCLCLRDDSFLHPNT-001", "", "", GetType().ToString(), TipoErro.Sistema);
        //        return false;
        //    }
        //    else
        //        return true;

        //    return true;
        //}

        //private TimeSpan CalcularPlanoIncentivo(Lancamento inicio, Lancamento fim)
        //{
        //    if (inicio.LanDataHora > fim.LanDataHora) throw new Exception("Erro ao calcular as horas do plano de incentivo. Data inicial maior que a data final");
        //    if (inicio.Abono != null || fim.Abono != null)
        //    {
        //        if (inicio.Abono.AbnId != fim.Abono.AbnId) throw new Exception("Erro ao calcular as horas do plano de incentivo. Dois lançamentos com abonos diferentes foram informados");
        //        if (inicio.Abono.AbnHoraInicio != inicio.LanDataHora) throw new Exception("Erro ao calcular as horas do plano de incentivo. Hora inicial do abono tem valor diferente do lançamento que ele gerou");
        //        if (fim.Abono.AbnHoraFim != fim.LanDataHora) throw new Exception("Erro ao calcular as horas do plano de incentivo. Hora final do abono tem valor diferente do lançamento que ele gerou");
        //    }

            
        //    TimeSpan inicioCorreto = inicio.LanDataHora.TimeOfDay >= Parametros.Prop<DateTime>(Constantes.Parametros.InicioPlanoIncentivo).TimeOfDay ? inicio.DataHora.TimeOfDay : Parametros.Prop<DateTime>(Constantes.Parametros.InicioPlanoIncentivo).TimeOfDay;
        //    TimeSpan fimCorreto = fim.LanDataHora.TimeOfDay <= Parametros.Prop<DateTime>(Constantes.Parametros.FimPlanoIncentivo).TimeOfDay ? fim.DataHora.TimeOfDay : Parametros.Prop<DateTime>(Constantes.Parametros.FimPlanoIncentivo).TimeOfDay;
        //    return fimCorreto - inicioCorreto;
        //}
    }
}
