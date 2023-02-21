using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Schowek.Library.Data;
using Schowek.Library.Interfaces;
using Schowek.Library.Repositories;
using System.Threading.Tasks;
using Schowek.Library.Models;

namespace Schowek.ClientConsole
{
    internal class Program
    {
        private static DataContext? _appDbContext;
        private static ICatalogRepository? catalogRepository;
        private static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddScoped<ICatalogRepository, CatalogRepository>();
            services.AddDbContext<DataContext>(options => options.UseSqlite("DataSource=/Users/sisimoski/Documents/Development 👨‍💻/SchowekNew/Schowek.Library/Data/app.db"));

            var serviceProvider = services.BuildServiceProvider();
            var catalogRepository = serviceProvider.GetService<ICatalogRepository>();

            try
            {
                if (catalogRepository is not null)
                {
                    var catalogs = catalogRepository.GetCatalogs();
                    foreach (var item in catalogs)
                    {
                        System.Console.WriteLine(item.CatalogName);
                    }
                }
                else
                {
                    System.Console.WriteLine("null");
                }
            }
            catch (System.Exception)
            {
                throw;
            }


            /// Działa
            // var context = new DataContext();
            // System.Console.WriteLine(context.Database.GetConnectionString());
            // foreach (var item in context.Catalogs)
            // {
            //     Console.WriteLine(item.CatalogName);
            // }
        }
    }
}