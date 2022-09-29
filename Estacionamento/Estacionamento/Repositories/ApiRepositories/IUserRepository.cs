using Estacionamento.Models;
using Estacionamento.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Repositories.ApiRepositories
{
    public interface IUserRepository
    {
        List<AppUser> GetUsers();
        AppUser GetUserById(string? id);
        
        void DeleteUser(string? id);

        void UpdateUser (AppUser model);
    }
}
