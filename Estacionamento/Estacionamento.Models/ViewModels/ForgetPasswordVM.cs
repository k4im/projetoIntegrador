using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Models.ViewModels
{
    public class ForgetPasswordVM
    {
        [Required(ErrorMessage = "O campo é obrigatório")]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
