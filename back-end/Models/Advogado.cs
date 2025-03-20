using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_end.Models;

public class Advogado (
    int idAdvogado,
    bool isProcurador,
    string oab,
    string nomePessoaFisica,
    string? nomeSocial,
    string cpf,
    string celular,
    string? telefone,
    string email,
    DateOnly dataNascimento)
{
    public int IdAdvogado { get; init; } = idAdvogado;
    public bool IsProcurador { get; set; } = isProcurador;
    public string Oab { get; set; } = oab;
    public string NomePessoaFisica { get; set; } = nomePessoaFisica;
    public string? NomeSocial { get; set; } = nomeSocial;
    public string Cpf { get; set; } = cpf;
    public string Celular {get ; set;} = celular;
    public string? Telefone {get ; set;} = telefone;
    public string Email {get ; set;} = email;
    public DateOnly DataNascimento { get; set; } = dataNascimento;
}