namespace back_end.Models;

public class Documento
{
    public string IdDocumento { get; set; }
    public string Tipo { get; set; }
    public string Caminho { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public DateTime DataCriacao { get; set; }
    public string Codigo { get; set; }
}