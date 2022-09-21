using Estacionamento.Models;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Repositories.ApiRepositories
{
    public interface ICarsRepository
    {
        Task<List<Car>> GetCars();
        Task<ActionResult> InsertCar(Car model);
        Task<ActionResult> UpdateCar(Car model, int? id);
        Task<ActionResult> DeleteCar(int? id);

    }
}
