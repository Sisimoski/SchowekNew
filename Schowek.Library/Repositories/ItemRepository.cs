using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Schowek.Library.Data;
using Schowek.Library.Interfaces;
using Schowek.Library.Models;

namespace Schowek.Library.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly DataContext dataContext;
        public ItemRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<Item> AddItem(Item item)
        {
            await dataContext.Items.AddAsync(item);
            await dataContext.SaveChangesAsync();
            return item;
        }

        public async Task<Item> DeleteItem(int itemId)
        {
            Item item = dataContext.Items.Find(itemId);
            if (item is null) return null!;

            dataContext.Items.Remove(item);
            await dataContext.SaveChangesAsync();

            return item;
        }

        public async Task<Item> GetItem(int itemId)
        {
            var item = await dataContext.Items.FindAsync(itemId);
            return item;
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            var items = await dataContext.Items.ToListAsync();
            return items;
        }

        public async Task<Item> UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}