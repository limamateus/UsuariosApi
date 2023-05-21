using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Dtos
{
    public class CreateUsuarioDto
    {

        [Required]

        public string Username { get; set; }
        [Required]
        public DateTime DataDeNascimento { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")] // um campo para comparar uma outra propriadade.
        public string RePassword { get; set; }






    }
}
