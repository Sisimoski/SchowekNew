using Schowek.Library.Models;

namespace Schowek.Library.Interfaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetItemsAsync();
        Task<Item> GetItemAsync(int itemId);
        Task<Item> AddItem(Item item);
        Task<Item?> UpdateItem(int itemId, Item item);
        Task<Item> DeleteItem(int itemId);
    }
}