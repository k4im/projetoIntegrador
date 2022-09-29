using Estacionamento.Models;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Repositories.ApiRepositories
{
    public interface ICarsRepository
    {
        List<Car> GetCars();
        Car GetCarById(int? id);
        void AddCar (Car car);
        void UpdateCar (Car car);
        void DeleteCar(int? id);

    }
}
