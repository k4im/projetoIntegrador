using System.ComponentModel.DataAnnotations;

namespace Estacionamento.Models.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage ="O campo é obrigatório")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
