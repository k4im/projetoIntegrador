using Estacionamento.Database;
using Estacionamento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Estacionamento.Repositories.ApiRepositories
{
    public class CarRepository : ControllerBase, ICarsRepository
    {
        private readonly DataContext _db;

        public CarRepository(DataContext db) => _db = db;
        public Task<List<Car>> GetCars()
        {
            var cars = _db.Cars;
            return cars.ToListAsync();
        }

        public async Task<ActionResult> InsertCar(Car model)
        {
            if(ModelState.IsValid)
            {
                var car = new Car()
                {
                    Id = model.Id,
                    Marca = model.Marca,
                    Modelo = model.Modelo,
                    Placa = model.Placa

                };
                _db.Cars.Add(car);
                await _db.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
        }

        public async Task<ActionResult> UpdateCar(Car model, int? id)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var car = _db.Cars.FirstOrDefaultAsync(c => c.Id == id);
                _db.Cars.Update(model);
                await _db.SaveChangesAsync();
                return Ok();
            }
            catch(Exception)
            {
                return StatusCode(500, "Não foi possivel atualizar o carro por motivos internos");
            }
        }
        public async Task<ActionResult> DeleteCar(int? id)
        {
            try
            {
                var car = await _db.Cars.FirstOrDefaultAsync(x => x.Id == id);
                if (car == null) return NotFound();
                _db.Cars.Remove(car);
                await _db.SaveChangesAsync();
                return Ok();
            }
            catch(Exception)
            {
                return StatusCode(500, "Não foi possivel atualizar o carro por motivos internos");
            }
        }


    }
}
