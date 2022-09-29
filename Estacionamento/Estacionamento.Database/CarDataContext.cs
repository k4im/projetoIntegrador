using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estacionamento.Models;
using Microsoft.EntityFrameworkCore;

namespace Estacionamento.Database
{
    public class CarDataContext : DbContext
    {
        public CarDataContext(DbContextOptions<CarDataContext> options) : base(options)
        {}

        public DbSet<Car>? Cars { get; set; }
    }
}