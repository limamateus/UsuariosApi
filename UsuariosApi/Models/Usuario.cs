using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Models
{
    public class Usuario : IdentityUser
    {
        [Required]
        public DateTime DataDeNascimento { get; set; }

        public Usuario() : base()
        {

        }

    }
}
