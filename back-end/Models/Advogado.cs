using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_end.Models;

[Table("TB_ADVOGADO")]
public class Advogado (
    bool isProcurador,
    string oab,
    string nomePessoaFisica,
    string? nomeSocial,
    string cpf,
    string celular,
    string? telefone,
    string email,
    DateTime dataNascimento)
{
    [Key]
    [Column("ID_ADVOGADO")]
    public int IdAdvogado { get; init; } = int.Abs(Guid.NewGuid().GetHashCode());
    
    [Column("IS_PROCURADOR")]
    public bool IsProcurador { get; set; } = isProcurador;
    
    [Column("OAB")]
    public string Oab { get; set; } = oab;
    
    [Column("NM_PESSOA_FISICA")]
    public string NomePessoaFisica { get; set; } = nomePessoaFisica;
    
    [Column("NM_SOCIAL")]
    public string? NomeSocial { get; set; } = nomeSocial;
    
    [Column("NR_CPF")]
    public string Cpf { get; set; } = cpf;
    
    [Column("NR_CELULAR")]
    public string Celular { get; set; } = celular;
    
    [Column("NR_TELEFONE")]
    public string? Telefone { get; set; } = telefone;
    
    [Column("EMAIL")]
    public string Email { get; set; } = email;
    
    [Column("DT_NASCIMENTO")]
    public DateTime DataNascimento { get; set; } = dataNascimento;
}