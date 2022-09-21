using Estacionamento.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Repositories.ApiRepositories
{
    public interface IUserRepository
    {
        List<AdminVM> GetAdmins();
        List<GerenteVM> GetGerentes();
        List<FuncionarioVM> GetFuncionarios();

    }
}
