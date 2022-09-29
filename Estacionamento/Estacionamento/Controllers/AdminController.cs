using Estacionamento.Models;
using Estacionamento.Repositories.ApiRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUserRepository _repository;

        public AdminController(IUserRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var users = _repository.GetUsers();
            return View(users);
        }

        public IActionResult Delete(string? id)
        {
            var user = _repository.GetUserById(id);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost([FromRoute] string id)
        {
            _repository.DeleteUser(id);
            return RedirectToAction("Index", "Admin");
        }

    }
}
