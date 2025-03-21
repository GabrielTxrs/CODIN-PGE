namespace back_end.Models;

public class AtualizacaoProcesso
{
    public AtualizacaoProcesso(ProcessoJuridico processoJuridico,
        string descricao, DateTime dataAtualizacao, string tramitacao)
    {
        ProcessoJuridico = processoJuridico;
        Descricao = descricao;
        DataAtualizacao = dataAtualizacao;
        Tramitacao = tramitacao;
    }

    public List<Documento> Documentos = new List<Documento>();
    public ProcessoJuridico ProcessoJuridico { get; set; }
    public string Descricao { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public string Tramitacao { get; set; }
}