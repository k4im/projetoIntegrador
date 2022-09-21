using Estacionamento.Models.ViewModels;
using Estacionamento.Repositories.ApiRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Controllers.Api
{
    [Route("api/users")]
    [ApiController]
    public class UserApiController : Controller
    {
        private readonly IUserRepository _repo;

        public UserApiController(IUserRepository repo) => _repo = repo;

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<List<AdminVM>> GetAdmins()
        {
            var AdminUsers = _repo.GetAdmins();
            return Ok(ViewBag);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<List<AdminVM>> GetGerentes()
        {
            var GerenteUsers = _repo.GetGerentes();
            return Ok(GerenteUsers);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Gerente")]
        public ActionResult<List<AdminVM>> GetFuncionarios()
        {
            var FuncionariosUsers = _repo.GetFuncionarios();
            return Ok(FuncionariosUsers);
        }

    }
}
