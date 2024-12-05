using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Reflection.Emit;
using Microsoft.Data.SqlClient;
using CakeShopApp.Server.Models;
using CakeShopApp.Server.Controllers;


namespace CakeShopApp.Server.Contexts
{
    public class LoginContext : DbContext
    {
        public LoginContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<LoginModel> Login { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure SalesSummary as a keyless entity
            modelBuilder.Entity<LoginModel>().HasNoKey();

            // modelBuilder.UseSqlServer("Server=.;Database=Cakeshop;Integrated Security=True");
            // base.OnModelCreating(modelBuilder);

            // If you're mapping this to a database view, you can specify the view name
            // modelBuilder.Entity<SalesSummary>().ToView("SalesSummaryView");

            // For example, mapping to a SQL query:
            //modelBuilder.Entity<LoginModel>().ToSqlQuery(
            //    @"SELECT ProductName, SUM(Quantity) AS TotalQuantitySold, SUM(Price * Quantity) AS TotalSalesAmount
            //  FROM Sales
            //  GROUP BY ProductName");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
            base.OnConfiguring(optionsBuilder);
        }

        public async Task<bool> CheckRequestParametersAsync(string param1, string param2)
        {
            var sqlQuery = "SELECT UserName,Pass FROM Login WHERE UserName = @param1 AND Pass = @param2";
            var result = await Login.AnyAsync(x => x.userName == param1 && x.pass == param2);
            return result;
        }
    }
}
