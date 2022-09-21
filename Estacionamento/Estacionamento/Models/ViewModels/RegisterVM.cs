using System.ComponentModel.DataAnnotations;

namespace Estacionamento.Models.ViewModels
{
    public class RegisterVM
    {

        [Required(ErrorMessage = "Campo é obrigatório")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Campo é obrigatório")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Campo precisa conter de {0} a {2} caracteres", MinimumLength =6)]
        public string? Password { get; set; }
        
        [Required(ErrorMessage = "Campo é obrigatório")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "As senhas precisam ser iguais!")]
        public string? ConfirmPassowrd { get; set; }
        
        [Required(ErrorMessage = "Campo é obrigatório")]
        public string? RoleName { get; set; }
    }
}
