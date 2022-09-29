using Estacionamento.Database;
using Estacionamento.Helpers;
using Estacionamento.Models;
using Estacionamento.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Estacionamento.Repositories.ApiRepositories
{
    
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _db;

        public UserRepository(DataContext db) => _db = db;

        public List<AppUser> GetUsers()
        {
             var users = (from user in _db.Users
                          join userRole in _db.UserRoles on user.Id equals userRole.UserId
                          join role in _db.Roles on userRole.RoleId equals role.Id
                          select new AppUser()
                          {
                              Id = user.Id,
                              Email = user.Email,
                              Name = role.Name
                          }).ToList();
            return users;
        }
        public AppUser GetUserById(string? id)
        {
            var user = _db.Users.Find(id);
            return user;
        }

        public void DeleteUser(string? id)
        {
            var user = GetUserById(id);
            _db.Users.Remove(user);
            _db.SaveChanges();
        }

        public void UpdateUser(AppUser model)
        {
            _db.Entry<AppUser>(model).State = EntityState.Modified;
            _db.SaveChanges();

        }
    }
}
