using System.Collections.Generic;
using Estacionamento.Database;
using Estacionamento.Models;
using Estacionamento.Repositories.ApiRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Estacionamento.Controllers
{
    [Authorize(Roles= "Admin,Gerente,Funcionario")]
    public class DashBoardController : Controller
    {

        private readonly ICarsRepository _carsRepository;

        public DashBoardController(ICarsRepository carsRepository) => _carsRepository = carsRepository;

        public IActionResult Index()
        {
            var cars = _carsRepository.GetCars();
            return View(cars);
        }

        public IActionResult AddCar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCar(Car model)
        {
            if (!ModelState.IsValid) return View(model);
            _carsRepository.AddCar(model);
            return RedirectToAction("Index", "DashBoard");
        }

        public IActionResult Update(int? id)
        {
            if (id == null || id == 0) return NotFound();
            var car = _carsRepository.GetCarById(id);
            if (car == null) return NotFound();
            return View(car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromForm]Car model)
        {
            if (model == null) return NotFound();
            _carsRepository.UpdateCar(model);
            return RedirectToAction("Index", "DashBoard");
        }
        
        public IActionResult Delete(int id)
        {
            var car = _carsRepository.GetCarById(id);
            if (car == null) return NotFound();
            return View(car);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute]int? id)
        {
            if (id == null || id == 0) return NotFound();
            _carsRepository.DeleteCar(id);
            return RedirectToAction("Index", "DashBoard");
        }

    }
}