using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_end.Models;

[Table("TB_ADVOGADO")]
public class Advogado
{
    public Advogado(string oab, Guid idUsuario, Guid idPessoaFisica, Guid idPessoaJuridica, bool isProcurador)
    {
        IdAdvogado = Guid.NewGuid();
        IdUsuario = idUsuario;
        IdPessoaJuridica = idPessoaJuridica;
        IdPessoaFisica = idPessoaFisica;
        IsProcurador = isProcurador;
        Oab = oab;
    }
    
    [Key]
    [Column("ID_ADVOGADO")]
    public Guid IdAdvogado { get; init; }
    
    [Column("ID_USUARIO")]
    public Guid IdUsuario { get; set; }
    
    [Column("ID_PESSOA_JURIDICA")]
    public Guid? IdPessoaJuridica { get; set; }
    public PessoaJuridica? PessoaJuridica { get; set; }
    
    [Column("ID_PESSOA_FISICA")]
    public Guid? IdPessoaFisica { get; set; }
    
    [Column("IS_PROCURADOR")]
    public bool IsProcurador { get; set; }
    
    [Column("OAB", TypeName = "VARCHAR(1000)")]
    [Required]
    public string Oab { get; set; }
}