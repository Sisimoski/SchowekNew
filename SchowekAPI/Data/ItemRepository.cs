using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchowekAPI.Data
{
    public class ItemRepository : IItemRepository
    {
        private readonly DataContext db;

        public ItemRepository(DataContext db)
        {
            this.db = db;
        }

        public Task<Item> AddItem(Item item)
        {
            throw new NotImplementedException();
        }

        public Task<Item> DeleteItem(int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetItem(int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Item>> GetItems()
        {
            throw new NotImplementedException();
            // var items = await db.Items.ToListAsync();
            // return items;
        }

        public Task<Item> UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}