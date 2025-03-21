namespace back_end.Models;

public class Prazo
{
    public Prazo(int idPrazo, int idProcesso, string nome, string descricao, string tipo, DateTime dataInicio,
        DateTime dataFim)
    {
        IdPrazo = idPrazo;
        IdProcesso = idProcesso;
        Nome = nome;
        Descricao = descricao;
        Tipo = tipo;
        DataInicio = dataInicio;
        DataFim = dataFim;
    }

    public int IdPrazo { get; init; }
    public int IdProcesso { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    private string Tipo { get; set; }
    private DateTime DataInicio { get; set; }
    private DateTime DataFim { get; set; }
}