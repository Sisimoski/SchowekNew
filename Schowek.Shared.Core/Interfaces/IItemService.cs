using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schowek.Shared.Domain.Models;

namespace Schowek.Shared.Core.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetItemsAsync();
        Task<Item> GetItemAsync(int itemId);
        Task<Item> AddItemAsync(Item item);
        Task<Item?> UpdateItemAsync(int itemId, Item item);
        Task<Item> DeleteItemAsync(int itemId);
    }
}