using CarentalLibrary.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarentalLibrary.DataAcces.Context
{
    public class CarentalContext:DbContext
    {
        public CarentalContext(DbContextOptions<CarentalContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        public DbSet<Car> cars { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Rental> rentals { get; set; }
    }
}
