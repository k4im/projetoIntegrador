using Microsoft.AspNetCore.Identity;

namespace Estacionamento.Models
{
    public class AppUser : IdentityUser
    {
        public string? Name { get; set; }
    }
}
