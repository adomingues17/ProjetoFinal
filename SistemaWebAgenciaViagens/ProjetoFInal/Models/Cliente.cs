using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models;

public class Cliente
{
    [Key]
    public int IdCliente { get; set; }

    [Required(ErrorMessage = "Campo nome é obrigatório")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "Campo CPF é obrigatório")]
    public string? CPF { get; set; }

    [Required(ErrorMessage = "Campo endereço é obrigatório")]
    public string? Endereco { get; set; }

    [Required(ErrorMessage = "Campo email é obrigatório")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Campo telefone é obrigatório")]
    public string? Telefone { get; set; }


}
