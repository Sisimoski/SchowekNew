using Schowek.Library.Models;

namespace Schowek.Library.Interfaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetItems();
        Task<Item> GetItem(int itemId);
        Task<Item> AddItem(Item item);
        Task<Item> UpdateItem(Item item);
        Task<Item> DeleteItem(int itemId);
    }
}