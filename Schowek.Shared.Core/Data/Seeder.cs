using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schowek.Shared.Core.Models;

namespace Schowek.Shared.Core.Data
{
    public class Seeder
    {
        private readonly DataContext _dbContext;
        public Seeder(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Catalogs!.Any())
                {
                    var catalogs = GetCatalogs();
                    _dbContext.AddRange(catalogs);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Catalog> GetCatalogs()
        {
            var catalogs = new List<Catalog>()
            {
                new Catalog()
                {
                    CatalogName = "Inspiracje",
                    Description = "Moje dzienne inspiracje, dzięki którym mogę polepszyć życie.",
                    OnCreated = DateTime.Now,
                    IsDeleted = false,
                    CatalogColor = Models.Enums.Colors.Blue,
                    Items = new List<Item>()
                    {
                        new Item()
                        {
                            Content = "Ex deserunt fugiat incididunt cillum labore mollit voluptate deserunt.",
                            ItemColor = Models.Enums.Colors.Red,
                            OnCreated = DateTime.Now.AddMinutes(5.0),
                        },
                        new Item()
                        {
                            Content = "Exercitation tempor reprehenderit pariatur sint.",
                            ItemColor = Models.Enums.Colors.Purple,
                            OnCreated = DateTime.Now.AddMinutes(10.0),
                        }
                    }
                },
                new Catalog()
                {
                    CatalogName = "Przepisy",
                    Description = "Ulubione przepisy na dobre danie dnia.",
                    OnCreated = DateTime.Now.AddHours(1.0),
                    CatalogColor = Models.Enums.Colors.Yellow,
                    Items = new List<Item>()
                    {
                        new Item()
                        {
                            Content = "Consequat incididunt elit deserunt sint officia irure dolor tempor qui exercitation.",
                            ItemColor = Models.Enums.Colors.Red,
                            OnCreated = DateTime.Now.AddHours(1.0).AddMinutes(5.0),
                        },
                        new Item()
                        {
                            Content = "Ea mollit excepteur Lorem occaecat veniam cillum et.",
                            ItemColor = Models.Enums.Colors.Purple,
                            OnCreated = DateTime.Now.AddHours(1.0).AddMinutes(10.0),
                        }
                    }
                }
            };
            return catalogs;
        }
    }
}