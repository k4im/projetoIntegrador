using Estacionamento.Database;
using Estacionamento.Helpers;
using Estacionamento.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Repositories.ApiRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _db;

        public UserRepository(DataContext db) => _db = db;

        public List<AdminVM> GetAdmins()
        {
            var usersAdmin = (from user in _db.Users
                         join userRole in _db.UserRoles on user.Id equals userRole.UserId
                         join roles in _db.Roles.Where(x => x.Name == UserHelper.Admin) on userRole.RoleId equals roles.Id
                         select new AdminVM { Id = user.Id, Name = user.Name }).ToList();
            return usersAdmin;
        }

        public List<FuncionarioVM> GetFuncionarios()
        {
            var usersFuncionarios = (from user in _db.Users
                               join userRole in _db.UserRoles on user.Id equals userRole.UserId
                               join roles in _db.Roles.Where(x => x.Name == UserHelper.Funcionario) on userRole.RoleId equals roles.Id
                               select new FuncionarioVM
                               { Id = user.Id, Name = user.Name}).ToList();
            return usersFuncionarios;
        }

        public List<GerenteVM> GetGerentes()
        {
            var usersGerentes = (from user in _db.Users
                                 join userRole in _db.UserRoles on user.Id equals userRole.UserId
                                 join roles in _db.Roles.Where(x => x.Name == UserHelper.Gerente) on userRole.RoleId equals roles.Id
                                 select new GerenteVM
                                 { Id = user.Id, Name = user.Name}).ToList();
            return usersGerentes;
        }
    }
}
