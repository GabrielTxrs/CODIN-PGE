namespace back_end.Models;

public class ProcessoJuridico
{
    public Advogado Procurador;
    public List<Cliente> Clientes = new List<Cliente>();
    public List<Advogado> Advogados = new List<Advogado>();
    public List<Prazo> Prazos = new List<Prazo>();
    public DateTime DataInicio;
    public DateTime DataConclusao;
    public string StatusAtual;
    public string Tramitacao;

    public ProcessoJuridico(Advogado procurador, DateTime dataInicio, DateTime dataConclusao,
        string statusAtual,
        string tramitacao)
    {
        Procurador = procurador;
        DataInicio = dataInicio;
        DataConclusao = dataConclusao;
        StatusAtual = statusAtual;
        Tramitacao = tramitacao;
    }
}