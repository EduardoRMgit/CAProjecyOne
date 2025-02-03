using Microsoft.EntityFrameworkCore;
using NorthWind.Sales.Backend.BusinessObjects.Entities;
using Northwind.Sales.Backend.Repositories.Entities;
using NorthWind.Sales.Backend.BusinessObjects.ValueObjects;
using System.Reflection;

namespace NorthWind.Sales.Backend.DataContext.EFCore.DataContext
{
    // contexto de datos base de entity framework
    internal class NorthWindContext: DbContext
    {
        // conocimientos de Entity Framework => 
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=PruebaDB");
        }

        // archivos de configuración y aplicarlos aquí
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly());

        }

        // tablas para tiempo de diseño => no se usa en tiempo de ejecución, pero lo quiero que para 
        //que con este contexto, pueda crear la base de datos
        public DbSet<Order> Orders { get; set; }
        public DbSet<Northwind.Sales.Backend.Repositories.Entities.OrderDetail> OrderDetails { get; set; }
    }
}
