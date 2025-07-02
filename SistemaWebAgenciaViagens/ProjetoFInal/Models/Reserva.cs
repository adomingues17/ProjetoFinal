using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinal.Models;

public class Reserva
{
    [Key]
    public int IdReserva { get; set; }

    [Required(ErrorMessage = "Campo data de início obrigatório.")]
    [Display(Name = "Data de Início")]
    public DateTime DataInicio { get; set; }

    [Required(ErrorMessage = "Campo data de saída obrigatório.")]
    [Display(Name = "Data de Fim")]
    public DateTime DataFim { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    [Display(Name = "Valor Total")]
    public decimal ValorTotal { get; set; }

    //chave estrnageira para o local
    [Required]
    public int LocalId { get; set; }

    [ForeignKey("LocalId")]
    public virtual Local? Local { get; set; }

    //chave estrangeira para o usuário que fez a reserva
    [Required]
    public string? UsuarioId { get; set; }

    [ForeignKey("UsuarioId")]
    public virtual IdentityUser? Usuario { get; set; }



}
