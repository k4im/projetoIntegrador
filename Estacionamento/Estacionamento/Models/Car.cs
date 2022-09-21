
using System.ComponentModel.DataAnnotations;

namespace Estacionamento.Models
{
    public class Car
    {
        [Key]    
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Campo é Obrigatório")]
        [StringLength(10, ErrorMessage = "O campo precisa conter de {0} a {2} caracteres", MinimumLength = 2)]
        [DataType("NVARCHAR")]
        public string? Marca { get; set; }

        [Required(ErrorMessage = "Campo é Obrigatório")]
        [StringLength(10, ErrorMessage = "O campo precisa conter de {0} a {2} caracteres", MinimumLength = 2)]
        [DataType("NVARCHAR")]
        public string? Modelo { get; set; }
        [Required(ErrorMessage = "Campo é Obrigatório")]
        [StringLength(10, ErrorMessage = "O campo precisa conter de {0} a {2} caracteres", MinimumLength = 2)]
        [DataType("NVARCHAR")]
        public string? Placa { get; set; }

        public DateTime Chegada { get; set; } = DateTime.UtcNow;
    }
}
