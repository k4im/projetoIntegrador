using System.Collections.Generic;
using Estacionamento.Database;
using Estacionamento.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Estacionamento.Controllers
{
    [Authorize]
    public class DashBoardController : Controller
    {

        private readonly CarDataContext _db;

        public DashBoardController(CarDataContext db) => _db = db;

        public IActionResult Index()
        {
            IEnumerable<Car> cars = _db.Cars;
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
            var car = new Car()
            {
                Id = model.Id,
                Marca = model.Marca,
                Modelo = model.Modelo,
                Placa = model.Placa,
                Chegada = model.Chegada

            };
            _db.Cars.Add(car);
            _db.SaveChanges();
            return RedirectToAction("Index", "DashBoard");
        }

        public IActionResult Update(int? id)
        {
            if (id == null || id == 0) return NotFound();
            var car = _db.Cars.Find(id);
            if (car == null) return NotFound();
            return View(car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromRoute]int id, [FromForm]Car model)
        {
            if (model == null) return NotFound();
            _db.Entry<Car>(model).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index", "DashBoard");
        }
        
        
        public IActionResult Delete(int id)
        {
            var car = _db.Cars.Find(id);
            if (car == null) return NotFound();
            return View(car);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute]int? id)
        {
            if (id == null || id == 0) return NotFound();
            var car = _db.Cars.Find(id);
            if (car == null) return NotFound();
            _db.Cars.Remove(car);
            _db.SaveChanges();
            return RedirectToAction("Index", "DashBoard");

        }


    }
}
