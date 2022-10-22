using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchowekAPI.Data
{
    public class ItemRepository : IItemRepository
    {
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

        public Task<List<Item>> GetItems()
        {
            throw new NotImplementedException();
        }

        public Task<Item> UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}