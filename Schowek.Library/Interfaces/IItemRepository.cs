using Schowek.Library.Models;

namespace Schowek.Library.Interfaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetItemsAsync();
        Task<Item> GetItemAsync(int itemId);
        Task<Item> AddItemAsync(Item item);
        Task<Item?> UpdateItemAsync(int itemId, Item item);
        Task<Item> DeleteItemAsync(int itemId);
    }
}