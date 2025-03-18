using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_end.Models;

[Table("TB_PJ_PESSOA_JURIDICA")]
public class PessoaJuridica
{
    [Key]
    [Column("ID_PESSOA_JURIDICA")]
    public Guid IdPessoaJuridica { get; set; }
    
    [Column("NM_RAZAO_SOCIAL")]
    public string NomeRazaoSocial { get; set; }
    
    [Column("NR_CNPJ")]
    public string Cnpj { get; set; }
    
    [Column("NM_EMPRESARIAL")]
    public string NomeEmpresarial { get; set; }
}