using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Reflection.Emit;
using Microsoft.Data.SqlClient;
using CakeShopApp.Server.Models;
using CakeShopApp.Server.Controllers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CakeShopApp.Server.Contexts
{
    public class CakeContext : DbContext
    {
        public CakeContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<CakeModel> Cake { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure SalesSummary as a key entity
            modelBuilder.Entity<CakeModel>().HasKey(b => b.Cake_Id)
        .HasName("PrimaryKey_Cake_Id"); ;

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

        public async Task<CakeModel> GetCakeListAsync()
        {
            var sqlQuery = "SELECT Cake_Name, Price, Cake_Available, Category, Cake_Weight, Cake_Type, Cake_Description, Cake_Image FROM Cake ";
            using (var context = new CakeContext())
            {
                return await context.Cake.ToArrayAsync();
            }

            //var products = await Cake.QueryAsync<CakeModel>(sqlQuery);
            //return products.ToArray();

            //var result = await Cake.AnyAsync(x => x.userName == param1 && x.pass == param2);
            //return result;
        }
    }
}
