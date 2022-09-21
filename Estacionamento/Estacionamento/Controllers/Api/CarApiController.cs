using Estacionamento.Repositories.ApiRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Controllers.Api
{
    [Route("api/cars")]
    [ApiController]
    public class CarApiController : Controller
    {
        private readonly ICarsRepository _repo;

        public CarApiController(ICarsRepository repo) => _repo = repo;

        public IActionResult Index()
        {
            var cars = _repo.GetCars();
            return Ok(ViewBag.Cars = cars);
        }
    }
}
