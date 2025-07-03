using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinal.Models;

public class UserRoll
{
    public int Id { get; set; }
    [ForeignKey("ClienteId")]
    public virtual Cliente? Cliente { get; set; }

    [ForeignKey("UsuarioId")]
    public virtual IdentityUser Usuario { get; set; }
    
    
}
