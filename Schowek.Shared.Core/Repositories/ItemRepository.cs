using Microsoft.EntityFrameworkCore;
using Schowek.Shared.Core.Data;
using Schowek.Shared.Core.Interfaces;
using Schowek.Shared.Core.Models;

namespace Schowek.Shared.Core.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly DataContext dataContext;
        public ItemRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<Item> GetItemAsync(int itemId)
        {
            var item = await dataContext.Items!.FindAsync(itemId);
            return item!;
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            var items = await dataContext.Items!.ToListAsync();
            return items;
        }

        public async Task<Item> AddItemAsync(Item item)
        {
            await dataContext.Items!.AddAsync(item);
            await dataContext.SaveChangesAsync();
            return item;
        }

        public async Task<Item?> UpdateItemAsync(int itemId, Item item)
        {
            Item? dbItem = dataContext.Items!.Find(itemId);
            if (dbItem is null) return null;

            dataContext.Entry(item).State = EntityState.Modified;

            dbItem.Content = item.Content;
            dbItem.ItemColor = item.ItemColor;

            dataContext.Items.Update(dbItem);
            await dataContext.SaveChangesAsync();

            return item;
        }

        public async Task<Item> DeleteItemAsync(int itemId)
        {
            Item? item = dataContext.Items!.Find(itemId);
            if (item is null) return null!;

            dataContext.Items.Remove(item);
            await dataContext.SaveChangesAsync();

            return item;
        }
    }
}