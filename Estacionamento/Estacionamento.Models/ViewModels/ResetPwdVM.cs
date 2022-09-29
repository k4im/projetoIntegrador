using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Models.ViewModels
{
    public class ResetPwdVM
    {
        [Required(ErrorMessage = "Campo é obrigatório")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Campo é obrigatório")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Campo precisa conter de {0} a {2} caracteres", MinimumLength = 6)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Campo é obrigatório")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "As senhas precisam ser iguais!")]
        public string? ConfirmPassowrd { get; set; }
        
        public string? Code { get; set; }
        
    }
}
