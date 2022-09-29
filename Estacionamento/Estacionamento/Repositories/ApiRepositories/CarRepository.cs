using Estacionamento.Database;
using Estacionamento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Estacionamento.Repositories.ApiRepositories
{
    public class CarRepository : ControllerBase, ICarsRepository
    {
        private readonly CarDataContext _db;

        public CarRepository(CarDataContext db) => _db = db;


        public List<Car> GetCars()
        {
            var cars = _db.Cars;
            return cars.ToList();
        }
        public Car GetCarById(int? id)
        {
            var car = _db.Cars.Find(id);
            return car;
        }

        public void AddCar(Car car)
        {
            var carro = new Car()
            {
                Id = car.Id,
                Marca = car.Marca,
                Modelo = car.Modelo,
                Placa = car.Placa,
                Chegada = car.Chegada
            };

            _db.Cars.Add(carro);
            _db.SaveChanges();
        }

        public void UpdateCar(Car car)
        {
            _db.Entry<Car>(car).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteCar(int? id)
        {
            var car = GetCarById(id);
            _db.Cars.Remove(car);
            _db.SaveChanges();
        }
    }
}
